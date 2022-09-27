namespace Proforientir
{
    partial class AddCatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCatForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelF = new System.Windows.Forms.Label();
            this.lbCat = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.btnAddCat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 27);
            this.label1.TabIndex = 15;
            this.label1.Text = "Категории мероприятий";
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
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelF.Location = new System.Drawing.Point(12, 78);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(128, 22);
            this.labelF.TabIndex = 28;
            this.labelF.Text = "Все категории:";
            // 
            // lbCat
            // 
            this.lbCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCat.FormattingEnabled = true;
            this.lbCat.ItemHeight = 20;
            this.lbCat.Location = new System.Drawing.Point(12, 103);
            this.lbCat.Name = "lbCat";
            this.lbCat.Size = new System.Drawing.Size(410, 164);
            this.lbCat.TabIndex = 29;
            this.lbCat.SelectedIndexChanged += new System.EventHandler(this.lbCat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 312);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 22);
            this.label2.TabIndex = 30;
            this.label2.Text = "Новая категория:";
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(162, 309);
            this.txtCName.Name = "txtCName";
            this.txtCName.Size = new System.Drawing.Size(260, 30);
            this.txtCName.TabIndex = 44;
            // 
            // btnAddCat
            // 
            this.btnAddCat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddCat.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCat.Location = new System.Drawing.Point(297, 345);
            this.btnAddCat.Name = "btnAddCat";
            this.btnAddCat.Size = new System.Drawing.Size(125, 37);
            this.btnAddCat.TabIndex = 45;
            this.btnAddCat.Text = "Добавить";
            this.btnAddCat.UseVisualStyleBackColor = true;
            this.btnAddCat.Click += new System.EventHandler(this.btnAddCat_Click);
            // 
            // AddCatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 394);
            this.Controls.Add(this.btnAddCat);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCat);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCatForm";
            this.Text = "Категории";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddCatForm_FormClosing);
            this.Load += new System.EventHandler(this.AddCatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.ListBox lbCat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Button btnAddCat;
    }
}