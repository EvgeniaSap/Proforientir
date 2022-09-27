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
    public partial class EventForEmplForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private UserMainForm _userMainForm; //Форма личного кабинета пользователя;
        private AccEventForm _accEventForm; //Форма личного расписания пользователя;
        private User _user; //Пользователь, загрузивший форму;
        private DateEvent _dateEv; //Выбранное мероприятие

        public EventForEmplForm()
        {
            InitializeComponent();
        }

        public EventForEmplForm(AuthForm authForm, UserMainForm userMainForm, DateEvent dateEv, User user)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _dateEv = dateEv;
            _user = user;

            InitializeComponent();
        }

        public EventForEmplForm(AuthForm authForm, UserMainForm userMainForm, AccEventForm accEventForm, DateEvent dateEv, User user)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _accEventForm = accEventForm;
            _dateEv = dateEv;
            _user = user;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void EventForEmplForm_Load(object sender, EventArgs e) //Загрузка
        {
            labelInfo.Text += _dateEv.Info_event.Category + " '" + _dateEv.Info_event.Name_event + "' \n" +
                _dateEv.Datetime_event + " " + _dateEv.Info_event.Name_organizer;

            var column00 = new DataGridViewColumn();
            column00.HeaderText = "ID";
            column00.Width = 50; //ширина колонки
            column00.Name = "Id";
            column00.CellTemplate = new DataGridViewTextBoxCell();

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Роль"; //текст в шапке
            column11.Width = 100; //ширина колонки
            column11.Name = "Role"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column11.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column22 = new DataGridViewColumn();
            column22.HeaderText = "ФИО";
            column22.Width = 170; //ширина колонки
            column22.Name = "Name";
            column22.CellTemplate = new DataGridViewTextBoxCell();

            var column33 = new DataGridViewColumn();
            column33.HeaderText = "Тип пользователя";
            column33.Width = 170; //ширина колонки
            column33.Name = "Type";
            column33.CellTemplate = new DataGridViewTextBoxCell();

            dgvParts.Columns.Add(column00);
            dgvParts.Columns.Add(column11);
            dgvParts.Columns.Add(column22);
            dgvParts.Columns.Add(column33);

            dgvParts.EnableHeadersVisualStyles = false;
            dgvParts.ColumnHeadersDefaultCellStyle.Font = new Font(dgvParts.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16
            OutputParts(); //Выводим участников в выбранном мероприятии


        }

        public void OutputParts() //Выводим участников в выбранном мероприятии
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_activity, activity.id_action_plan, name_role, FIO, name_account_type, activity.id_role " +
               "FROM account_type " +
               "JOIN account " +
               "ON account_type.id_account_type = account.id_account_type " +
               "JOIN activity " +
               "ON account.id_account = activity.id_account " +
               "JOIN action_plan " +
               "ON activity.id_action_plan = action_plan.id_action_plan " +
               "JOIN role " +
               "ON activity.id_role = role.id_role " +
               "WHERE activity.id_action_plan = @id " +
               "ORDER BY activity.id_role ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _dateEv.Id_schedule;

            MySqlDataReader patrs = command.ExecuteReader();


            while (patrs.Read())
            {
                dgvParts.Rows.Add(patrs[0].ToString(), patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString());
            }

            patrs.Close();
            conn.Close();

            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            sql = "SELECT id_activity, activity.id_role " +
               "FROM activity " +
               "WHERE activity.id_account = @id ";

            command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _user.Id_account;

            patrs = command.ExecuteReader();
            patrs.Read();

            if (patrs[1].ToString() != "1")
            {
                btnAddPart.Enabled = false;
                btnDelPart.Enabled = false;
            }
            
            patrs.Close();
            conn.Close();

        }

        private void btnAddPart_Click(object sender, EventArgs e) //Добавить нового участника
        {
            this.Enabled = false;
            AddPartForm addPartForm = new AddPartForm(_authForm, null, this, _dateEv) { Visible = true }; //Открытие формы для добавления участника

        }

        private void btnDelPart_Click(object sender, EventArgs e) //Удалить участника
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
                    command.Parameters.AddWithValue("@id", dgvParts.CurrentRow.Cells[0].Value);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    dgvParts.Rows.Clear();
                    OutputParts();
                }
                this.TopMost = true;

            }
            catch
            {
                MessageBox.Show("Выберите участника!");
            }
        }

        private void btnMaterial_Click(object sender, EventArgs e) //Материалы для мероприятия
        {
            this.Hide();
            if (btnAddPart.Enabled == false) //Загрузка формы как для студента
            {
                MaterialForm materialForm = new MaterialForm(_authForm, _userMainForm, this, _dateEv, 3) { Visible = true }; //Открываем форму с материалами

            }
            else //Загрузка формы с возможностью добавлять и удалять файлы
            {
                MaterialForm materialForm = new MaterialForm(_authForm, _userMainForm, this, _dateEv, 2) { Visible = true }; //Открываем форму с материалами

            }
        }

        private void EventForEmplForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            if (_accEventForm!=null)
            {
                _accEventForm.Show();
            }
            else
            {
                _userMainForm.Show();
            }
        }

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvParts.Rows[dgvParts.CurrentRow.Index].Selected = true;
        }
    }
}
