namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.inputGridView = new System.Windows.Forms.DataGridView();
            this.inputDataSet = new System.Data.DataSet();
            this.computeCoefficientsButton = new System.Windows.Forms.Button();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updownPretProdus = new System.Windows.Forms.NumericUpDown();
            this.updownPretFactor = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.updownChFixe = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.plotView2 = new OxyPlot.WindowsForms.PlotView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog3 = new System.Windows.Forms.SaveFileDialog();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretProdus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownChFixe)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(70, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(201, 23);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Deschide fisier";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // inputGridView
            // 
            this.inputGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.inputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N3";
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.inputGridView.Location = new System.Drawing.Point(58, 53);
            this.inputGridView.Name = "inputGridView";
            this.inputGridView.ReadOnly = true;
            this.inputGridView.Size = new System.Drawing.Size(242, 234);
            this.inputGridView.TabIndex = 1;
            // 
            // inputDataSet
            // 
            this.inputDataSet.DataSetName = "NewDataSet";
            // 
            // computeCoefficientsButton
            // 
            this.computeCoefficientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.computeCoefficientsButton.Location = new System.Drawing.Point(57, 305);
            this.computeCoefficientsButton.Name = "computeCoefficientsButton";
            this.computeCoefficientsButton.Size = new System.Drawing.Size(243, 23);
            this.computeCoefficientsButton.TabIndex = 2;
            this.computeCoefficientsButton.Text = "Pas 1: Calculeaza functia de productie";
            this.computeCoefficientsButton.UseVisualStyleBackColor = true;
            this.computeCoefficientsButton.Click += new System.EventHandler(this.computeCoefficientsButton_Click);
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.White;
            this.plotView1.Location = new System.Drawing.Point(320, 12);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(690, 399);
            this.plotView1.TabIndex = 3;
            this.plotView1.Text = "plotViewProd";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView1.DoubleClick += new System.EventHandler(this.plotView1_DoubleClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(57, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(243, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Pas 2: Interpretarea economica";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(80, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pret vanzare produs (lei/kg)";
            // 
            // updownPretProdus
            // 
            this.updownPretProdus.DecimalPlaces = 2;
            this.updownPretProdus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownPretProdus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretProdus.Location = new System.Drawing.Point(130, 397);
            this.updownPretProdus.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretProdus.Name = "updownPretProdus";
            this.updownPretProdus.Size = new System.Drawing.Size(69, 26);
            this.updownPretProdus.TabIndex = 19;
            this.updownPretProdus.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretProdus.ValueChanged += new System.EventHandler(this.updownPretProdus_ValueChanged);
            // 
            // updownPretFactor
            // 
            this.updownPretFactor.DecimalPlaces = 2;
            this.updownPretFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownPretFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretFactor.Location = new System.Drawing.Point(130, 468);
            this.updownPretFactor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretFactor.Name = "updownPretFactor";
            this.updownPretFactor.Size = new System.Drawing.Size(69, 26);
            this.updownPretFactor.TabIndex = 21;
            this.updownPretFactor.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretFactor.ValueChanged += new System.EventHandler(this.updownPretFactor_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(80, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Pret achizitie factor (lei / kg sa)";
            // 
            // updownChFixe
            // 
            this.updownChFixe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownChFixe.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updownChFixe.Location = new System.Drawing.Point(130, 541);
            this.updownChFixe.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.updownChFixe.Name = "updownChFixe";
            this.updownChFixe.Size = new System.Drawing.Size(69, 26);
            this.updownChFixe.TabIndex = 23;
            this.updownChFixe.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownChFixe.ValueChanged += new System.EventHandler(this.updownChFixe_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(102, 522);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cheltuieli fixe (lei / ha)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(58, 618);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 54);
            this.label4.TabIndex = 24;
            this.label4.Text = "Optional, dublu-clic pe fiecare grafic pentru exportare (format .png) in afara ap" +
    "licatiei";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // plotView2
            // 
            this.plotView2.BackColor = System.Drawing.Color.White;
            this.plotView2.Location = new System.Drawing.Point(320, 417);
            this.plotView2.Name = "plotView2";
            this.plotView2.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView2.Size = new System.Drawing.Size(689, 243);
            this.plotView2.TabIndex = 26;
            this.plotView2.Text = "plotViewProd";
            this.plotView2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView2.DoubleClick += new System.EventHandler(this.plotView2_DoubleClick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.FileName = "f1p1plot";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.DefaultExt = "png";
            this.saveFileDialog2.FileName = "f1p1plot";
            this.saveFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog2_FileOk);
            // 
            // saveFileDialog3
            // 
            this.saveFileDialog3.DefaultExt = "xlsx";
            this.saveFileDialog3.FileName = "statistici";
            this.saveFileDialog3.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog3_FileOk);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(57, 592);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(243, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Pas 3: Exporta statistici (Excel)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1076, 672);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.plotView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.updownChFixe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updownPretFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updownPretProdus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.plotView1);
            this.Controls.Add(this.computeCoefficientsButton);
            this.Controls.Add(this.inputGridView);
            this.Controls.Add(this.openFileButton);
            this.Name = "Form1";
            this.Text = "Modelarea, simularea si interpretarea dependentei 1F -1P";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretProdus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownChFixe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.DataGridView inputGridView;
        private System.Data.DataSet inputDataSet;
        private System.Windows.Forms.Button computeCoefficientsButton;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown updownPretProdus;
        private System.Windows.Forms.NumericUpDown updownPretFactor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown updownChFixe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private OxyPlot.WindowsForms.PlotView plotView2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog3;
        private System.Windows.Forms.Button button3;
    }
}

