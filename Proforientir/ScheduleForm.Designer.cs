namespace Proforientir
{
    partial class ScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleForm));
            this.btnBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnMaterials = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvParts = new System.Windows.Forms.DataGridView();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.btnDelPart = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.labelSomeEv = new System.Windows.Forms.Label();
            this.labelSEv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 27);
            this.label1.TabIndex = 14;
            this.label1.Text = "План проведения мероприятий";
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(12, 126);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.Size = new System.Drawing.Size(599, 266);
            this.dgvEvents.TabIndex = 15;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            this.dgvEvents.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellDoubleClick);
            this.dgvEvents.SelectionChanged += new System.EventHandler(this.dgvEvents_SelectionChanged);
            // 
            // btnNew
            // 
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNew.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(12, 398);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(121, 54);
            this.btnNew.TabIndex = 17;
            this.btnNew.Text = "Добавить новое";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnMaterials
            // 
            this.btnMaterials.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMaterials.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterials.Location = new System.Drawing.Point(139, 398);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(121, 54);
            this.btnMaterials.TabIndex = 18;
            this.btnMaterials.Text = "Материалы мероприятия";
            this.btnMaterials.UseVisualStyleBackColor = true;
            this.btnMaterials.Click += new System.EventHandler(this.btnMaterials_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Расписание на учебный год:";
            // 
            // cmbDate
            // 
            this.cmbDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDate.FormattingEnabled = true;
            this.cmbDate.Location = new System.Drawing.Point(249, 88);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(362, 29);
            this.cmbDate.TabIndex = 21;
            this.cmbDate.SelectedIndexChanged += new System.EventHandler(this.cmbDate_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(740, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 22;
            this.label3.Text = "Участники";
            // 
            // dgvParts
            // 
            this.dgvParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParts.Location = new System.Drawing.Point(617, 126);
            this.dgvParts.Name = "dgvParts";
            this.dgvParts.ReadOnly = true;
            this.dgvParts.Size = new System.Drawing.Size(332, 266);
            this.dgvParts.TabIndex = 23;
            this.dgvParts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParts_CellClick);
            // 
            // btnAddPart
            // 
            this.btnAddPart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddPart.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPart.Location = new System.Drawing.Point(617, 398);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(108, 54);
            this.btnAddPart.TabIndex = 24;
            this.btnAddPart.Text = "Добавить нового";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click);
            // 
            // btnDelPart
            // 
            this.btnDelPart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDelPart.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelPart.Location = new System.Drawing.Point(731, 398);
            this.btnDelPart.Name = "btnDelPart";
            this.btnDelPart.Size = new System.Drawing.Size(108, 54);
            this.btnDelPart.TabIndex = 25;
            this.btnDelPart.Text = "Удалить участника";
            this.btnDelPart.UseVisualStyleBackColor = true;
            this.btnDelPart.Click += new System.EventHandler(this.btnDelPart_Click);
            // 
            // btnMore
            // 
            this.btnMore.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnMore.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMore.Location = new System.Drawing.Point(849, 398);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(104, 54);
            this.btnMore.TabIndex = 26;
            this.btnMore.Text = "Подробнее";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // labelSomeEv
            // 
            this.labelSomeEv.AutoSize = true;
            this.labelSomeEv.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSomeEv.Location = new System.Drawing.Point(12, 52);
            this.labelSomeEv.Name = "labelSomeEv";
            this.labelSomeEv.Size = new System.Drawing.Size(0, 22);
            this.labelSomeEv.TabIndex = 27;
            // 
            // labelSEv
            // 
            this.labelSEv.AutoSize = true;
            this.labelSEv.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSEv.Location = new System.Drawing.Point(18, 52);
            this.labelSEv.Name = "labelSEv";
            this.labelSEv.Size = new System.Drawing.Size(105, 22);
            this.labelSEv.TabIndex = 28;
            this.labelSEv.Text = "Расписание ";
            this.labelSEv.Visible = false;
            // 
            // ScheduleForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 464);
            this.Controls.Add(this.labelSEv);
            this.Controls.Add(this.labelSomeEv);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.btnDelPart);
            this.Controls.Add(this.btnAddPart);
            this.Controls.Add(this.dgvParts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMaterials);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleForm";
            this.Text = "План проведения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScheduleForm_FormClosing);
            this.Load += new System.EventHandler(this.ScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.Button btnDelPart;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Label labelSomeEv;
        public System.Windows.Forms.DataGridView dgvParts;
        public System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Label labelSEv;
    }
}