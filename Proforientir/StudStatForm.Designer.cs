namespace Proforientir
{
    partial class StudStatForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudStatForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAbit = new System.Windows.Forms.GroupBox();
            this.radioButtonCount = new System.Windows.Forms.RadioButton();
            this.radioButtonEx = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGraph1 = new System.Windows.Forms.Button();
            this.gbDraphX = new System.Windows.Forms.GroupBox();
            this.radioButtonCurs = new System.Windows.Forms.RadioButton();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.chPage2 = new LiveCharts.WinForms.CartesianChart();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDegr1 = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.chPage1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGraph2 = new System.Windows.Forms.Button();
            this.cmbDegr2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbActiv = new System.Windows.Forms.GroupBox();
            this.radioButtonInTime = new System.Windows.Forms.RadioButton();
            this.radioButtonBefore = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chPage3 = new LiveCharts.WinForms.PieChart();
            this.dataGraph = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGraph3 = new System.Windows.Forms.Button();
            this.gbAfter = new System.Windows.Forms.GroupBox();
            this.radioButtonLB = new System.Windows.Forms.RadioButton();
            this.radioButtonGrad = new System.Windows.Forms.RadioButton();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.gbAbit.SuspendLayout();
            this.gbDraphX.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chPage1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbActiv.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).BeginInit();
            this.gbAfter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "Стастистика о студентах";
            // 
            // gbAbit
            // 
            this.gbAbit.Controls.Add(this.radioButtonCount);
            this.gbAbit.Controls.Add(this.radioButtonEx);
            this.gbAbit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbAbit.Location = new System.Drawing.Point(6, 6);
            this.gbAbit.Name = "gbAbit";
            this.gbAbit.Size = new System.Drawing.Size(327, 84);
            this.gbAbit.TabIndex = 33;
            this.gbAbit.TabStop = false;
            this.gbAbit.Text = "Режим отображения (Ось Y)";
            // 
            // radioButtonCount
            // 
            this.radioButtonCount.AutoSize = true;
            this.radioButtonCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCount.Location = new System.Drawing.Point(6, 49);
            this.radioButtonCount.Name = "radioButtonCount";
            this.radioButtonCount.Size = new System.Drawing.Size(220, 24);
            this.radioButtonCount.TabIndex = 35;
            this.radioButtonCount.TabStop = true;
            this.radioButtonCount.Text = "Количество поступивших";
            this.radioButtonCount.UseVisualStyleBackColor = true;
            // 
            // radioButtonEx
            // 
            this.radioButtonEx.AutoSize = true;
            this.radioButtonEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonEx.Location = new System.Drawing.Point(6, 19);
            this.radioButtonEx.Name = "radioButtonEx";
            this.radioButtonEx.Size = new System.Drawing.Size(279, 24);
            this.radioButtonEx.TabIndex = 34;
            this.radioButtonEx.TabStop = true;
            this.radioButtonEx.Text = "Средние баллы при поступлении";
            this.radioButtonEx.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 22);
            this.label4.TabIndex = 34;
            this.label4.Text = "График зависимости:";
            // 
            // btnGraph1
            // 
            this.btnGraph1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGraph1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph1.Location = new System.Drawing.Point(343, 86);
            this.btnGraph1.Name = "btnGraph1";
            this.btnGraph1.Size = new System.Drawing.Size(330, 60);
            this.btnGraph1.TabIndex = 35;
            this.btnGraph1.Text = "Посторить график";
            this.btnGraph1.UseVisualStyleBackColor = true;
            this.btnGraph1.Click += new System.EventHandler(this.btnDel1_Click);
            // 
            // gbDraphX
            // 
            this.gbDraphX.Controls.Add(this.radioButtonCurs);
            this.gbDraphX.Controls.Add(this.radioButtonYear);
            this.gbDraphX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbDraphX.Location = new System.Drawing.Point(339, 6);
            this.gbDraphX.Name = "gbDraphX";
            this.gbDraphX.Size = new System.Drawing.Size(327, 84);
            this.gbDraphX.TabIndex = 37;
            this.gbDraphX.TabStop = false;
            this.gbDraphX.Text = "График (ось  X)";
            // 
            // radioButtonCurs
            // 
            this.radioButtonCurs.AutoSize = true;
            this.radioButtonCurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonCurs.Location = new System.Drawing.Point(7, 49);
            this.radioButtonCurs.Name = "radioButtonCurs";
            this.radioButtonCurs.Size = new System.Drawing.Size(137, 24);
            this.radioButtonCurs.TabIndex = 36;
            this.radioButtonCurs.TabStop = true;
            this.radioButtonCurs.Text = "номера курсов";
            this.radioButtonCurs.UseVisualStyleBackColor = true;
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonYear.Location = new System.Drawing.Point(7, 21);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(137, 24);
            this.radioButtonYear.TabIndex = 35;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "года обучения";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            // 
            // chPage2
            // 
            this.chPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chPage2.Location = new System.Drawing.Point(6, 185);
            this.chPage2.Name = "chPage2";
            this.chPage2.Size = new System.Drawing.Size(660, 248);
            this.chPage2.TabIndex = 38;
            this.chPage2.Text = "cartesianChart1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(339, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 22);
            this.label12.TabIndex = 57;
            this.label12.Text = "Ученая степень:";
            // 
            // cmbDegr1
            // 
            this.cmbDegr1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr1.FormattingEnabled = true;
            this.cmbDegr1.Location = new System.Drawing.Point(484, 6);
            this.cmbDegr1.Name = "cmbDegr1";
            this.cmbDegr1.Size = new System.Drawing.Size(189, 29);
            this.cmbDegr1.TabIndex = 58;
            this.cmbDegr1.SelectedIndexChanged += new System.EventHandler(this.cmbDegr1_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(12, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 468);
            this.tabControl1.TabIndex = 59;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chPage1);
            this.tabPage1.Controls.Add(this.cmbDegr1);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.gbAbit);
            this.tabPage1.Controls.Add(this.btnGraph1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Поступление";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 22);
            this.label2.TabIndex = 60;
            this.label2.Text = "График зависимости:";
            // 
            // chPage1
            // 
            chartArea1.Name = "ChartArea1";
            this.chPage1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chPage1.Legends.Add(legend1);
            this.chPage1.Location = new System.Drawing.Point(6, 186);
            this.chPage1.Name = "chPage1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chPage1.Series.Add(series1);
            this.chPage1.Size = new System.Drawing.Size(667, 243);
            this.chPage1.TabIndex = 59;
            this.chPage1.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGraph2);
            this.tabPage2.Controls.Add(this.chPage2);
            this.tabPage2.Controls.Add(this.cmbDegr2);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.gbActiv);
            this.tabPage2.Controls.Add(this.gbDraphX);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Активность";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnGraph2
            // 
            this.btnGraph2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGraph2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph2.Location = new System.Drawing.Point(339, 96);
            this.btnGraph2.Name = "btnGraph2";
            this.btnGraph2.Size = new System.Drawing.Size(327, 54);
            this.btnGraph2.TabIndex = 60;
            this.btnGraph2.Text = "Посторить график";
            this.btnGraph2.UseVisualStyleBackColor = true;
            this.btnGraph2.Click += new System.EventHandler(this.btnGraph2_Click);
            // 
            // cmbDegr2
            // 
            this.cmbDegr2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr2.FormattingEnabled = true;
            this.cmbDegr2.Location = new System.Drawing.Point(6, 118);
            this.cmbDegr2.Name = "cmbDegr2";
            this.cmbDegr2.Size = new System.Drawing.Size(327, 29);
            this.cmbDegr2.TabIndex = 59;
            this.cmbDegr2.SelectedIndexChanged += new System.EventHandler(this.cmbDegr2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 22);
            this.label5.TabIndex = 58;
            this.label5.Text = "Ученая степень:";
            // 
            // gbActiv
            // 
            this.gbActiv.Controls.Add(this.radioButtonInTime);
            this.gbActiv.Controls.Add(this.radioButtonBefore);
            this.gbActiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbActiv.Location = new System.Drawing.Point(6, 6);
            this.gbActiv.Name = "gbActiv";
            this.gbActiv.Size = new System.Drawing.Size(327, 84);
            this.gbActiv.TabIndex = 34;
            this.gbActiv.TabStop = false;
            this.gbActiv.Text = "Режим отображения (ось Y)";
            // 
            // radioButtonInTime
            // 
            this.radioButtonInTime.AutoSize = true;
            this.radioButtonInTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonInTime.Location = new System.Drawing.Point(6, 49);
            this.radioButtonInTime.Name = "radioButtonInTime";
            this.radioButtonInTime.Size = new System.Drawing.Size(239, 24);
            this.radioButtonInTime.TabIndex = 35;
            this.radioButtonInTime.TabStop = true;
            this.radioButtonInTime.Text = "Активность во время учебы";
            this.radioButtonInTime.UseVisualStyleBackColor = true;
            this.radioButtonInTime.CheckedChanged += new System.EventHandler(this.radioButtonInTime_CheckedChanged);
            // 
            // radioButtonBefore
            // 
            this.radioButtonBefore.AutoSize = true;
            this.radioButtonBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBefore.Location = new System.Drawing.Point(6, 19);
            this.radioButtonBefore.Name = "radioButtonBefore";
            this.radioButtonBefore.Size = new System.Drawing.Size(242, 24);
            this.radioButtonBefore.TabIndex = 34;
            this.radioButtonBefore.TabStop = true;
            this.radioButtonBefore.Text = "Активность до поступления";
            this.radioButtonBefore.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnUpdate);
            this.tabPage3.Controls.Add(this.chPage3);
            this.tabPage3.Controls.Add(this.dataGraph);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnGraph3);
            this.tabPage3.Controls.Add(this.gbAfter);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(679, 435);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Востребованность";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chPage3
            // 
            this.chPage3.Location = new System.Drawing.Point(6, 137);
            this.chPage3.Name = "chPage3";
            this.chPage3.Size = new System.Drawing.Size(356, 292);
            this.chPage3.TabIndex = 66;
            this.chPage3.Text = "pieChart1";
            // 
            // dataGraph
            // 
            this.dataGraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGraph.Location = new System.Drawing.Point(368, 137);
            this.dataGraph.Name = "dataGraph";
            this.dataGraph.ReadOnly = true;
            this.dataGraph.Size = new System.Drawing.Size(305, 118);
            this.dataGraph.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 63;
            this.label3.Text = "Диаграмма:";
            // 
            // btnGraph3
            // 
            this.btnGraph3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGraph3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph3.Location = new System.Drawing.Point(368, 16);
            this.btnGraph3.Name = "btnGraph3";
            this.btnGraph3.Size = new System.Drawing.Size(305, 74);
            this.btnGraph3.TabIndex = 61;
            this.btnGraph3.Text = "Посторить график";
            this.btnGraph3.UseVisualStyleBackColor = true;
            this.btnGraph3.Click += new System.EventHandler(this.btnGraph3_Click);
            // 
            // gbAfter
            // 
            this.gbAfter.Controls.Add(this.radioButtonLB);
            this.gbAfter.Controls.Add(this.radioButtonGrad);
            this.gbAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbAfter.Location = new System.Drawing.Point(6, 6);
            this.gbAfter.Name = "gbAfter";
            this.gbAfter.Size = new System.Drawing.Size(356, 84);
            this.gbAfter.TabIndex = 35;
            this.gbAfter.TabStop = false;
            this.gbAfter.Text = "Отобразить";
            // 
            // radioButtonLB
            // 
            this.radioButtonLB.AutoSize = true;
            this.radioButtonLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLB.Location = new System.Drawing.Point(6, 49);
            this.radioButtonLB.Name = "radioButtonLB";
            this.radioButtonLB.Size = new System.Drawing.Size(123, 24);
            this.radioButtonLB.TabIndex = 35;
            this.radioButtonLB.TabStop = true;
            this.radioButtonLB.Text = "Рынок труда";
            this.radioButtonLB.UseVisualStyleBackColor = true;
            this.radioButtonLB.CheckedChanged += new System.EventHandler(this.radioButtonLB_CheckedChanged);
            // 
            // radioButtonGrad
            // 
            this.radioButtonGrad.AutoSize = true;
            this.radioButtonGrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGrad.Location = new System.Drawing.Point(6, 19);
            this.radioButtonGrad.Name = "radioButtonGrad";
            this.radioButtonGrad.Size = new System.Drawing.Size(258, 24);
            this.radioButtonGrad.TabIndex = 34;
            this.radioButtonGrad.TabStop = true;
            this.radioButtonGrad.Text = "Трудоустройство выпускников";
            this.radioButtonGrad.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpdate.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(368, 355);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(305, 74);
            this.btnUpdate.TabIndex = 67;
            this.btnUpdate.Text = "Обновить информацию о вакансиях";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // StudStatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 528);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudStatForm";
            this.Text = "Рейтинг. Студенты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudStatForm_FormClosing);
            this.Load += new System.EventHandler(this.StudStatForm_Load);
            this.gbAbit.ResumeLayout(false);
            this.gbAbit.PerformLayout();
            this.gbDraphX.ResumeLayout(false);
            this.gbDraphX.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chPage1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gbActiv.ResumeLayout(false);
            this.gbActiv.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGraph)).EndInit();
            this.gbAfter.ResumeLayout(false);
            this.gbAfter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbAbit;
        private System.Windows.Forms.RadioButton radioButtonCount;
        private System.Windows.Forms.RadioButton radioButtonEx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGraph1;
        private System.Windows.Forms.GroupBox gbDraphX;
        private LiveCharts.WinForms.CartesianChart chPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDegr1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbActiv;
        private System.Windows.Forms.RadioButton radioButtonInTime;
        private System.Windows.Forms.RadioButton radioButtonBefore;
        private System.Windows.Forms.Button btnGraph2;
        private System.Windows.Forms.ComboBox cmbDegr2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGraph3;
        private System.Windows.Forms.GroupBox gbAfter;
        private System.Windows.Forms.RadioButton radioButtonLB;
        private System.Windows.Forms.RadioButton radioButtonGrad;
        private System.Windows.Forms.RadioButton radioButtonCurs;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.DataGridView dataGraph;
        private LiveCharts.WinForms.PieChart chPage3;
        private System.Windows.Forms.Button btnUpdate;
    }
}