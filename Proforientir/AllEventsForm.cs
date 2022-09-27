using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proforientir
{
    public partial class AllEventsForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private ScheduleForm _scheduleForm; //Форма полного расписания;
        private string _selectedPositCat; //Выбранная категория;

        public AllEventsForm()
        {
            InitializeComponent();
        }

        public AllEventsForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _selectedPositCat = "";

            InitializeComponent();
        }

        public AllEventsForm(AuthForm authForm, AdminMainForm adminMainForm, ScheduleForm scheduleForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _selectedPositCat = "";
            _scheduleForm = scheduleForm;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
            
        }

        private void AllEventsForm_Load(object sender, EventArgs e) //Загрузка формы
        {
            if (_scheduleForm != null)
            {
                btnSched.Text = "Добавить в расписание";
            }

            labelEv.Text = "Перечень всех мероприятий:";
           
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название"; //текст в шапке
            column1.Width = 300; //ширина колонки
            column1.Name = "Event"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Категория";
            column2.Width = 170; //ширина колонки
            column2.Name = "Categ";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Организатор";
            column3.Width = 170; //ширина колонки
            column3.Name = "Org";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 40; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputAllEvent();
            OutputCmbCat();
        }

        public void OutputAllEvent() //Выводим в DataGridView новые значения
        {
            if(_selectedPositCat=="")
            {
                labelEv.Text = "Перечень всех мероприятий:";
            }
            else
            {
                int pos = _selectedPositCat.IndexOf('.') + 2;
                labelEv.Text = "Мероприятия категории '"+ _selectedPositCat.Substring(pos, _selectedPositCat.Length - pos)+"':";
            }
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_event, name_event, name_category, name_organizer, name_organization_type " +
               "FROM organization_type " +
               "JOIN organizer " +
               "ON organization_type.id_organization_type = organizer.id_organization_type " +
                "JOIN event " +
               "ON organizer.id_organizer = event.id_organizer " +
                "JOIN category " +
               "ON event.id_category = category.id_category ";

            if (_selectedPositCat != "")
            {
                sql += "WHERE event.id_category = @id";
            }

            MySqlCommand command = new MySqlCommand(sql, conn);
            if (_selectedPositCat != "")
            {
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _selectedPositCat.Substring(0, _selectedPositCat.IndexOf('.'));
            }

            MySqlDataReader events = command.ExecuteReader();


            while (events.Read())
            {
                dataGridView1.Rows.Add(events[0].ToString(), events[1].ToString(), events[2].ToString(), events[3].ToString() + "\n (" + events[4].ToString()+")");
            }

            events.Close();
            conn.Close();
        }

        public void OutputCmbCat() //Вывод категорий 
        {
            cmbCat.Items.Add("");
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_category, name_category " +
                "FROM category ";
            
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbCat.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void AllEventsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_scheduleForm != null)
            {
                _scheduleForm.Show(); //Переход на форму расписаня
            }
            else
            {
                _adminMainForm.Show(); //Переход на форму админа

            }
        }

        private void btnNew_Click(object sender, EventArgs e) //Добавить новое
        {
            this.Enabled = false;
            AddEventForm addEventForm = new AddEventForm(_authForm, _adminMainForm, this) { Visible = true }; //Переход к форме добавления нового мероприятия в перечень
        }

        private void btnTop_Click(object sender, EventArgs e) //Рейтинг
        {
            this.Hide();
            EventStatForm eventStatForm = new EventStatForm(_authForm, _adminMainForm, this, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value)) { Visible = true }; //Переход к форме рейтинга мероприятия
        }

        private void btnSched_Click(object sender, EventArgs e) //Расписание конкретного мероприятия
        {
            if (_scheduleForm != null)
            {
                this.Hide();
                Event ev = new Event(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                   Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value),
                   Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value));

                AddEntryShedForm addEntryShedForm = new AddEntryShedForm(_authForm, _adminMainForm, _scheduleForm, this, ev) { Visible = true }; //Переход на форму добавления в расписание
            }
            else
            {
                this.Hide();
                ScheduleForm scheduleForm = new ScheduleForm(_authForm, _adminMainForm, this, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value)) { Visible = true }; //Переход на форму расписания конкретного мероприятия

            }

        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositCat = cmbCat.SelectedItem.ToString();
            dataGridView1.Rows.Clear();
            OutputAllEvent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }
    }
}
