namespace Proforientir
{
    partial class UserMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiKafedra = new System.Windows.Forms.ToolStripMenuItem();
            this.всеМоиМероприятияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.общееРасписаниеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTechSup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.учетнаяЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKafedra,
            this.учетнаяЗаписьToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(658, 35);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiKafedra
            // 
            this.tsmiKafedra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.всеМоиМероприятияToolStripMenuItem,
            this.общееРасписаниеToolStripMenuItem});
            this.tsmiKafedra.Name = "tsmiKafedra";
            this.tsmiKafedra.Size = new System.Drawing.Size(158, 31);
            this.tsmiKafedra.Text = "Мероприятия";
            // 
            // всеМоиМероприятияToolStripMenuItem
            // 
            this.всеМоиМероприятияToolStripMenuItem.Name = "всеМоиМероприятияToolStripMenuItem";
            this.всеМоиМероприятияToolStripMenuItem.Size = new System.Drawing.Size(307, 32);
            this.всеМоиМероприятияToolStripMenuItem.Text = "Все мои мероприятия";
            this.всеМоиМероприятияToolStripMenuItem.Click += new System.EventHandler(this.всеМоиМероприятияToolStripMenuItem_Click);
            // 
            // общееРасписаниеToolStripMenuItem
            // 
            this.общееРасписаниеToolStripMenuItem.Name = "общееРасписаниеToolStripMenuItem";
            this.общееРасписаниеToolStripMenuItem.Size = new System.Drawing.Size(307, 32);
            this.общееРасписаниеToolStripMenuItem.Text = "Общее расписание";
            this.общееРасписаниеToolStripMenuItem.Click += new System.EventHandler(this.общееРасписаниеToolStripMenuItem_Click);
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFIO.Location = new System.Drawing.Point(12, 66);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(85, 27);
            this.lblFIO.TabIndex = 7;
            this.lblFIO.Text = "lable1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "Мои будущие мероприятия:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "(Выберите, чтобы узнать подробности)";
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(12, 153);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.ReadOnly = true;
            this.dgvEvents.Size = new System.Drawing.Size(523, 231);
            this.dgvEvents.TabIndex = 10;
            this.dgvEvents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellClick);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(541, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 48);
            this.button1.TabIndex = 11;
            this.button1.Text = "Подробнее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTechSup
            // 
            this.btnTechSup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTechSup.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechSup.Location = new System.Drawing.Point(541, 395);
            this.btnTechSup.Name = "btnTechSup";
            this.btnTechSup.Size = new System.Drawing.Size(104, 25);
            this.btnTechSup.TabIndex = 13;
            this.btnTechSup.Text = "Написать";
            this.btnTechSup.UseVisualStyleBackColor = true;
            this.btnTechSup.Click += new System.EventHandler(this.btnTechSup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(137, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Заметили ошибку в работе приложения? Обращайтесь в техподдержку: ";
            // 
            // учетнаяЗаписьToolStripMenuItem
            // 
            this.учетнаяЗаписьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьДанныеToolStripMenuItem});
            this.учетнаяЗаписьToolStripMenuItem.Name = "учетнаяЗаписьToolStripMenuItem";
            this.учетнаяЗаписьToolStripMenuItem.Size = new System.Drawing.Size(182, 31);
            this.учетнаяЗаписьToolStripMenuItem.Text = "Учетная запись";
            // 
            // изменитьДанныеToolStripMenuItem
            // 
            this.изменитьДанныеToolStripMenuItem.Name = "изменитьДанныеToolStripMenuItem";
            this.изменитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(265, 32);
            this.изменитьДанныеToolStripMenuItem.Text = "Изменить данные";
            this.изменитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.изменитьДанныеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(88, 31);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 430);
            this.Controls.Add(this.btnTechSup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserMainForm";
            this.Text = "Личный кабинет";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserMainForm_FormClosing);
            this.Load += new System.EventHandler(this.UserMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiKafedra;
        private System.Windows.Forms.ToolStripMenuItem всеМоиМероприятияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem общееРасписаниеToolStripMenuItem;
        public System.Windows.Forms.Label lblFIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTechSup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem учетнаяЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
    }
}