namespace Proforientir
{
    partial class AddEventForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEventForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelF = new System.Windows.Forms.Label();
            this.cmbOrg = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddOrg = new System.Windows.Forms.Button();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "Добавление нового мероприятия";
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
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelF.Location = new System.Drawing.Point(8, 95);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(203, 22);
            this.labelF.TabIndex = 27;
            this.labelF.Text = "Выберите организатора:";
            // 
            // cmbOrg
            // 
            this.cmbOrg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrg.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrg.FormattingEnabled = true;
            this.cmbOrg.Location = new System.Drawing.Point(221, 94);
            this.cmbOrg.Name = "cmbOrg";
            this.cmbOrg.Size = new System.Drawing.Size(290, 29);
            this.cmbOrg.TabIndex = 36;
            this.cmbOrg.SelectedIndexChanged += new System.EventHandler(this.cmbOrg_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Выберите категорию:";
            // 
            // cmbCat
            // 
            this.cmbCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(221, 129);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(290, 29);
            this.cmbCat.TabIndex = 38;
            this.cmbCat.SelectedIndexChanged += new System.EventHandler(this.cmbCat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(508, 44);
            this.label3.TabIndex = 39;
            this.label3.Text = "Если не нашли в перечне нужного организатора или категорю \r\nиспользуйте следующие" +
    " кнопки:";
            // 
            // btnAddOrg
            // 
            this.btnAddOrg.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddOrg.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOrg.Location = new System.Drawing.Point(12, 236);
            this.btnAddOrg.Name = "btnAddOrg";
            this.btnAddOrg.Size = new System.Drawing.Size(212, 53);
            this.btnAddOrg.TabIndex = 40;
            this.btnAddOrg.Text = "Добавить нового организатора";
            this.btnAddOrg.UseVisualStyleBackColor = true;
            this.btnAddOrg.Click += new System.EventHandler(this.btnAddOrg_Click);
            // 
            // btnAddCat
            // 
            this.btnAddCat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddCat.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCat.Location = new System.Drawing.Point(299, 236);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(212, 53);
            this.btnAddCat.TabIndex = 41;
            this.btnAddCat.Text = "Добавить новую категорию";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(325, 22);
            this.label4.TabIndex = 42;
            this.label4.Text = "Введите название нового мероприятия:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(12, 339);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(499, 30);
            this.txtName.TabIndex = 43;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddEvent.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.Location = new System.Drawing.Point(149, 382);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(212, 53);
            this.btnAddEvent.TabIndex = 44;
            this.btnAddEvent.Text = "Добавить ";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 447);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddCat);
            this.Controls.Add(this.btnAddOrg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOrg);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddEventForm";
            this.Text = "Добавление мероприятия";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEventForm_FormClosing);
            this.Load += new System.EventHandler(this.AddEventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddOrg;
        private System.Windows.Forms.Button btnAddCat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAddEvent;
        public System.Windows.Forms.ComboBox cmbOrg;
        public System.Windows.Forms.ComboBox cmbCat;
    }
}