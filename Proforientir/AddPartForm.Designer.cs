namespace Proforientir
{
    partial class AddPartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPartForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEv = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTypeAcc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDegr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvPart = new System.Windows.Forms.DataGridView();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "Добавление участника";
            // 
            // labelEv
            // 
            this.labelEv.AutoSize = true;
            this.labelEv.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEv.Location = new System.Drawing.Point(12, 62);
            this.labelEv.Name = "labelEv";
            this.labelEv.Size = new System.Drawing.Size(125, 22);
            this.labelEv.TabIndex = 21;
            this.labelEv.Text = "Мероприятие: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Выберите тип пользователя:";
            // 
            // cmbTypeAcc
            // 
            this.cmbTypeAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeAcc.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTypeAcc.FormattingEnabled = true;
            this.cmbTypeAcc.Location = new System.Drawing.Point(258, 165);
            this.cmbTypeAcc.Name = "cmbTypeAcc";
            this.cmbTypeAcc.Size = new System.Drawing.Size(225, 29);
            this.cmbTypeAcc.TabIndex = 23;
            this.cmbTypeAcc.SelectedIndexChanged += new System.EventHandler(this.cmbTypeAcc_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Для студента можете выбрать ученую степень:";
            // 
            // cmbDegr
            // 
            this.cmbDegr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr.FormattingEnabled = true;
            this.cmbDegr.Location = new System.Drawing.Point(258, 222);
            this.cmbDegr.Name = "cmbDegr";
            this.cmbDegr.Size = new System.Drawing.Size(225, 29);
            this.cmbDegr.TabIndex = 25;
            this.cmbDegr.SelectedIndexChanged += new System.EventHandler(this.cmbDegr_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "Пользователи: ";
            // 
            // dgvPart
            // 
            this.dgvPart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPart.Location = new System.Drawing.Point(12, 272);
            this.dgvPart.Name = "dgvPart";
            this.dgvPart.ReadOnly = true;
            this.dgvPart.Size = new System.Drawing.Size(471, 185);
            this.dgvPart.TabIndex = 27;
            this.dgvPart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPart_CellClick);
            // 
            // btnAddPart
            // 
            this.btnAddPart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddPart.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPart.Location = new System.Drawing.Point(133, 463);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(240, 34);
            this.btnAddPart.TabIndex = 28;
            this.btnAddPart.Text = "Добавить";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(258, 130);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(225, 29);
            this.cmbRole.TabIndex = 29;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(117, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Выберите роль:";
            // 
            // AddPartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 509);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.dgvPart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDegr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTypeAcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelEv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPartForm";
            this.Text = "Новый участник";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPartForm_FormClosing);
            this.Load += new System.EventHandler(this.AddPartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTypeAcc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDegr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvPart;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label5;
    }
}