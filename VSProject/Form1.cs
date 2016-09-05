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

using ExportToExcel;
using System.Diagnostics;
using MarcuLicenta;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        struct Results
        {
            public double coefA;
            public double coefB;
            public double coefC;
            public double correlation;
            public double Fcal;
            public double f1;
            public double f5;
            public double stdDev; // abaterea
            public double tp2; // p = 80%
            public double tp1; // p = 90%
            public double tp05; // p = 95%
            public double tp01; // p = 99%
            public double tp001; // p = 99.9%
        }

        struct Optim
        {
            public double pragRentabilitate;
            public double maxTehnic;
            public double optimEconomic;
        }

        Results results;
        Optim optim;

        string delimiter = ",";
        string inputTableName = "Date initiale";
        DataSet inputDataset = new DataSet();

        int indexOfSize = 8; // this index indicates the number of measurements in file
        List<double> inputs = new List<double>();
        List<double> outputs = new List<double>();
        //int measurements = 0;

        double sumN0, sumN1, sumN2, sumN3, sumN4, sumFN0, sumFN1, sumFN2;

        // A * X = B, where X = (c, b, a)
        double coefA, coefB, coefC;

        double highestN;

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
            inputGridView.ReadOnly = false;
            inputGridView.DefaultCellStyle.Format = "N2";
            inputGridView.RowsDefaultCellStyle.Format = "N2";
            inputGridView.KeyPress += new KeyPressEventHandler(KeyPressed);
        }


        private void readDataFromInputGrid()
        {
            //return;
            DataTable tempTable = new DataTable();
            tempTable.Columns.Add("Doza");
            tempTable.Columns.Add("Productie");
            tempTable.Rows.Clear();
            inputs.Clear();
            outputs.Clear();

            foreach(DataGridViewRow gridRow in inputGridView.Rows)
            {
                DataRow row = tempTable.NewRow();

                if (gridRow.Cells[0].Value == null || gridRow.Cells[1].Value == null)
                {
                    continue;
                }

                string s1 = gridRow.Cells[0].Value.ToString();
                string s2 = gridRow.Cells[1].Value.ToString();

                if (s1 == null || s2 == null || s1.Length == 0 || s2.Length == 0)
                {
                    continue;
                }

                double N = 1;
                double f = 0;
                try
                {
                    N = double.Parse(s1.Trim(), System.Globalization.NumberStyles.Number);
                    f = double.Parse(s2.Trim(), System.Globalization.NumberStyles.Number);
                }
                catch (Exception e)
                {
                    continue;
                }
                row[0] = N; //double.Parse((string)gridRow.Cells[0].Value, System.Globalization.NumberStyles.Number);
                row[1] = f;
                inputs.Add(N);
                outputs.Add(f);
                tempTable.Rows.Add(row);
            }

            //inputDataSet.Tables[inputTableName].Rows.Clear(); //tempTable.Rows;
            //inputDataSet.Tables[inputTableName].Rows.Add(tempTable.Rows);

            inputDataset = new DataSet();
            //inputDataset.Tables.Add(inputTableName);
            tempTable.TableName = inputTableName;
            inputDataset.Tables.Add(tempTable);

            //inputDataset.Tables[inputTableName].Columns.Add("Doza");
            //inputDataset.Tables[inputTableName].Columns.Add("Productie");

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = inputDataset.Tables[inputTableName];
            inputGridView.DataSource = bs1;
            //inputGridView.ReadOnly = false;
            //inputGridView.DefaultCellStyle.Format = "N2";
            inputGridView.KeyPress += new KeyPressEventHandler(KeyPressed);
        }


        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                   && !char.IsDigit(e.KeyChar)
                   && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }


        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshInterpretation();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inputs.Count < 3)
            {
                return;
            }
            saveFileDialog3.ShowDialog();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            plotFunction();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            plotFunction();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            plotFunction();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            plotFunction();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            plotFunction();
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

                    inputDataset.Tables[inputTableName].Rows.Clear();

                    for (int i = indexOfSize + 1; i + 1 < parts.Length; i += 2)
                    {
                        string s1 = parts[i].Trim();
                        string s2 = parts[i + 1].Trim();
                        double N = double.Parse(s1, System.Globalization.NumberStyles.Number);
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
            readDataFromInputGrid();
            if(inputs.Count < 3)
            {
                return;
            }

            computeSums();

            double[,] A = new double[3, 3] { { sumN2, sumN1, sumN0 }, { sumN3, sumN2, sumN1 }, { sumN4, sumN3, sumN2 } };
            double[] B = new double[3] { sumFN0, sumFN1, sumFN2 };

            coefC = detX2(A, B) / det(A);
            coefB = detX1(A, B) / det(A);
            coefA = detX0(A, B) / det(A);

            results.coefA = coefA;
            results.coefB = coefB;
            results.coefC = coefC;

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

            double corelation = computeCorelation();

            var model = new PlotModel
            {
                Title = string.Format("F(N) = {0:0.###} * N^2  +  {1:0.###} * N  +  {2:0.###}", coefC, coefB, coefA, corelation),
                Subtitle = string.Format("coeficient de corelatie = {0:0.###}", corelation),
                PlotType = PlotType.XY,
                Background = OxyColors.White
            };

            // Define X-Axis
            var Xaxis = new OxyPlot.Axes.LinearAxis();
            Xaxis.Maximum = double.NaN;
            Xaxis.Minimum = 0;
            Xaxis.Position = OxyPlot.Axes.AxisPosition.Bottom;
            Xaxis.Title = "Doza aplicata (kgsa / ha)";
            Xaxis.PositionAtZeroCrossing = true;
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

            model.Series.Add(new FunctionSeries(x => F(x),
                0, lastX, 100, "Productie"));



            double currentInterval = getCurrentDelta();
            FunctionSeries fInf = new FunctionSeries(x => F(x) - currentInterval,
                0, lastX, 100, "Limite incredere");
            fInf.LineStyle = LineStyle.Dot;
            model.Series.Add(fInf);

            FunctionSeries fSup = new FunctionSeries(x => F(x) + currentInterval,
                0, lastX, 100);
            fSup.LineStyle = LineStyle.Dot;
            fSup.BrokenLineColor = fInf.BrokenLineColor;
            model.Series.Add(fSup);


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


        private double getCurrentDelta()
        {
            double delta = 0;
            double tp = results.tp2;

            if (radioButton1.Checked) { tp = results.tp2; }
            if (radioButton2.Checked) { tp = results.tp1; }
            if (radioButton3.Checked) { tp = results.tp05; }
            if (radioButton4.Checked) { tp = results.tp01; }
            if (radioButton5.Checked) { tp = results.tp001; }

            delta = tp * results.stdDev;

            return delta;
        }

        private void refreshInterpretation()
        {
            if (inputs.Count < 3)
            {
                return;
            }
            refreshPlot1();
            refreshPlot2();
        }

        private void refreshPlot1()
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;
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

            optim.pragRentabilitate = pragRent;
            optim.maxTehnic = maxTehnic;
            optim.optimEconomic = optimEconomic;

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
            Xaxis.PositionAtZeroCrossing = true;
            Xaxis.AxislineStyle = LineStyle.Dot;
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

            highestN = lastX;

            var f1 = new FunctionSeries(x => F(x) * py,
                0, lastX, 100, "Incasari");
            var f2 = new FunctionSeries(x => x * pN + chF,
                0, lastX, 100, "Cheltuieli");
            var f3 = new FunctionSeries(x => F(x) * py - (x * pN + chF),
                0, lastX, 100, "Profit");
            
            var f1Max = f1.Points.Max(p => p.Y);
            var f1Min = f1.Points.Min(p => p.Y);
            var f2Max = f2.Points.Max(p => p.Y);
            var f2Min = f2.Points.Min(p => p.Y);
            var f3Max = f3.Points.Max(p => p.Y);
            var f3Min = f3.Points.Min(p => p.Y);

            var minY = Math.Min(f1Min, Math.Min(f2Min, f3Min));
            var maxY = Math.Max(f1Max, Math.Max(f2Max, f3Max));

            model.Series.Add(f1);
            model.Series.Add(f2);
            model.Series.Add(f3);

            var discreteSeries = new StemSeries();

            var maxTehnicPointMin = new DataPoint(maxTehnic, 0);
            var maxTehnicPointMax = new DataPoint(maxTehnic, maxY);
            discreteSeries.Points.Add(maxTehnicPointMin);
            discreteSeries.Points.Add(maxTehnicPointMax);

            model.Series.Add(discreteSeries);

            var discreteSeries2 = new StemSeries();

            var optEcPointMin = new DataPoint(optimEconomic, 0);
            var optEcPointMax = new DataPoint(optimEconomic, maxY);
            discreteSeries2.Points.Add(optEcPointMin);
            discreteSeries2.Points.Add(optEcPointMax);

            model.Series.Add(discreteSeries2);

            var discreteSeries3 = new StemSeries();

            //var pragRentPoint = new DataPoint(pragRent, F(pragRent) * py);
            //discreteSeries3.Points.Add(pragRentPoint);

            var pragRentPointMin = new DataPoint(pragRent, 0);
            var pragRentPointMax = new DataPoint(pragRent, maxY);
            discreteSeries3.Points.Add(pragRentPointMin);
            discreteSeries3.Points.Add(pragRentPointMax);

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
            Xaxis.PositionAtZeroCrossing = true;
            Xaxis.AxislineStyle = LineStyle.Dot;
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


            var f1 = new FunctionSeries(x => Fd(x) * py,
                0, lastX, 100, "Incasari marginale");
            var f1Max = f1.Points.Max(p => p.Y);
            var f1Min = f1.Points.Min(p => p.Y);

            var f2 = new FunctionSeries(x => pN,
                0, lastX, 100, "Cheltuieli marginale");
            var f2Max = f2.Points.Max(p => p.Y);
            var f2Min = f2.Points.Min(p => p.Y);

            var f3 = new FunctionSeries(x => Fd(x) * py - pN,
                0, lastX, 100, "Profit marginal");
            var f3Max = f3.Points.Max(p => p.Y);
            var f3Min = f3.Points.Min(p => p.Y);

            var minY = Math.Min(f1Min, Math.Min(f2Min, f3Min));
            var maxY = Math.Max(f1Max, Math.Max(f2Max, f3Max));

            model.Series.Add(f1);
            model.Series.Add(f2);
            model.Series.Add(f3);

            var discreteSeries = new StemSeries();

            var maxTehnicPointMin = new DataPoint(maxTehnic, 0);
            discreteSeries.Points.Add(maxTehnicPointMin);
            var maxTehnicPointMax = new DataPoint(maxTehnic, maxY);
            discreteSeries.Points.Add(maxTehnicPointMax);
            model.Series.Add(discreteSeries);

            var discreteSeries2 = new StemSeries();


            var optEcPointMin = new DataPoint(optimEconomic, 0);
            discreteSeries2.Points.Add(optEcPointMin);
            var optEcPointMax = new DataPoint(optimEconomic, maxY);
            discreteSeries2.Points.Add(optEcPointMax);

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
            double corelation = Math.Sqrt((sum2 - sum1) / sum2);
            
            results.correlation = corelation;

            int nn = outputs.Count;
            results.stdDev = Math.Sqrt(sum2 / (nn*(nn-1)) );

            if (inputs.Count > 3)
            {
                results.Fcal = 0.5 * (inputs.Count - 3) * (sum2 - sum1) / sum1;

                double[] f1Values = new double[13] { 0, 0, 0, 30.82, 18, 13.27, 10.92, 9.55, 8.62, 8.02, 7.56, 7.2, 6.93 };
                double[] f5Values = new double[13] { 0, 0, 0, 9.55, 6.94, 5.79, 5.14, 4.74, 4.46, 4.26, 4.10, 3.98, 3.88 };

                int GL = inputs.Count - 1;
                results.f1 = f1Values[GL-1];
                results.f5 = f5Values[GL-1];

                
                double[] tp2Values = new double[12] { 0, 0, 1.886, 1.638, 1.533, 1.476, 1.44, 1.415, 1.397, 1.383, 1.372, 1.363 };
                double[] tp1Values = new double[12] { 0, 0, 2.92, 2.353, 2.132, 2.015, 1.943, 1.895, 1.86, 1.833, 1.812, 1.796 };
                double[] tp05Values = new double[12] { 0, 0, 4.303, 3.182, 2.776, 2.571, 2.447, 2.365, 2.306, 2.262, 2.228, 2.201 };
                double[] tp01Values = new double[12] { 0, 0, 9.925, 5.841, 4.604, 4.032, 3.707, 3.499, 3.355, 3.25, 3.169, 3.106 };
                double[] tp001Values = new double[12] { 0, 0, 31.598, 12.924, 8.61, 6.869, 5.959, 5.408, 5.041, 4.781, 4.587, 4.437 };

                if(GL > 11)
                {
                    GL = 11;
                }

                results.tp2 = tp2Values[GL];
                results.tp1 = tp1Values[GL];
                results.tp05 = tp05Values[GL];
                results.tp01 = tp01Values[GL];
                results.tp001 = tp001Values[GL];

            }

            


            return corelation;
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

            if (b * b - 4 * a * c < 0)
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
            sumFN1 = outputs.Select((f, i) => f * inputs[i]).Sum();
            sumFN2 = outputs.Select((f, i) => f * inputs[i] * inputs[i]).Sum();
            //Console.WriteLine("Sums: {0} {1} {2} {3} {4} {5} {6} {7}", 
            //  sumN0, sumN1, sumN2, sumN3, sumN4, sumFN0, sumFN1, sumFN2);
        }



        #region compute discriminants

        private double det(double[,] a)
        {
            double d =
                (a[0, 2] * a[1, 1] * a[2, 0] + a[0, 0] * a[1, 2] * a[2, 1] + a[0, 1] * a[1, 0] * a[2, 2]) -
                (a[0, 0] * a[1, 1] * a[2, 2] + a[0, 1] * a[1, 2] * a[2, 0] + a[0, 2] * a[1, 0] * a[2, 1]);
            if (Math.Abs(d) < 0.001)
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
                (a[0, 0] * a[1, 1] * b[2] + a[0, 1] * b[1] * a[2, 0] + b[0] * a[1, 0] * a[2, 1]);
            return d;
        }

        #endregion



        #region info PDF

        private void info0_Click(object sender, EventArgs e)
        {
            string filename = "info0.pdf";
            openPDF(filename);
        }

        private void info1_Click(object sender, EventArgs e)
        {
            string filename = "info1.pdf";
            openPDF(filename);
        }

        private void info2_Click(object sender, EventArgs e)
        {
            string filename = "info2.pdf";
            openPDF(filename);
        }

        private void info3_Click(object sender, EventArgs e)
        {
            string filename = "info3.pdf";
            openPDF(filename);
        }

        private void openPDF(string filename)
        {
            WebViewForm web = new WebViewForm();
            web.Text = filename;
            string path = Path.GetFullPath(filename);
            web.loadURL(path);
            web.Show();
        }

        #endregion


        #region export graphs to png

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

        #endregion


        #region export statistics to Excel

        private void saveFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog3.FileName;
            DataSet excelDataSet = new DataSet();

            excelDataSet.Tables.Add(inputDataset.Tables[inputTableName].Copy());

            DataTable resultsTable = new DataTable();
            resultsTable.TableName = "Validare";
            resultsTable.Columns.Add("coefA");
            resultsTable.Columns.Add("coefB");
            resultsTable.Columns.Add("coefC");
            resultsTable.Columns.Add("Fcal");
            resultsTable.Columns.Add("Corelatie");
            resultsTable.Columns.Add("f 1%");
            resultsTable.Columns.Add("f 5%");
            resultsTable.Columns.Add("Abatere");
            resultsTable.Columns.Add("tp 80%");
            resultsTable.Columns.Add("tp 90%");
            resultsTable.Columns.Add("tp 95%");
            resultsTable.Columns.Add("tp 99%");
            resultsTable.Columns.Add("tp 99.9%");
            DataRow row = resultsTable.NewRow();
            row[0] = results.coefA;
            row[1] = results.coefB;
            row[2] = results.coefC;
            row[3] = results.Fcal;
            row[4] = results.correlation;
            row[5] = results.f1;
            row[6] = results.f5;
            row[7] = results.stdDev;
            row[8] = results.tp2;
            row[9] = results.tp1;
            row[10] = results.tp05;
            row[11] = results.tp01;
            row[12] = results.tp001;
            resultsTable.Rows.Add(row);            
            excelDataSet.Tables.Add(resultsTable);

            DataTable optimTable = new DataTable();
            optimTable.TableName = "Valori de interes";
            optimTable.Columns.Add("Tip");
            optimTable.Columns.Add("Doza N (kgsa/ha)");
            optimTable.Columns.Add("F(N) (kg/ha)");
            DataRow optimRow1 = optimTable.NewRow();
            optimRow1[0] = "Prag Rentabilitate";
            optimRow1[1] = optim.pragRentabilitate;
            optimRow1[2] = F(optim.pragRentabilitate);
            optimTable.Rows.Add(optimRow1);
            DataRow optimRow2 = optimTable.NewRow();
            optimRow2[0] = "Maximum Tehnic";
            optimRow2[1] = optim.maxTehnic;
            optimRow2[2] = F(optim.maxTehnic);
            optimTable.Rows.Add(optimRow2);
            DataRow optimRow3 = optimTable.NewRow();
            optimRow3[0] = "Optim Economic";
            optimRow3[1] = optim.optimEconomic;
            optimRow3[2] = F(optim.optimEconomic);
            optimTable.Rows.Add(optimRow3);
            excelDataSet.Tables.Add(optimTable);

            DataTable pricesTable = new DataTable();
            pricesTable.TableName = "Preturi de referinta";
            pricesTable.Columns.Add("Tip");
            pricesTable.Columns.Add("Valoare (lei)");
            DataRow priceRow1 = pricesTable.NewRow();
            priceRow1[0] = "Pret vanzare produs (lei/kg)";
            priceRow1[1] = (double)updownPretProdus.Value;
            pricesTable.Rows.Add(priceRow1);
            DataRow priceRow2 = pricesTable.NewRow();
            priceRow2[0] = "Pret achizitie factor (lei/kgsa)";
            priceRow2[1] = (double)updownPretFactor.Value;
            pricesTable.Rows.Add(priceRow2);
            DataRow priceRow3 = pricesTable.NewRow();
            priceRow3[0] = "Cheltuieli fixe (lei / ha)";
            priceRow3[1] = (double)updownChFixe.Value;
            pricesTable.Rows.Add(priceRow3);
            excelDataSet.Tables.Add(pricesTable);

            DataTable valuesTable = new DataTable();
            valuesTable.TableName = "Rezultate economice";
            valuesTable.Columns.Add("Doza aplicata (kgsa/ha)");
            valuesTable.Columns.Add("Productie (kg/ha)");
            valuesTable.Columns.Add("Cheltuieli (lei/ha)");
            valuesTable.Columns.Add("Venituri (lei/ha)");
            valuesTable.Columns.Add("Profit (lei/ha)");
            valuesTable.Columns.Add("Cheltuieli marginale (lei/ha)");
            valuesTable.Columns.Add("Venituri marginale (lei/ha)");
            valuesTable.Columns.Add("Profit marginal (lei/ha)");
            int step = 0;
            for(step = 0; step <= highestN; step += 10)
            {
                DataRow r = valuesTable.NewRow();
                r[0] = step;
                r[1] = F(step);
                r[2] = Cheltuieli(step);
                r[3] = Incasari(step);
                r[4] = Profit(step);
                r[5] = CheltuieliMg(step);
                r[6] = IncasariMg(step);
                r[7] = ProfitMg(step);
                valuesTable.Rows.Add(r);
            }
            excelDataSet.Tables.Add(valuesTable);

            CreateExcelFile.CreateExcelDocument(excelDataSet, fileName);
        }

        //helpers

        private double Incasari(double x)
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;

            return F(x) * py;
        }

        private double Cheltuieli(double x)
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;

            return x * pN + chF;
        }

        private double Profit(double x)
        {
            return Incasari(x) - Cheltuieli(x);
        }


        private double IncasariMg(double x)
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;

            return Fd(x) * py;
        }

        private double CheltuieliMg(double x)
        {
            double py = (double)updownPretProdus.Value;
            double pN = (double)updownPretFactor.Value;
            double chF = (double)updownChFixe.Value;

            return pN;
        }

        private double ProfitMg(double x)
        {
            return IncasariMg(x) - CheltuieliMg(x);
        }

        #endregion
    }
}
