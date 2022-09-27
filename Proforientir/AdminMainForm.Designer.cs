namespace Proforientir
{
    partial class AdminMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminMainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiKafedra = new System.Windows.Forms.ToolStripMenuItem();
            this.сотрудникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.студентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выпускникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.всеПользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мероприятияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переченьВсехToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.планПроведенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.организаторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.профориентацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.результатыАнкетированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статистикаОСтудентахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblFIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTechSup = new System.Windows.Forms.Button();
            this.btnChen = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Lucida Fax", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKafedra,
            this.мероприятияToolStripMenuItem,
            this.профориентацияToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiKafedra
            // 
            this.tsmiKafedra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сотрудникиToolStripMenuItem,
            this.студентыToolStripMenuItem,
            this.выпускникиToolStripMenuItem,
            this.всеПользователиToolStripMenuItem});
            this.tsmiKafedra.Name = "tsmiKafedra";
            this.tsmiKafedra.Size = new System.Drawing.Size(115, 31);
            this.tsmiKafedra.Text = "Кафедра";
            // 
            // сотрудникиToolStripMenuItem
            // 
            this.сотрудникиToolStripMenuItem.Name = "сотрудникиToolStripMenuItem";
            this.сотрудникиToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.сотрудникиToolStripMenuItem.Text = "Сотрудники";
            this.сотрудникиToolStripMenuItem.Click += new System.EventHandler(this.сотрудникиToolStripMenuItem_Click);
            // 
            // студентыToolStripMenuItem
            // 
            this.студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            this.студентыToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.студентыToolStripMenuItem.Text = "Студенты";
            this.студентыToolStripMenuItem.Click += new System.EventHandler(this.студентыToolStripMenuItem_Click);
            // 
            // выпускникиToolStripMenuItem
            // 
            this.выпускникиToolStripMenuItem.Name = "выпускникиToolStripMenuItem";
            this.выпускникиToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.выпускникиToolStripMenuItem.Text = "Выпускники";
            this.выпускникиToolStripMenuItem.Click += new System.EventHandler(this.выпускникиToolStripMenuItem_Click);
            // 
            // всеПользователиToolStripMenuItem
            // 
            this.всеПользователиToolStripMenuItem.Name = "всеПользователиToolStripMenuItem";
            this.всеПользователиToolStripMenuItem.Size = new System.Drawing.Size(268, 32);
            this.всеПользователиToolStripMenuItem.Text = "Все пользователи";
            this.всеПользователиToolStripMenuItem.Click += new System.EventHandler(this.всеПользователиToolStripMenuItem_Click);
            // 
            // мероприятияToolStripMenuItem
            // 
            this.мероприятияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переченьВсехToolStripMenuItem,
            this.планПроведенияToolStripMenuItem,
            this.организаторыToolStripMenuItem});
            this.мероприятияToolStripMenuItem.Name = "мероприятияToolStripMenuItem";
            this.мероприятияToolStripMenuItem.Size = new System.Drawing.Size(158, 31);
            this.мероприятияToolStripMenuItem.Text = "Мероприятия";
            // 
            // переченьВсехToolStripMenuItem
            // 
            this.переченьВсехToolStripMenuItem.Name = "переченьВсехToolStripMenuItem";
            this.переченьВсехToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.переченьВсехToolStripMenuItem.Text = "Перечень всех";
            this.переченьВсехToolStripMenuItem.Click += new System.EventHandler(this.переченьВсехToolStripMenuItem_Click);
            // 
            // планПроведенияToolStripMenuItem
            // 
            this.планПроведенияToolStripMenuItem.Name = "планПроведенияToolStripMenuItem";
            this.планПроведенияToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.планПроведенияToolStripMenuItem.Text = "План проведения";
            this.планПроведенияToolStripMenuItem.Click += new System.EventHandler(this.планПроведенияToolStripMenuItem_Click);
            // 
            // организаторыToolStripMenuItem
            // 
            this.организаторыToolStripMenuItem.Name = "организаторыToolStripMenuItem";
            this.организаторыToolStripMenuItem.Size = new System.Drawing.Size(261, 32);
            this.организаторыToolStripMenuItem.Text = "Организаторы";
            this.организаторыToolStripMenuItem.Click += new System.EventHandler(this.организаторыToolStripMenuItem_Click);
            // 
            // профориентацияToolStripMenuItem
            // 
            this.профориентацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.результатыАнкетированияToolStripMenuItem,
            this.статистикаОСтудентахToolStripMenuItem});
            this.профориентацияToolStripMenuItem.Name = "профориентацияToolStripMenuItem";
            this.профориентацияToolStripMenuItem.Size = new System.Drawing.Size(197, 31);
            this.профориентацияToolStripMenuItem.Text = "Профориентация";
            // 
            // результатыАнкетированияToolStripMenuItem
            // 
            this.результатыАнкетированияToolStripMenuItem.Name = "результатыАнкетированияToolStripMenuItem";
            this.результатыАнкетированияToolStripMenuItem.Size = new System.Drawing.Size(361, 32);
            this.результатыАнкетированияToolStripMenuItem.Text = "Результаты анкетирования";
            this.результатыАнкетированияToolStripMenuItem.Click += new System.EventHandler(this.результатыАнкетированияToolStripMenuItem_Click);
            // 
            // статистикаОСтудентахToolStripMenuItem
            // 
            this.статистикаОСтудентахToolStripMenuItem.Name = "статистикаОСтудентахToolStripMenuItem";
            this.статистикаОСтудентахToolStripMenuItem.Size = new System.Drawing.Size(361, 32);
            this.статистикаОСтудентахToolStripMenuItem.Text = "Статистика о студентах";
            this.статистикаОСтудентахToolStripMenuItem.Click += new System.EventHandler(this.статистикаОСтудентахToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(88, 31);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // lblFIO
            // 
            this.lblFIO.AutoSize = true;
            this.lblFIO.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFIO.Location = new System.Drawing.Point(12, 53);
            this.lblFIO.Name = "lblFIO";
            this.lblFIO.Size = new System.Drawing.Size(53, 17);
            this.lblFIO.TabIndex = 1;
            this.lblFIO.Text = "lable1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Будущие мероприятия кафедры:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(513, 227);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "(Выберите, чтобы узнать подробности)";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(531, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 48);
            this.button1.TabIndex = 5;
            this.button1.Text = "Подробнее";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(127, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Заметили ошибку в работе приложения? Обращайтесь в техподдержку: ";
            // 
            // btnTechSup
            // 
            this.btnTechSup.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTechSup.Font = new System.Drawing.Font("Lucida Fax", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTechSup.Location = new System.Drawing.Point(531, 380);
            this.btnTechSup.Name = "btnTechSup";
            this.btnTechSup.Size = new System.Drawing.Size(104, 25);
            this.btnTechSup.TabIndex = 7;
            this.btnTechSup.Text = "Написать";
            this.btnTechSup.UseVisualStyleBackColor = true;
            this.btnTechSup.Click += new System.EventHandler(this.btnTechSup_Click);
            // 
            // btnChen
            // 
            this.btnChen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChen.Font = new System.Drawing.Font("Lucida Fax", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChen.Location = new System.Drawing.Point(531, 53);
            this.btnChen.Name = "btnChen";
            this.btnChen.Size = new System.Drawing.Size(104, 48);
            this.btnChen.TabIndex = 8;
            this.btnChen.Text = "Изменить учетную запись";
            this.btnChen.UseVisualStyleBackColor = true;
            this.btnChen.Click += new System.EventHandler(this.btnChen_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(647, 410);
            this.Controls.Add(this.btnChen);
            this.Controls.Add(this.btnTechSup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFIO);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminMainForm";
            this.Text = "Главное меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiKafedra;
        private System.Windows.Forms.ToolStripMenuItem сотрудникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выпускникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мероприятияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem переченьВсехToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem планПроведенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem профориентацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem результатыАнкетированияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статистикаОСтудентахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTechSup;
        private System.Windows.Forms.ToolStripMenuItem организаторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem всеПользователиToolStripMenuItem;
        private System.Windows.Forms.Button btnChen;
        public System.Windows.Forms.Label lblFIO;
    }
}