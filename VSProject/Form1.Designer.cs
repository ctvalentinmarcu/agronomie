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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.info3 = new System.Windows.Forms.Button();
            this.info2 = new System.Windows.Forms.Button();
            this.info1 = new System.Windows.Forms.Button();
            this.info0 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretProdus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownChFixe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileButton
            // 
            this.openFileButton.BackColor = System.Drawing.Color.ForestGreen;
            this.openFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openFileButton.ForeColor = System.Drawing.Color.Yellow;
            this.openFileButton.Location = new System.Drawing.Point(70, 12);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(201, 28);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.Text = "Deschide fișier";
            this.openFileButton.UseVisualStyleBackColor = false;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // inputGridView
            // 
            this.inputGridView.BackgroundColor = System.Drawing.Color.ForestGreen;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inputGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.inputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.inputGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.inputGridView.GridColor = System.Drawing.Color.Yellow;
            this.inputGridView.Location = new System.Drawing.Point(48, 53);
            this.inputGridView.Name = "inputGridView";
            this.inputGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inputGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.inputGridView.Size = new System.Drawing.Size(244, 234);
            this.inputGridView.TabIndex = 1;
            // 
            // inputDataSet
            // 
            this.inputDataSet.DataSetName = "NewDataSet";
            // 
            // computeCoefficientsButton
            // 
            this.computeCoefficientsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.computeCoefficientsButton.ForeColor = System.Drawing.Color.Yellow;
            this.computeCoefficientsButton.Location = new System.Drawing.Point(44, 312);
            this.computeCoefficientsButton.Name = "computeCoefficientsButton";
            this.computeCoefficientsButton.Size = new System.Drawing.Size(270, 28);
            this.computeCoefficientsButton.TabIndex = 2;
            this.computeCoefficientsButton.Text = "Pas 1: Calculează funcția de producție";
            this.computeCoefficientsButton.UseVisualStyleBackColor = false;
            this.computeCoefficientsButton.Click += new System.EventHandler(this.computeCoefficientsButton_Click);
            // 
            // plotView1
            // 
            this.plotView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView1.BackColor = System.Drawing.Color.ForestGreen;
            this.plotView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plotView1.Location = new System.Drawing.Point(320, 12);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(690, 491);
            this.plotView1.TabIndex = 3;
            this.plotView1.Text = "plotViewProd";
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            this.plotView1.DoubleClick += new System.EventHandler(this.plotView1_DoubleClick);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Yellow;
            this.button2.Location = new System.Drawing.Point(44, 450);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(270, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "Pas 2: Interpretarea economică";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(80, 489);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Preț vânzare produs (lei/kg)";
            // 
            // updownPretProdus
            // 
            this.updownPretProdus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updownPretProdus.DecimalPlaces = 2;
            this.updownPretProdus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownPretProdus.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretProdus.Location = new System.Drawing.Point(130, 508);
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
            this.updownPretFactor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updownPretFactor.DecimalPlaces = 2;
            this.updownPretFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownPretFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.updownPretFactor.Location = new System.Drawing.Point(130, 565);
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
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(80, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Preț achiziție factor (lei / kg sa)";
            // 
            // updownChFixe
            // 
            this.updownChFixe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.updownChFixe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updownChFixe.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updownChFixe.Location = new System.Drawing.Point(130, 625);
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
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(102, 606);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Cheltuieli fixe (lei / ha)";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(58, 709);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 54);
            this.label4.TabIndex = 24;
            this.label4.Text = "Opțional, dublu-clic pe fiecare grafic pentru exportare (format .png) în afara ap" +
    "licației";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // plotView2
            // 
            this.plotView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotView2.BackColor = System.Drawing.Color.ForestGreen;
            this.plotView2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plotView2.Location = new System.Drawing.Point(320, 516);
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
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.ForeColor = System.Drawing.Color.Yellow;
            this.button3.Location = new System.Drawing.Point(44, 679);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(270, 28);
            this.button3.TabIndex = 27;
            this.button3.Text = "Pas 3: Exportă statistici (Excel)";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(12, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 54);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Intervale de încredere";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(236, 21);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(62, 20);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.Text = "99.9%";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(185, 21);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(52, 20);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "99%";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(134, 21);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(52, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "95%";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(83, 21);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(52, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "90%";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 21);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "80%";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // info3
            // 
            this.info3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.info3.BackColor = System.Drawing.Color.Transparent;
            this.info3.BackgroundImage = global::MarcuLicenta.Properties.Resources.info;
            this.info3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info3.ForeColor = System.Drawing.Color.Yellow;
            this.info3.Location = new System.Drawing.Point(3, 673);
            this.info3.Name = "info3";
            this.info3.Size = new System.Drawing.Size(40, 40);
            this.info3.TabIndex = 31;
            this.info3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.info3.UseVisualStyleBackColor = false;
            this.info3.Click += new System.EventHandler(this.info3_Click);
            // 
            // info2
            // 
            this.info2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.info2.BackColor = System.Drawing.Color.Transparent;
            this.info2.BackgroundImage = global::MarcuLicenta.Properties.Resources.info;
            this.info2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info2.ForeColor = System.Drawing.Color.Yellow;
            this.info2.Location = new System.Drawing.Point(3, 444);
            this.info2.Name = "info2";
            this.info2.Size = new System.Drawing.Size(40, 40);
            this.info2.TabIndex = 30;
            this.info2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.info2.UseVisualStyleBackColor = false;
            this.info2.Click += new System.EventHandler(this.info2_Click);
            // 
            // info1
            // 
            this.info1.BackColor = System.Drawing.Color.Transparent;
            this.info1.BackgroundImage = global::MarcuLicenta.Properties.Resources.info;
            this.info1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info1.ForeColor = System.Drawing.Color.Yellow;
            this.info1.Location = new System.Drawing.Point(3, 306);
            this.info1.Name = "info1";
            this.info1.Size = new System.Drawing.Size(40, 40);
            this.info1.TabIndex = 29;
            this.info1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.info1.UseVisualStyleBackColor = false;
            this.info1.Click += new System.EventHandler(this.info1_Click);
            // 
            // info0
            // 
            this.info0.BackColor = System.Drawing.Color.Transparent;
            this.info0.BackgroundImage = global::MarcuLicenta.Properties.Resources.info;
            this.info0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.info0.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info0.ForeColor = System.Drawing.Color.Yellow;
            this.info0.Location = new System.Drawing.Point(3, 6);
            this.info0.Name = "info0";
            this.info0.Size = new System.Drawing.Size(40, 40);
            this.info0.TabIndex = 28;
            this.info0.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.info0.UseVisualStyleBackColor = false;
            this.info0.Click += new System.EventHandler(this.info0_Click);
            // 
            // Form1
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1034, 771);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.info3);
            this.Controls.Add(this.info2);
            this.Controls.Add(this.info1);
            this.Controls.Add(this.info0);
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
            this.MinimumSize = new System.Drawing.Size(1050, 711);
            this.Name = "Form1";
            this.Text = "Modelarea, simularea si interpretarea dependentei 1F -1P";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretProdus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownPretFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownChFixe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button info0;
        private System.Windows.Forms.Button info1;
        private System.Windows.Forms.Button info2;
        private System.Windows.Forms.Button info3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
    }
}

