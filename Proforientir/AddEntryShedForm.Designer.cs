namespace Proforientir
{
    partial class AddEntryShedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEntryShedForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEv = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbH = new System.Windows.Forms.ComboBox();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnNewEntry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbM = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 27);
            this.label1.TabIndex = 16;
            this.label1.Text = "Добавление записи в расписание";
            // 
            // labelEv
            // 
            this.labelEv.AutoSize = true;
            this.labelEv.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEv.Location = new System.Drawing.Point(8, 77);
            this.labelEv.Name = "labelEv";
            this.labelEv.Size = new System.Drawing.Size(208, 22);
            this.labelEv.TabIndex = 21;
            this.labelEv.Text = "Выбранное мероприятие:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Выберите дату проведения:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(325, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "Выберите время:";
            // 
            // cmbH
            // 
            this.cmbH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbH.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbH.FormattingEnabled = true;
            this.cmbH.Location = new System.Drawing.Point(296, 206);
            this.cmbH.Name = "cmbH";
            this.cmbH.Size = new System.Drawing.Size(85, 29);
            this.cmbH.TabIndex = 38;
            this.cmbH.SelectedIndexChanged += new System.EventHandler(this.cmbH_SelectedIndexChanged);
            // 
            // mCalendar
            // 
            this.mCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mCalendar.Location = new System.Drawing.Point(31, 206);
            this.mCalendar.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.mCalendar.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 39;
            this.mCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateSelected);
            // 
            // btnNewEntry
            // 
            this.btnNewEntry.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNewEntry.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEntry.Location = new System.Drawing.Point(89, 380);
            this.btnNewEntry.Name = "btnNewEntry";
            this.btnNewEntry.Size = new System.Drawing.Size(353, 48);
            this.btnNewEntry.TabIndex = 40;
            this.btnNewEntry.Text = "Добавить в расписание";
            this.btnNewEntry.UseVisualStyleBackColor = true;
            this.btnNewEntry.Click += new System.EventHandler(this.btnNewEntry_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 22);
            this.label3.TabIndex = 41;
            this.label3.Text = ":";
            // 
            // cmbM
            // 
            this.cmbM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbM.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbM.FormattingEnabled = true;
            this.cmbM.Location = new System.Drawing.Point(409, 206);
            this.cmbM.Name = "cmbM";
            this.cmbM.Size = new System.Drawing.Size(85, 29);
            this.cmbM.TabIndex = 42;
            this.cmbM.SelectedIndexChanged += new System.EventHandler(this.cmbM_SelectedIndexChanged);
            // 
            // AddEntryShedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 440);
            this.Controls.Add(this.cmbM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnNewEntry);
            this.Controls.Add(this.mCalendar);
            this.Controls.Add(this.cmbH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEntryShedForm";
            this.Text = "Новая запись в плане проведения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEntryShedForm_FormClosing);
            this.Load += new System.EventHandler(this.AddEntryShedForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox cmbH;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.Button btnNewEntry;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox cmbM;
    }
}