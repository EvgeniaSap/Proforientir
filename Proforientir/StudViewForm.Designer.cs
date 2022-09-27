namespace Proforientir
{
    partial class StudViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudViewForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDegr = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvStud = new System.Windows.Forms.DataGridView();
            this.labelStud = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnActiv = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.txtFIO = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStud)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 16;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "Информация о студентах";
            // 
            // cmbDegr
            // 
            this.cmbDegr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr.FormattingEnabled = true;
            this.cmbDegr.Location = new System.Drawing.Point(288, 69);
            this.cmbDegr.Name = "cmbDegr";
            this.cmbDegr.Size = new System.Drawing.Size(361, 29);
            this.cmbDegr.TabIndex = 26;
            this.cmbDegr.SelectedIndexChanged += new System.EventHandler(this.cmbDegr_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Можете выбрать ученую степень:";
            // 
            // dgvStud
            // 
            this.dgvStud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStud.Location = new System.Drawing.Point(12, 179);
            this.dgvStud.Name = "dgvStud";
            this.dgvStud.ReadOnly = true;
            this.dgvStud.Size = new System.Drawing.Size(637, 185);
            this.dgvStud.TabIndex = 28;
            this.dgvStud.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStud_CellClick);
            // 
            // labelStud
            // 
            this.labelStud.AutoSize = true;
            this.labelStud.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStud.Location = new System.Drawing.Point(8, 154);
            this.labelStud.Name = "labelStud";
            this.labelStud.Size = new System.Drawing.Size(123, 22);
            this.labelStud.TabIndex = 29;
            this.labelStud.Text = "Все студенты:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpdate.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(12, 370);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(141, 58);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "Добавить нового";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnActiv
            // 
            this.btnActiv.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnActiv.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiv.Location = new System.Drawing.Point(508, 370);
            this.btnActiv.Name = "btnActiv";
            this.btnActiv.Size = new System.Drawing.Size(141, 58);
            this.btnActiv.TabIndex = 31;
            this.btnActiv.Text = "Активность студента";
            this.btnActiv.UseVisualStyleBackColor = true;
            this.btnActiv.Click += new System.EventHandler(this.btnActiv_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnUpd.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpd.Location = new System.Drawing.Point(361, 370);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(141, 58);
            this.btnUpd.TabIndex = 32;
            this.btnUpd.Text = "Изменить";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // txtFIO
            // 
            this.txtFIO.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFIO.Location = new System.Drawing.Point(12, 122);
            this.txtFIO.Name = "txtFIO";
            this.txtFIO.Size = new System.Drawing.Size(490, 30);
            this.txtFIO.TabIndex = 33;
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(508, 121);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(141, 31);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Поиск";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "Поиск по ФИО:";
            // 
            // StudViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFIO);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnActiv);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.labelStud);
            this.Controls.Add(this.dgvStud);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDegr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StudViewForm";
            this.Text = "Студенты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudViewForm_FormClosing);
            this.Load += new System.EventHandler(this.StudViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDegr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelStud;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnActiv;
        private System.Windows.Forms.Button btnUpd;
        public System.Windows.Forms.DataGridView dgvStud;
        private System.Windows.Forms.TextBox txtFIO;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
    }
}