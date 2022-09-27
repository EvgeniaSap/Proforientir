namespace Proforientir
{
    partial class EditStudForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditStudForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.cmbDegr = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEx = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtFN = new System.Windows.Forms.TextBox();
            this.txtLN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.btnAddStud = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnd = new System.Windows.Forms.TextBox();
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
            // cmbDegr
            // 
            this.cmbDegr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegr.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDegr.FormattingEnabled = true;
            this.cmbDegr.Location = new System.Drawing.Point(309, 88);
            this.cmbDegr.Name = "cmbDegr";
            this.cmbDegr.Size = new System.Drawing.Size(218, 29);
            this.cmbDegr.TabIndex = 70;
            this.cmbDegr.SelectedIndexChanged += new System.EventHandler(this.cmbDegr_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(305, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 22);
            this.label12.TabIndex = 69;
            this.label12.Text = "Ученая степень:";
            // 
            // txtYear
            // 
            this.txtYear.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYear.Location = new System.Drawing.Point(457, 159);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(71, 30);
            this.txtYear.TabIndex = 68;
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(303, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 22);
            this.label11.TabIndex = 67;
            this.label11.Text = "Год поступления:";
            // 
            // txtEx
            // 
            this.txtEx.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEx.Location = new System.Drawing.Point(438, 123);
            this.txtEx.Name = "txtEx";
            this.txtEx.Size = new System.Drawing.Size(90, 30);
            this.txtEx.TabIndex = 66;
            this.txtEx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEx_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(305, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 22);
            this.label10.TabIndex = 65;
            this.label10.Text = "Средний балл:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 22);
            this.label9.TabIndex = 64;
            this.label9.Text = "Отчество:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 22);
            this.label8.TabIndex = 63;
            this.label8.Text = "Имя:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 22);
            this.label7.TabIndex = 62;
            this.label7.Text = "Фамилия:";
            // 
            // txtP
            // 
            this.txtP.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtP.Location = new System.Drawing.Point(16, 206);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(218, 30);
            this.txtP.TabIndex = 61;
            this.txtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            // 
            // txtFN
            // 
            this.txtFN.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFN.Location = new System.Drawing.Point(16, 148);
            this.txtFN.Name = "txtFN";
            this.txtFN.Size = new System.Drawing.Size(218, 30);
            this.txtFN.TabIndex = 60;
            this.txtFN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFN_KeyPress);
            // 
            // txtLN
            // 
            this.txtLN.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLN.Location = new System.Drawing.Point(16, 88);
            this.txtLN.Name = "txtLN";
            this.txtLN.Size = new System.Drawing.Size(218, 30);
            this.txtLN.TabIndex = 59;
            this.txtLN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLN_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(303, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 71;
            this.label1.Text = "Год отчисления:";
            // 
            // txtDel
            // 
            this.txtDel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDel.Location = new System.Drawing.Point(450, 195);
            this.txtDel.Name = "txtDel";
            this.txtDel.Size = new System.Drawing.Size(78, 30);
            this.txtDel.TabIndex = 72;
            this.txtDel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDel_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(145, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 27);
            this.label2.TabIndex = 73;
            this.label2.Text = "Информация о студенте";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 22);
            this.label3.TabIndex = 74;
            this.label3.Text = "Почта:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.Location = new System.Drawing.Point(16, 311);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 24);
            this.checkBox1.TabIndex = 75;
            this.checkBox1.Text = "Выпускник";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtMail
            // 
            this.txtMail.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.Location = new System.Drawing.Point(16, 267);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(512, 30);
            this.txtMail.TabIndex = 76;
            // 
            // btnAddStud
            // 
            this.btnAddStud.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddStud.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStud.Location = new System.Drawing.Point(313, 337);
            this.btnAddStud.Name = "btnAddStud";
            this.btnAddStud.Size = new System.Drawing.Size(218, 37);
            this.btnAddStud.TabIndex = 77;
            this.btnAddStud.Text = "Сохранить изменения";
            this.btnAddStud.UseVisualStyleBackColor = true;
            this.btnAddStud.Click += new System.EventHandler(this.btnAddStud_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(305, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 22);
            this.label4.TabIndex = 78;
            this.label4.Text = "Год окончания:";
            // 
            // txtEnd
            // 
            this.txtEnd.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnd.Location = new System.Drawing.Point(438, 231);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size(90, 30);
            this.txtEnd.TabIndex = 79;
            // 
            // EditStudForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 387);
            this.Controls.Add(this.txtEnd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddStud);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDegr);
            this.Controls.Add(this.label12);
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
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditStudForm";
            this.Text = "Редактировать информацию";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditStudForm_FormClosing);
            this.Load += new System.EventHandler(this.EditStudForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ComboBox cmbDegr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtFN;
        private System.Windows.Forms.TextBox txtLN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Button btnAddStud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEnd;
    }
}