namespace Proforientir
{
    partial class RegFormCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegFormCode));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelN = new System.Windows.Forms.Label();
            this.txtPatron = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.labelF = new System.Windows.Forms.Label();
            this.labelCM = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.txtPass2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 27);
            this.label1.TabIndex = 13;
            this.label1.Text = "Регистрация пользователя";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP.Location = new System.Drawing.Point(37, 190);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(160, 22);
            this.labelP.TabIndex = 30;
            this.labelP.Text = "Введите отчество:";
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelN.Location = new System.Drawing.Point(37, 132);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(118, 22);
            this.labelN.TabIndex = 29;
            this.labelN.Text = "Введите имя:";
            // 
            // txtPatron
            // 
            this.txtPatron.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatron.Location = new System.Drawing.Point(41, 215);
            this.txtPatron.Name = "txtPatron";
            this.txtPatron.Size = new System.Drawing.Size(356, 30);
            this.txtPatron.TabIndex = 28;
            this.txtPatron.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatron_KeyPress);
            // 
            // txtFname
            // 
            this.txtFname.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.Location = new System.Drawing.Point(41, 157);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(356, 30);
            this.txtFname.TabIndex = 27;
            this.txtFname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFname_KeyPress);
            // 
            // txtLname
            // 
            this.txtLname.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLname.Location = new System.Drawing.Point(41, 99);
            this.txtLname.Name = "txtLname";
            this.txtLname.Size = new System.Drawing.Size(356, 30);
            this.txtLname.TabIndex = 26;
            this.txtLname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLname_KeyPress);
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelF.Location = new System.Drawing.Point(37, 74);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(164, 22);
            this.labelF.TabIndex = 25;
            this.labelF.Text = "Введите фамилию:";
            // 
            // labelCM
            // 
            this.labelCM.AutoSize = true;
            this.labelCM.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCM.Location = new System.Drawing.Point(37, 264);
            this.labelCM.Name = "labelCM";
            this.labelCM.Size = new System.Drawing.Size(230, 22);
            this.labelCM.TabIndex = 31;
            this.labelCM.Text = "Введите код из сообщения:";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(76, 289);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(303, 30);
            this.txtCode.TabIndex = 32;
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // btnReg
            // 
            this.btnReg.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReg.Location = new System.Drawing.Point(76, 448);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(303, 33);
            this.btnReg.TabIndex = 33;
            this.btnReg.Text = "Проверить приглашение";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 22);
            this.label2.TabIndex = 34;
            this.label2.Text = "Введите пароль:";
            // 
            // txtPass1
            // 
            this.txtPass1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass1.Location = new System.Drawing.Point(76, 347);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(303, 30);
            this.txtPass1.TabIndex = 35;
            this.txtPass1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass1_KeyPress);
            // 
            // txtPass2
            // 
            this.txtPass2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass2.Location = new System.Drawing.Point(76, 405);
            this.txtPass2.Name = "txtPass2";
            this.txtPass2.PasswordChar = '*';
            this.txtPass2.Size = new System.Drawing.Size(303, 30);
            this.txtPass2.TabIndex = 36;
            this.txtPass2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPass2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 22);
            this.label3.TabIndex = 37;
            this.label3.Text = "Повторите пароль:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(76, 289);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(303, 30);
            this.txtLogin.TabIndex = 38;
            this.txtLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLogin_KeyPress);
            // 
            // RegFormCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 493);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPass2);
            this.Controls.Add(this.txtPass1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelCM);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelN);
            this.Controls.Add(this.txtPatron);
            this.Controls.Add(this.txtFname);
            this.Controls.Add(this.txtLname);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegFormCode";
            this.Text = "Регистрация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegFormCode_FormClosing);
            this.Load += new System.EventHandler(this.RegFormCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.TextBox txtPatron;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelCM;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.TextBox txtPass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogin;
    }
}