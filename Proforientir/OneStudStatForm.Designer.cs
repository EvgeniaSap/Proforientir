namespace Proforientir
{
    partial class OneStudStatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OneStudStatForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.gbActiv = new System.Windows.Forms.GroupBox();
            this.chbStud = new System.Windows.Forms.CheckBox();
            this.chbCurse = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chPage = new LiveCharts.WinForms.CartesianChart();
            this.btnGraph = new System.Windows.Forms.Button();
            this.gbActiv.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(209, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 27);
            this.label1.TabIndex = 18;
            this.label1.Text = "Статистика об активности";
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Lucida Fax", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(8, 66);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(129, 24);
            this.labelInfo.TabIndex = 19;
            this.labelInfo.Text = "Пользователь:";
            // 
            // gbActiv
            // 
            this.gbActiv.Controls.Add(this.chbAll);
            this.gbActiv.Controls.Add(this.chbCurse);
            this.gbActiv.Controls.Add(this.chbStud);
            this.gbActiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbActiv.Location = new System.Drawing.Point(12, 93);
            this.gbActiv.Name = "gbActiv";
            this.gbActiv.Size = new System.Drawing.Size(419, 102);
            this.gbActiv.TabIndex = 35;
            this.gbActiv.TabStop = false;
            this.gbActiv.Text = "Графики";
            // 
            // chbStud
            // 
            this.chbStud.AutoSize = true;
            this.chbStud.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbStud.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chbStud.Location = new System.Drawing.Point(3, 18);
            this.chbStud.Name = "chbStud";
            this.chbStud.Size = new System.Drawing.Size(173, 22);
            this.chbStud.TabIndex = 0;
            this.chbStud.Text = "Активность студента";
            this.chbStud.UseVisualStyleBackColor = true;
            // 
            // chbCurse
            // 
            this.chbCurse.AutoSize = true;
            this.chbCurse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbCurse.Location = new System.Drawing.Point(3, 46);
            this.chbCurse.Name = "chbCurse";
            this.chbCurse.Size = new System.Drawing.Size(415, 22);
            this.chbCurse.TabIndex = 1;
            this.chbCurse.Text = "Средняя активность студентов того же курса обучения";
            this.chbCurse.UseVisualStyleBackColor = true;
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbAll.Location = new System.Drawing.Point(3, 74);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(328, 22);
            this.chbAll.TabIndex = 2;
            this.chbAll.Text = "Средняя активность всех студентов за год";
            this.chbAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 36;
            this.label4.Text = "График:";
            // 
            // chPage
            // 
            this.chPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chPage.Location = new System.Drawing.Point(12, 247);
            this.chPage.Name = "chPage";
            this.chPage.Size = new System.Drawing.Size(660, 248);
            this.chPage.TabIndex = 39;
            this.chPage.Text = "cartesianChart1";
            // 
            // btnGraph
            // 
            this.btnGraph.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGraph.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraph.Location = new System.Drawing.Point(437, 139);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(236, 56);
            this.btnGraph.TabIndex = 61;
            this.btnGraph.Text = "Отобразить";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // OneStudStatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 507);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.chPage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbActiv);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OneStudStatForm";
            this.Text = "Статистика о студенте";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OneStudStatForm_FormClosing);
            this.Load += new System.EventHandler(this.OneStudStatForm_Load);
            this.gbActiv.ResumeLayout(false);
            this.gbActiv.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.GroupBox gbActiv;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.CheckBox chbCurse;
        private System.Windows.Forms.CheckBox chbStud;
        private System.Windows.Forms.Label label4;
        private LiveCharts.WinForms.CartesianChart chPage;
        private System.Windows.Forms.Button btnGraph;
    }
}