namespace Proforientir
{
    partial class EditGradForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditGradForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.gbGrad = new System.Windows.Forms.GroupBox();
            this.radioButtonF = new System.Windows.Forms.RadioButton();
            this.radioButtonT = new System.Windows.Forms.RadioButton();
            this.radioButtonUn = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbGrad.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(57, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "Добавление сведений о выпускнике";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(8, 76);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(90, 22);
            this.labelName.TabIndex = 28;
            this.labelName.Text = "Выпускник";
            // 
            // gbGrad
            // 
            this.gbGrad.Controls.Add(this.radioButtonUn);
            this.gbGrad.Controls.Add(this.radioButtonF);
            this.gbGrad.Controls.Add(this.radioButtonT);
            this.gbGrad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbGrad.Location = new System.Drawing.Point(12, 118);
            this.gbGrad.Name = "gbGrad";
            this.gbGrad.Size = new System.Drawing.Size(327, 119);
            this.gbGrad.TabIndex = 34;
            this.gbGrad.TabStop = false;
            this.gbGrad.Text = "Работа выпускника";
            // 
            // radioButtonF
            // 
            this.radioButtonF.AutoSize = true;
            this.radioButtonF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonF.Location = new System.Drawing.Point(6, 51);
            this.radioButtonF.Name = "radioButtonF";
            this.radioButtonF.Size = new System.Drawing.Size(190, 24);
            this.radioButtonF.TabIndex = 35;
            this.radioButtonF.TabStop = true;
            this.radioButtonF.Text = "Не по специальности";
            this.radioButtonF.UseVisualStyleBackColor = true;
            // 
            // radioButtonT
            // 
            this.radioButtonT.AutoSize = true;
            this.radioButtonT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonT.Location = new System.Drawing.Point(6, 21);
            this.radioButtonT.Name = "radioButtonT";
            this.radioButtonT.Size = new System.Drawing.Size(168, 24);
            this.radioButtonT.TabIndex = 34;
            this.radioButtonT.TabStop = true;
            this.radioButtonT.Text = "По специальности";
            this.radioButtonT.UseVisualStyleBackColor = true;
            // 
            // radioButtonUn
            // 
            this.radioButtonUn.AutoSize = true;
            this.radioButtonUn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUn.Location = new System.Drawing.Point(6, 81);
            this.radioButtonUn.Name = "radioButtonUn";
            this.radioButtonUn.Size = new System.Drawing.Size(117, 24);
            this.radioButtonUn.TabIndex = 36;
            this.radioButtonUn.TabStop = true;
            this.radioButtonUn.Text = "Нет данных";
            this.radioButtonUn.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(62, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(378, 55);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Сохранить изменения";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditGradForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 310);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbGrad);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditGradForm";
            this.Text = "Работа выпускника";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditGradForm_FormClosing);
            this.Load += new System.EventHandler(this.EditGradForm_Load);
            this.gbGrad.ResumeLayout(false);
            this.gbGrad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.GroupBox gbGrad;
        private System.Windows.Forms.RadioButton radioButtonUn;
        private System.Windows.Forms.RadioButton radioButtonF;
        private System.Windows.Forms.RadioButton radioButtonT;
        private System.Windows.Forms.Button btnSave;
    }
}