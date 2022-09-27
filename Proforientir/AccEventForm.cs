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
    public partial class AccEventForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню для администратора;
       // private User _user; //Пользователь, загрузивший форму;
        private EmplViewForm _emplViewForm; //Форма просмотра всех сотрудников;
        private StudViewForm _studViewForm; //Форма просмотра всех студентов;
        private ScheduleForm _scheduleForm; //Форма расписания мероприятий;
        private UserMainForm _userMainForm; //Форма личного кабинета пользователя;
        private int _idAcc; //Индекс аккаунта, о котором отображать информацию;
        private int _idStud; //Индекс студента, о котором отображать информацию;
        private User _user; //Пользователь, загрузивший форму;

        public AccEventForm()
        {
            InitializeComponent();
        }

        public AccEventForm(AuthForm authForm, AdminMainForm adminMainForm, EmplViewForm emplViewForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _emplViewForm = emplViewForm;
            _idAcc = id;
           
            InitializeComponent();
        }

        public AccEventForm(AuthForm authForm, AdminMainForm adminMainForm, StudViewForm studViewForm, int id, int id2)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _studViewForm = studViewForm;
            _idAcc = id;
            _idStud = id2;

            InitializeComponent();
        }

        public AccEventForm(AuthForm authForm, AdminMainForm adminMainForm, ScheduleForm scheduleForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _scheduleForm = scheduleForm;
            _idAcc = id;

            InitializeComponent();
        }

        public AccEventForm(AuthForm authForm, UserMainForm userMainForm, int id, User us)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _idAcc = id;
            _user = us;

            InitializeComponent();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void AccEventForm_Load(object sender, EventArgs e) //Загрузка
        {
            if (_userMainForm!=null)
            {
                btnStat.Visible = false;
                btnDel.Visible = false;
                btnMore.Visible = true;
            }

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT FIO, name_account_type " +
                "FROM account "+
                "JOIN account_type "+
                "ON account.id_account_type = account_type.id_account_type " +
                "WHERE id_account = @id ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idAcc;
            MySqlDataReader posit = command.ExecuteReader();

            posit.Read();
            labelInfo.Text = posit[0].ToString() +", "+ posit[1].ToString();

            posit.Close();
            conn.Close();

            if (_studViewForm!=null)
            {
                btnStat.Visible = true;
            }

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

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Роль"; //текст в шапке
            column11.Width = 100; //ширина колонки
            column11.Name = "Role"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column11.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            dgvEvents.Columns.Add(column0);
            dgvEvents.Columns.Add(column01);
            dgvEvents.Columns.Add(column1);
            dgvEvents.Columns.Add(column2);
            dgvEvents.Columns.Add(column11);

            dgvEvents.EnableHeadersVisualStyles = false;
            dgvEvents.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEvents.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputEventOfPart(); //Выводим мероприятия пользователя


        }

        public void OutputEventOfPart() //Выводим мероприятия пользователя
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_activity, date_event, time_event, name_event, name_category, name_role " +
               "FROM account " +
               "JOIN activity " +
               "ON account.id_account = activity.id_account " +
               "JOIN action_plan " +
               "ON activity.id_action_plan = action_plan.id_action_plan " +
               "JOIN role " +
               "ON activity.id_role = role.id_role " +
                "JOIN event " +
                 "ON event.id_event = action_plan.id_event " +
                  "JOIN category " +
                  "ON event.id_category = category.id_category " +
               "WHERE activity.id_account = @id " +
               "ORDER BY date_event DESC ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idAcc;

            MySqlDataReader patrs = command.ExecuteReader();


            while (patrs.Read())
            {
                dgvEvents.Rows.Add(patrs[0].ToString(), patrs[1].ToString().Substring(0,10)+ " " +patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString(), patrs[5].ToString());
            }

            patrs.Close();
            conn.Close();

        }


        private void AccEventForm_FormClosing(object sender, FormClosingEventArgs e) //Закрыть
        {
            if (_emplViewForm!=null)
            {
                _emplViewForm.Show();
            }
            else if (_studViewForm!=null)
            {
                _studViewForm.Show();
            }
            else if (_scheduleForm!=null)
            {
                _scheduleForm.Show();
            }
            else if (_userMainForm != null)
            {
                _userMainForm.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e) //Убрать из участников
        {
            try
            {
                DialogResult result = MessageBox.Show(
                     "Вы уверены, что хотите снять участника с мероприятия?",
                     "Сообщение",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information,
                     MessageBoxDefaultButton.Button1,
                     MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    // MessageBox.Show(_tick[dataGridView1.CurrentRow.Index].ToString());
                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                    string sql = "DELETE FROM activity WHERE id_activity = @id";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", dgvEvents.CurrentRow.Cells[0].Value);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    dgvEvents.Rows.Clear();
                    OutputEventOfPart();
                }
                this.TopMost = true;


            }
            catch
            {
                MessageBox.Show("Выберите запись в плане!");
            }
        }

        private void btnStat_Click(object sender, EventArgs e) //Статистика
        {
            this.Hide();
            OneStudStatForm OneStudStatForm = new OneStudStatForm(_authForm, _adminMainForm, _studViewForm, this, _idStud) { Visible = true }; //Статистика о конкретном студенте
        }

        private void btnMore_Click(object sender, EventArgs e) //Кнопка подробнее для сотрудника
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_action_plan " +
               "FROM activity " +
               "WHERE id_activity = @id ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(dgvEvents.CurrentRow.Cells[0].Value);

            MySqlDataReader patrs = command.ExecuteReader();
            patrs.Read();
            int id_action_plan = Convert.ToInt32(patrs[0]);
            
            patrs.Close();
            conn.Close();

            DateEvent ev = new DateEvent(id_action_plan,
               Convert.ToString(dgvEvents.CurrentRow.Cells[1].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[2].Value),
               Convert.ToString(dgvEvents.CurrentRow.Cells[4].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[3].Value));

            this.Hide();
            EventForEmplForm eventForEmplForm = new EventForEmplForm(_authForm, _userMainForm, this, ev, _user) { Visible = true }; //Переход к конкретному мероприятию

        }
    }
}
