using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        string delimiter = ",";
        string inputTableName = "inputTableName";
        DataSet inputDataset = new DataSet();

        int indexOfSize = 8; // this index indicates the number of measurements in file
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        //int measurements = 0;

        double sumN0, sumN1, sumN2, sumN3, sumN4, sumFN0, sumFN1, sumFN2;
       
        // A * X = B, where X = (c, b, a)
        double coefA, coefB, coefC;

        private void computeCoefficientsButton_Click(object sender, EventArgs e)
        {
            computeCoefficients();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputDataset = new DataSet();
            inputDataset.Tables.Add(inputTableName);
 
            inputDataset.Tables[inputTableName].Columns.Add("Doza");
            inputDataset.Tables[inputTableName].Columns.Add("Productie");

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = inputDataset.Tables[inputTableName];
            inputGridView.DataSource = bs1; 
        }

       
        

        

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

       

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void updownPretProdus_ValueChanged(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string line;
            //string[] components = new string[]();
            System.IO.Stream fileStream = openFileDialog2.OpenFile();

            using (System.IO.StreamReader file = new System.IO.StreamReader(fileStream))
            {
                if ((line = file.ReadLine()) != null)
                {
                    char[] delimiters = new char[] { ',' };
                    string[] parts = line.Split(delimiters,
                                     StringSplitOptions.RemoveEmptyEntries);
                    //string s = parts[indexOfSize].Trim();
                    //measurements = int.Parse(s);

                    for (int i = indexOfSize+1; i+1 < parts.Length; i+=2)
                    {
                        string s1 = parts[i].Trim();
                        string s2 = parts[i+1].Trim();
                        double N = double.Parse(s1,System.Globalization.NumberStyles.Number);                     
                        double f = double.Parse(s2, System.Globalization.NumberStyles.Number);               

                        //int currentMeasurement = (i - indexOfSize) / 2;
                        inputs.Add(N);
                        outputs.Add(f);

                        DataRow row = inputDataset.Tables[inputTableName].NewRow();
                        row[0] = N;
                        row[1] = f;
                        inputDataset.Tables[inputTableName].Rows.Add(row);
                        //Console.WriteLine("Added {0} {1}", N, f);
                    }                    
                }
            }
            fileStream.Close();
        }

        private void inputGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void updownPretFactor_ValueChanged(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

        private void updownChFixe_ValueChanged(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

        private void updownMarja_ValueChanged(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

        private void computeCoefficients()
        {
            computeSums();

            double[,] A = new double[3, 3] { { sumN2, sumN1, sumN0 }, { sumN3, sumN2, sumN1 }, { sumN4, sumN3, sumN2 } };
            double[] B = new double[3] { sumFN0, sumFN1, sumFN2 };

            coefC = detX2(A, B) / det(A);
            coefB = detX1(A, B) / det(A);
            coefA = detX0(A, B) / det(A);

            //Console.WriteLine("Coefficients: c = {0:0.###}; b = {1:0.###}; a = {2:0.###}", coefC, coefB, coefA);

            plotFunction();
        }


        private void plotFunction()
        {
            plotView1.InvalidatePlot(false);
            plotView2.InvalidatePlot(false);

            double radDelta = Math.Sqrt(coefB * coefB - 4 * coefA * coefC);
            double N1 = (-coefB - radDelta) / (2 * coefC);
            double N2 = (-coefB + radDelta) / (2 * coefC);
            double maxN = Math.Max(N1, N2);

            double lastX = Math.Min(maxN, -coefB / coefC);

            var model = new PlotModel
            {
                Title = string.Format("F(N) = {0:0.###} * N^2  +  {1:0.###} * N  +  {2:0.###}", coefC, coefB, coefA, computeCorelation()),
                Subtitle = string.Format("coeficient de corelatie = {0:0.###}", computeCorelation()),
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };

            // Define X-Axis
            var Xaxis = new OxyPlot.Axes.LinearAxis();
            Xaxis.Maximum = double.NaN;
            Xaxis.Minimum = 0;
            Xaxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            Xaxis.Title = "Doza aplicata (kgsa / ha)";
            model.Axes.Add(Xaxis);

            //Define Y-Axis
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            //Yaxis.MajorStep = 15;
            Yaxis.Maximum = double.NaN;
            Yaxis.MaximumPadding = 0;
            Yaxis.Minimum = 0;
            Yaxis.MinimumPadding = 0;
            //Yaxis.MinorStep = 5;
            Yaxis.Title = "Productie realizata (kg/ha)";
            model.Axes.Add(Yaxis);

            model.Series.Add(new FunctionSeries(x => coefC * x * x + coefB * x + coefA,
                0, lastX, 100, "Productie"));

            var discreteSeries = new StemSeries();
            foreach (double N in inputs)
            {
                var point = new DataPoint(N, outputs[inputs.IndexOf(N)]);
                discreteSeries.Points.Add(point);
            }
            model.Series.Add(discreteSeries);
            plotView1.Model = model;
            plotView1.Refresh();
        }

        private void refreshInterpretation()
        {
            refreshPlot1();
            refreshPlot2();
        }

        private void refreshPlot1()
        {
            double py = (double) updownPretProdus.Value;
            double pN = (double) updownPretFactor.Value;
            double chF = (double) updownChFixe.Value;
            //double trust = (double)updownMarja.Value;

            plotView1.Invalidate();

            double radDelta = Math.Sqrt(coefB * coefB - 4 * coefA * coefC);
            double N1 = (-coefB - radDelta) / (2 * coefC);
            double N2 = (-coefB + radDelta) / (2 * coefC);
            double maxN = Math.Max(N1, N2);

            double lastX = Math.Min(maxN, -coefB / coefC);

            double maxTehnic = -coefB / (2 * coefC);
            double optimEconomic = (pN - coefB * py) / (2 * coefC * py);
            double pragRent = pragRentabilitate();
            
            var model = new PlotModel
            {
                Title = string.Format("pragRent = {0:0.#} kgsa, maxTehnic = {1:0.#} kgsa; optimEc = {2:0.#} kgsa;", pragRent, maxTehnic, optimEconomic),
                Subtitle = string.Format("pretProdus = {0:0.#} lei/kg; pretFactor = {1:0.#} lei/kg; ChFixe = {2:0} lei", py, pN, chF),
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };

            // Define X-Axis
            var Xaxis = new OxyPlot.Axes.LinearAxis();
            Xaxis.Maximum = double.NaN;
            Xaxis.Minimum = 0;
            Xaxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            Xaxis.Title = "Doza aplicata";
            model.Axes.Add(Xaxis);

            //Define Y-Axis
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            //Yaxis.MajorStep = 15;
            Yaxis.Maximum = double.NaN;
            Yaxis.MaximumPadding = 0;
            Yaxis.Minimum = double.NaN;
            Yaxis.MinimumPadding = 0;
            //Yaxis.MinorStep = 5;
            Yaxis.Title = "Cheltuieli, Incasari, Profituri";
            model.Axes.Add(Yaxis);

            
            model.Series.Add(new FunctionSeries(x => F(x) * py,
                0, lastX, 100, "Incasari"));
            model.Series.Add(new FunctionSeries(x => x * pN + chF,
                0, lastX, 100, "Cheltuieli"));
            model.Series.Add(new FunctionSeries(x => F(x) * py - (x * pN + chF),
                0, lastX, 100, "Profit"));

            var discreteSeries = new StemSeries();
            var maxTehnicPoint = new DataPoint(maxTehnic, F(maxTehnic)*py);
            discreteSeries.Points.Add(maxTehnicPoint);
            var maxTehnicPoint2 = new DataPoint(maxTehnic, maxTehnic*pN + chF);
            discreteSeries.Points.Add(maxTehnicPoint2);
            var maxTehnicPoint3 = new DataPoint(maxTehnic, F(maxTehnic) * py - (maxTehnic * pN + chF));
            discreteSeries.Points.Add(maxTehnicPoint3);
            model.Series.Add(discreteSeries);

            var discreteSeries2 = new StemSeries();
            var optEcPoint = new DataPoint(optimEconomic, F(optimEconomic)*py);
            discreteSeries2.Points.Add(optEcPoint);
            var optEcPoint2 = new DataPoint(optimEconomic, optimEconomic * pN + chF);
            discreteSeries2.Points.Add(optEcPoint2);
            var optEcPoint3 = new DataPoint(optimEconomic, F(optimEconomic) * py - (optimEconomic * pN + chF));
            discreteSeries2.Points.Add(optEcPoint3);
            model.Series.Add(discreteSeries2);


            var discreteSeries3 = new StemSeries();
            var pragRentPoint = new DataPoint(pragRent, F(pragRent) * py);
            discreteSeries3.Points.Add(pragRentPoint);
            model.Series.Add(discreteSeries3);

            plotView1.Model = model;
            plotView1.Refresh();
        }

        

        private void refreshPlot2()
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;
            //double trust = (double)updownMarja.Value;

            plotView2.Invalidate();

            double radDelta = Math.Sqrt(coefB * coefB - 4 * coefA * coefC);
            double N1 = (-coefB - radDelta) / (2 * coefC);
            double N2 = (-coefB + radDelta) / (2 * coefC);
            double maxN = Math.Max(N1, N2);

            double lastX = Math.Min(maxN, -coefB / coefC);

            double maxTehnic = -coefB / (2 * coefC);
            double optimEconomic = (pN - coefB * py) / (2 * coefC * py);

            var model = new PlotModel
            {
                Title = "Cheltuieli, Incasari si Profituri marginale",
                Subtitle = string.Format("pretProdus = {0:0.#} lei/kg; pretFactor = {1:0.#} lei/kg; ChFixe = {2:0} lei", py, pN, chF),
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };

            // Define X-Axis
            var Xaxis = new OxyPlot.Axes.LinearAxis();
            Xaxis.Maximum = double.NaN;
            Xaxis.Minimum = 0;
            Xaxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            Xaxis.Title = "Doza aplicata";
            model.Axes.Add(Xaxis);

            //Define Y-Axis
            var Yaxis = new OxyPlot.Axes.LinearAxis();
            //Yaxis.MajorStep = 5;
            Yaxis.Maximum = double.NaN;
            Yaxis.MaximumPadding = 0;
            Yaxis.Minimum = double.NaN;
            Yaxis.MinimumPadding = 0;
            //Yaxis.MinorStep = 1;
            Yaxis.Title = "Valori marginale";
           
            model.Axes.Add(Yaxis);


            model.Series.Add(new FunctionSeries(x => Fd(x) * py,
                0, lastX, 100, "Incasari marginale"));
            model.Series.Add(new FunctionSeries(x => pN,
                0, lastX, 100, "Cheltuieli marginale"));
            model.Series.Add(new FunctionSeries(x => Fd(x) * py - pN,
                0, lastX, 100, "Profit marginal"));

            var discreteSeries = new StemSeries();
            var maxTehnicPoint = new DataPoint(maxTehnic, Fd(maxTehnic) * py);
            discreteSeries.Points.Add(maxTehnicPoint);
            var maxTehnicPoint2 = new DataPoint(maxTehnic, pN);
            discreteSeries.Points.Add(maxTehnicPoint2);
            var maxTehnicPoint3 = new DataPoint(maxTehnic, Fd(maxTehnic) * py - pN);
            discreteSeries.Points.Add(maxTehnicPoint3);
            model.Series.Add(discreteSeries);

            var discreteSeries2 = new StemSeries();
            var optEcPoint = new DataPoint(optimEconomic, Fd(optimEconomic) * py);
            discreteSeries2.Points.Add(optEcPoint);
            var optEcPoint2 = new DataPoint(optimEconomic, pN);
            discreteSeries2.Points.Add(optEcPoint2);
            var optEcPoint3 = new DataPoint(optimEconomic, Fd(optimEconomic) * py - pN);
            discreteSeries2.Points.Add(optEcPoint3);
            model.Series.Add(discreteSeries2);

            plotView2.Model = model;
            plotView2.Refresh();
        }


        private double F(double N)
        {
            return coefA + coefB * N + coefC * N * N;
        }
        // derivata lui F
        private double Fd(double N)
        {
            return coefB + coefC * N * 2;
        }


        private double computeCorelation()
        {
            double med = outputs.Average();
            double sum1 = inputs.Select((n, i) => Math.Pow(F(n) - outputs[i], 2)).Sum();
            double sum2 = inputs.Select((n, i) => Math.Pow(med - outputs[i], 2)).Sum();
            double coef = Math.Sqrt((sum2-sum1) / sum2);
            return coef;
        }


        private double pragRentabilitate()
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;

            //  F(x) * py - (x * pN + chF),

            double a = coefA * py - chF;
            double b = coefB * py - pN;
            double c = coefC * py;

            if(b * b - 4 * a * c < 0)
            {
                return 0;
            }

            double radDelta = Math.Sqrt(b * b - 4 * a * c);
            double N1 = (-b - radDelta) / (2 * c);
            double N2 = (-b + radDelta) / (2 * c);
            double minN = Math.Min(N1, N2);

            double prag = Math.Max(0, minN);
            return prag;
        }

        private void computeSums()
        {
            sumN0 = inputs.Count;
            sumN1 = inputs.Sum();
            sumN2 = inputs.Select(N => N * N).Sum();
            sumN3 = inputs.Select(N => N * N * N).Sum();
            sumN4 = inputs.Select(N => N * N * N * N).Sum();
            
            sumFN0 = outputs.Sum();
            sumFN1 = outputs.Select((f,i) => f * inputs[i]).Sum();
            sumFN2 = outputs.Select((f, i) => f * inputs[i] * inputs[i]).Sum();
            //Console.WriteLine("Sums: {0} {1} {2} {3} {4} {5} {6} {7}", 
            //  sumN0, sumN1, sumN2, sumN3, sumN4, sumFN0, sumFN1, sumFN2);
        }

        private double det(double[,] a)
        {
            double d =
                (a[0, 2] * a[1, 1] * a[2, 0] + a[0, 0] * a[1, 2] * a[2, 1] + a[0, 1] * a[1, 0] * a[2, 2]) -
                (a[0, 0] * a[1, 1] * a[2, 2] + a[0, 1] * a[1, 2] * a[2, 0] + a[0, 2] * a[1, 0] * a[2, 1]);
            if(Math.Abs(d) < 0.001)
            {
                d = 0.001;
            }
            return d;
        }

        private double detX2(double[,] a, double[] b)
        {
            double d =
                (a[0, 2] * a[1, 1] * b[2] + b[0] * a[1, 2] * a[2, 1] + a[0, 1] * b[1] * a[2, 2]) -
                (b[0] * a[1, 1] * a[2, 2] + a[0, 1] * a[1, 2] * b[2] + a[0, 2] * b[1] * a[2, 1]);
            return d;
        }

        private double detX1(double[,] a, double[] b)
        {
            double d =
                (a[0, 2] * b[1] * a[2, 0] + a[0, 0] * a[1, 2] * b[2] + b[0] * a[1, 0] * a[2, 2]) -
                (a[0, 0] * b[1] * a[2, 2] + b[0] * a[1, 2] * a[2, 0] + a[0, 2] * a[1, 0] * b[2]);            
            return d;
        }

        private double detX0(double[,] a, double[] b)
        {
            double d =
                (b[0] * a[1, 1] * a[2, 0] + a[0, 0] * b[1] * a[2, 1] + a[0, 1] * a[1, 0] * b[2]) -
                (a[0, 0] * a[1, 1] * b[2] + a[0, 1] *b[1] * a[2, 0] + b[0] * a[1, 0] * a[2, 1]);
            return d;
        }

        private void plotView1_DoubleClick(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void plotView2_DoubleClick(object sender, EventArgs e)
        {
            saveFileDialog2.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            pngExporter.ExportToFile(plotView1.Model, fileName);
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog2.FileName;
            var pngExporter = new PngExporter { Width = 600, Height = 400, Background = OxyColors.White };
            pngExporter.ExportToFile(plotView2.Model, fileName);
        }
    }
}
