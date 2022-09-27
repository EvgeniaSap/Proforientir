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
    public partial class UserMainForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private User _user; //Пользователь, загрузивший форму;

        public UserMainForm()
        {
            InitializeComponent();
        }

        public UserMainForm(AuthForm authForm, User user)
        {
            _authForm = authForm;
            _user = user;

            InitializeComponent();
        }

        private void всеМоиМероприятияToolStripMenuItem_Click(object sender, EventArgs e) //Все мероприятия пользователя
        {
            this.Hide();
            AccEventForm accEventForm = new AccEventForm(_authForm, this, _user.Id_account, _user) { Visible = true }; //Переход на форму отображения мероприятий конкретного сотрудника
        }

        private void общееРасписаниеToolStripMenuItem_Click(object sender, EventArgs e) //Расписание
        {
            this.Hide();
            ScheduleForm sched = new ScheduleForm(_authForm, this, _user.Id_acc_level) { Visible = true }; //Открываем форму для просмотра плана проведения

        }

        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e) //Изменить параменты учетной записи
        {
            this.Hide();
            EditAccForm editAccForm = new EditAccForm(_authForm, this, _user.Id_account) { Visible = true }; //Переход на форму изменения инфы об аккаунте
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) //Выход
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e) //Выход
        {
            this.Close();

        }

        private void UserMainForm_Load(object sender, EventArgs e) //Загрузка
        {
            lblFIO.Text = _user.Full_name + ": " + _user.Name_acc_level;

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название"; //текст в шапке
            column1.Width = 300; //ширина колонки
            column1.Name = "Event"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Категория";
            column2.Width = 100; //ширина колонки
            column2.Name = "Categ";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Организатор";
            column3.Width = 100; //ширина колонки
            column3.Name = "Org";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 50; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();

            var column01 = new DataGridViewColumn();
            column01.HeaderText = "Дата и время";
            column01.Width = 100; //ширина колонки
            column01.Name = "DateT";
            column01.CellTemplate = new DataGridViewTextBoxCell();

            dgvEvents.Columns.Add(column0);
            dgvEvents.Columns.Add(column01);
            dgvEvents.Columns.Add(column1);
            dgvEvents.Columns.Add(column2);
            dgvEvents.Columns.Add(column3);

            dgvEvents.EnableHeadersVisualStyles = false;
            dgvEvents.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEvents.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputPlanEvent();

        }

        private void OutputPlanEvent() //Выводим в DataGridView новые значения
        {
            DateTime date_now = DateTime.Today; //Дата сейчас

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
           
            string sql = "SELECT activity.id_action_plan, action_plan.id_event, name_event, name_category, name_organizer, name_organization_type, date_event, time_event " +
                   "FROM organization_type " +
                   "JOIN organizer " +
                   "ON organization_type.id_organization_type = organizer.id_organization_type " +
                    "JOIN event " +
                   "ON organizer.id_organizer = event.id_organizer " +
                    "JOIN category " +
                   "ON event.id_category = category.id_category " +
                    "JOIN action_plan " +
                   "ON event.id_event = action_plan.id_event " +
                   "JOIN activity " +
                   "ON activity.id_action_plan = action_plan.id_action_plan " +
               "WHERE date_event >= @date AND activity.id_account = @id "+
               "ORDER BY date_event, time_event";

            string date_n = Convert.ToString(date_now).Substring(0, 10);
            string date = date_n.Substring(6, 4) + "." + date_n.Substring(3, 2) + "." + date_n.Substring(0, 2);
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _user.Id_account;

            MySqlDataReader date_event = command.ExecuteReader();

            while (date_event.Read())
            {
                dgvEvents.Rows.Add(date_event[0].ToString(), date_event[6].ToString().Substring(0, 10) + " " + date_event[7].ToString(), date_event[2].ToString(), date_event[3].ToString(), 
                    date_event[4].ToString() + " ("+ date_event[5].ToString()+")");
            }

            date_event.Close();
            conn.Close();
        }

        private void UserMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authForm.Visible = true; //Переход на форму авторизации
        }

        private void btnTechSup_Click(object sender, EventArgs e) //Письмо в техподдержку
        {
            TechMailForm techMailForm = new TechMailForm(_user) { Visible = true };
        }

        private void btnChen_Click(object sender, EventArgs e) //Изменить параменты учетной записи
        {
            this.Hide();
            EditAccForm editAccForm = new EditAccForm(_authForm, this, _user.Id_account) { Visible = true }; //Переход на форму изменения инфы об аккаунте
        }

        private void button1_Click(object sender, EventArgs e) //Подробнее о мероприятии
        {
            DateEvent ev = new DateEvent(Convert.ToInt32(dgvEvents.CurrentRow.Cells[0].Value),
                   Convert.ToString(dgvEvents.CurrentRow.Cells[1].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[2].Value),
                   Convert.ToString(dgvEvents.CurrentRow.Cells[4].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[3].Value));

            this.Hide();
            EventForEmplForm eventForEmplForm = new EventForEmplForm(_authForm, this, ev, _user) { Visible = true }; //Переход к конкретному мероприятию
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;
        }
        
    }
}
