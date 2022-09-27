namespace Proforientir
{
    partial class AddStudForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOrdYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEx = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.btnAddStud = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbDegr = new System.Windows.Forms.ComboBox();
            this.dgvOrds = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAbit = new System.Windows.Forms.TextBox();
            this.dgvAbit = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrds)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 17;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "Добавление информации";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(906, 22);
            this.label3.TabIndex = 28;
            this.label3.Text = "Можете использовать приказы на официальном сайте МАИ или список абитуриентов для " +
    "занесеня информации.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 29;
            this.label2.Text = "Выберите:";
            // 
            // cmbOrdYear
            // 
            this.cmbOrdYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdYear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrdYear.FormattingEnabled = true;
            this.cmbOrdYear.Location = new System.Drawing.Point(110, 106);
            this.cmbOrdYear.Name = "cmbOrdYear";
            this.cmbOrdYear.Size = new System.Drawing.Size(490, 29);
            this.cmbOrdYear.TabIndex = 30;
            this.cmbOrdYear.SelectedIndexChanged += new System.EventHandler(this.cmbOrdYear_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "Приказы:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 18);
            this.label5.TabIndex = 33;
            this.label5.Text = "(Щелкните, чтобы открыть приказ в браузере)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(408, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 22);
            this.label6.TabIndex = 35;
            this.label6.Text = "Поля для ввода данных";
            // 
            // txtLN
            // 
            this.txtLN.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLN.Location = new System.Drawing.Point(12, 407);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(313, 30);
            this.txtLN.TabIndex = 45;
            this.txtLN.TextChanged += new System.EventHandler(this.txtLN_TextChanged);
            this.txtLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLN_KeyPress);
            // 
            // txtFN
            // 
            this.txtFN.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFN.Location = new System.Drawing.Point(331, 407);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(278, 30);
            this.txtFN.TabIndex = 46;
            this.txtFN.TextChanged += new System.EventHandler(this.txtFN_TextChanged);
            this.txtFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFN_KeyPress);
            // 
            // txtP
            // 
            this.txtP.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP.Location = new System.Drawing.Point(616, 407);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(364, 30);
            this.txtP.TabIndex = 47;
            this.txtP.TextChanged += new System.EventHandler(this.txtP_TextChanged);
            this.txtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 48;
            this.label7.Text = "Фамилия:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(327, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 22);
            this.label8.TabIndex = 49;
            this.label8.Text = "Имя:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(615, 382);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 22);
            this.label9.TabIndex = 50;
            this.label9.Text = "Отчество:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 446);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 22);
            this.label10.TabIndex = 51;
            this.label10.Text = "Средний балл:";
            // 
            // txtEx
            // 
            this.txtEx.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEx.Location = new System.Drawing.Point(144, 443);
            this.txtEx.Name = "txtEx";
            this.txtEx.Size = new System.Drawing.Size(177, 30);
            this.txtEx.TabIndex = 52;
            this.txtEx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEx_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(327, 446);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 22);
            this.label11.TabIndex = 53;
            this.label11.Text = "Год поступления:";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(481, 443);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(128, 30);
            this.txtYear.TabIndex = 54;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // btnAddStud
            // 
            this.btnAddStud.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddStud.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStud.Location = new System.Drawing.Point(762, 505);
            this.btnAddStud.Name = "btnAddStud";
            this.btnAddStud.Size = new System.Drawing.Size(218, 37);
            this.btnAddStud.TabIndex = 55;
            this.btnAddStud.Text = "Добавить";
            this.btnAddStud.UseVisualStyleBackColor = true;
            this.btnAddStud.Click += new System.EventHandler(this.btnAddStud_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(8, 483);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 22);
            this.label12.TabIndex = 56;
            this.label12.Text = "Ученая степень:";
            // 
            // cmbDegr
            // 
            this.cmbDegr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr.FormattingEnabled = true;
            this.cmbDegr.Location = new System.Drawing.Point(153, 482);
            this.cmbDegr.Name = "cmbDegr";
            this.cmbDegr.Size = new System.Drawing.Size(447, 29);
            this.cmbDegr.TabIndex = 57;
            this.cmbDegr.SelectedIndexChanged += new System.EventHandler(this.cmbDegr_SelectedIndexChanged);
            // 
            // dgvOrds
            // 
            this.dgvOrds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrds.Location = new System.Drawing.Point(12, 196);
            this.dgvOrds.Name = "dgvOrds";
            this.dgvOrds.ReadOnly = true;
            this.dgvOrds.Size = new System.Drawing.Size(588, 157);
            this.dgvOrds.TabIndex = 58;
            this.dgvOrds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrds_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtAbit);
            this.groupBox1.Controls.Add(this.dgvAbit);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(606, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 250);
            this.groupBox1.TabIndex = 59;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Абитуриенты";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(323, 36);
            this.label13.TabIndex = 60;
            this.label13.Text = "Начните вводить фамилию, имя или отчество \r\nдля поиска.";
            // 
            // btnSearch
            // 
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSearch.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(335, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(33, 33);
            this.btnSearch.TabIndex = 60;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAbit
            // 
            this.txtAbit.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbit.Location = new System.Drawing.Point(6, 59);
            this.txtAbit.Name = "txtAbit";
            this.txtAbit.Size = new System.Drawing.Size(323, 30);
            this.txtAbit.TabIndex = 60;
            // 
            // dgvAbit
            // 
            this.dgvAbit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbit.Location = new System.Drawing.Point(6, 95);
            this.dgvAbit.Name = "dgvAbit";
            this.dgvAbit.ReadOnly = true;
            this.dgvAbit.Size = new System.Drawing.Size(362, 149);
            this.dgvAbit.TabIndex = 60;
            this.dgvAbit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAbit_CellClick);
            // 
            // AddStudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvOrds);
            this.Controls.Add(this.cmbDegr);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAddStud);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtFN);
            this.Controls.Add(this.txtLN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbOrdYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStudForm";
            this.Text = "Новый студент";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddStudForm_FormClosing);
            this.Load += new System.EventHandler(this.AddStudForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrds)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbOrdYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Button btnAddStud;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbDegr;
        public System.Windows.Forms.DataGridView dgvOrds;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtAbit;
        public System.Windows.Forms.DataGridView dgvAbit;
        private System.Windows.Forms.Label label13;
    }
}