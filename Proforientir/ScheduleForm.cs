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
    public partial class ScheduleForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private AllEventsForm _allEventsForm; //Форма полного перечня мероприятий;
        private UserMainForm _userMainForm; //Форма личного кабинета пользователя;
        private string _selectedPosit; //Выбранный период;
        private int _idEvent; //Конкретное мероприятие;
        private string _name; //Конкретное мероприятие;
        private int _idUser; //Индекс уровня доступа пользователя, загрузившего форму;

        public ScheduleForm()
        {
            InitializeComponent();
        }

        public ScheduleForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _name = "";
            _idUser = 0;

            InitializeComponent();
        }

        public ScheduleForm(AuthForm authForm, AdminMainForm adminMainForm, AllEventsForm allEventsForm, int id, string str)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _allEventsForm = allEventsForm;
            _idEvent = id;
            _name = str;
            _idUser = 0;

            InitializeComponent();
        }

        public ScheduleForm(AuthForm authForm, AdminMainForm adminMainForm, int id, string str)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _idEvent = id;
            _name = str;
            _idUser = 0;

            InitializeComponent();
        }

        public ScheduleForm(AuthForm authForm, UserMainForm userMainForm, int user)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _idUser = user;
            _name = "";

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            if (_name != "")
            {
                labelSEv.Visible = true;
                labelSEv.Text += _name;
            }

            if (_userMainForm != null)
            {
                btnNew.Visible = false;
                btnAddPart.Visible = false;
                btnDelPart.Visible = false;
                btnMore.Visible = false;
                
            }

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

            OutputCmbDate(); //Вывод периодов
            //OutputEvents(); //Вывод мероприятий за период
        }

        public void OutputEvents() //Выводим мероприятия за период
        {
            if (_selectedPosit != "")
            {
                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();

                string sql = "SELECT id_action_plan, action_plan.id_event, name_event, name_category, name_organizer, name_organization_type, date_event, time_event " +
                   "FROM organization_type " +
                   "JOIN organizer " +
                   "ON organization_type.id_organization_type = organizer.id_organization_type " +
                    "JOIN event " +
                   "ON organizer.id_organizer = event.id_organizer " +
                    "JOIN category " +
                   "ON event.id_category = category.id_category " +
                    "JOIN action_plan " +
                   "ON event.id_event = action_plan.id_event ";// +

                if (_name!="")
                {
                    sql += "WHERE action_plan.id_event = @id ";
                }

                MySqlCommand command = new MySqlCommand(sql, conn);

                if (_name != "")
                {
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idEvent;
                }

                MySqlDataReader events = command.ExecuteReader();
                List<List<string>> bufev = new List<List<string>>();
                while (events.Read())
                {
                     List<string> buf = new List<string>();
                    buf.Add(events[0].ToString());
                    buf.Add(events[6].ToString().Substring(0, 10) + " " + events[7].ToString());
                    buf.Add(events[2].ToString());
                    buf.Add(events[3].ToString());
                    buf.Add(events[4].ToString() + " (" + events[5].ToString() + ")");
                    bufev.Add(buf);
                }

                events.Close();
                conn.Close();

                foreach (List<string> ev in bufev)
                {
                    if (Convert.ToInt32(ev[1].Substring(6, 4))> Convert.ToInt32(_selectedPosit.Substring(0, 4)) &&
                        Convert.ToInt32(ev[1].Substring(6, 4)) < Convert.ToInt32(_selectedPosit.Substring(_selectedPosit.IndexOf('-') + 1, 4)))
                    {
                        dgvEvents.Rows.Add(ev[0], ev[1], ev[2], ev[3], ev[4]);
                 }
                    else if (Convert.ToInt32(ev[1].Substring(6, 4))== Convert.ToInt32(_selectedPosit.Substring(0, 4)) &&
                        Convert.ToInt32(ev[1].Substring(3, 2))>=9)
                    {
                        dgvEvents.Rows.Add(ev[0], ev[1], ev[2], ev[3], ev[4]);
                    }
                    else if (Convert.ToInt32(ev[1].Substring(6, 4)) == Convert.ToInt32(_selectedPosit.Substring(_selectedPosit.IndexOf('-') + 1, 4)) &&
                        Convert.ToInt32(ev[1].Substring(3, 2)) <= 8)
                    {
                        dgvEvents.Rows.Add(ev[0], ev[1], ev[2], ev[3], ev[4]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Нет информации.");
            }
            
        }

        public void OutputCmbDate() //Вывод периодов
        {
            DateTime date_now = DateTime.Today; //Дата сейчас
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT date_event " +
                "FROM action_plan ORDER BY date_event";

            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            try
            {
                posit.Read();
                string firstDate = posit[0].ToString();

                posit.Close();
                conn.Close();

                List<string> years = new List<string>();

                if (Convert.ToInt32(firstDate.Substring(3, 2)) <= 8)
                {
                    years.Add((Convert.ToInt32(firstDate.Substring(6, 4)) - 1).ToString() + "-" + (Convert.ToInt32(firstDate.Substring(6, 4))).ToString());
                 }

                int k = 0;
                while (Convert.ToInt32(firstDate.Substring(6, 4)) + k <= Convert.ToInt32(Convert.ToString(date_now).Substring(6, 4)))
                {
                    years.Add((Convert.ToInt32(firstDate.Substring(6, 4)) + k).ToString() + "-" + (Convert.ToInt32(firstDate.Substring(6, 4)) + k +1).ToString());
                    k++;
                }

                for (int i = years.Count()-1; i>=0; i--)
                {
                    cmbDate.Items.Add(years[i]);
                }

                cmbDate.SelectedIndex = 0;
            }
            catch
            {
                posit.Close();
                conn.Close();
                MessageBox.Show("В расписании нет мероприятий.");
            }
            
        }

        public void OutputParts() //Выводим участников в выбранном мероприятии
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_activity, activity.id_action_plan, name_role, FIO, name_account_type, activity.id_role " +
               "FROM account_type "+
               "JOIN account " +
               "ON account_type.id_account_type = account.id_account_type " +
               "JOIN activity " +
               "ON account.id_account = activity.id_account " +
               "JOIN action_plan " +
               "ON activity.id_action_plan = action_plan.id_action_plan " +
               "JOIN role " +
               "ON activity.id_role = role.id_role " +
               "WHERE activity.id_action_plan = @id "+
               "ORDER BY activity.id_role ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = dgvEvents.CurrentRow.Cells[0].Value;
           
            MySqlDataReader patrs = command.ExecuteReader();


            while (patrs.Read())
            {
                dgvParts.Rows.Add(patrs[0].ToString(), patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString());
            }
           
            patrs.Close();
            conn.Close();

        }


        private void ScheduleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allEventsForm != null)
            {
                _allEventsForm.Show(); //Переход на форму всех мероприятий
            }
            else if (_userMainForm != null)
            {
                _userMainForm.Show();
            }
            else
            {
                _adminMainForm.Show(); //Переход на форму админа
            }
        }

        private void cmbDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = cmbDate.SelectedItem.ToString();
            if (dgvEvents.Rows !=null)
            {
                dgvEvents.Rows.Clear();

            }
            OutputEvents(); //Вывод мероприятий за период
          //  dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
           // dgvEvents.ClearSelection();

        }
        
        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (dgvParts.Rows != null)
             {
                dgvParts.Rows.Clear();
             }
            // OutputParts(); //Выводим участников в выбранном мероприятии*/
            dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;
          //  MessageBox.Show(Convert.ToString(dgvEvents.CurrentRow.Cells[0]));
            OutputParts(); //Выводим участников в выбранном мероприятии
           // dgvParts.ClearSelection();
        }

        private void dgvEvents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvParts.Rows != null)
            {
                dgvParts.Rows.Clear();
            }
            dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;
            OutputParts(); //Выводим участников в выбранном мероприятии
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

        private void dgvParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvParts.Rows[dgvParts.CurrentRow.Index].Selected = true;
        }

        private void btnAddPart_Click(object sender, EventArgs e) //Добавдение участника
        {
            if (dgvEvents.CurrentRow.Cells[0].Value != null)
            {
               // dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;

               // MessageBox.Show(dgvEvents.CurrentRow.Cells[0].Value.ToString());
                DateEvent ev = new DateEvent(Convert.ToInt32(dgvEvents.CurrentRow.Cells[0].Value),
                    Convert.ToString(dgvEvents.CurrentRow.Cells[1].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[2].Value),
                    Convert.ToString(dgvEvents.CurrentRow.Cells[4].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[3].Value));

               // string id = dgvEvents.CurrentRow.Cells[0].Value.ToString();
                this.Enabled = false;
                AddPartForm addPartForm = new AddPartForm(_authForm, _adminMainForm, this, ev) { Visible = true }; //Открытие формы для добавления участника
            }
            else
            {
                MessageBox.Show("Выберите мероприятие!");
            }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(dgvEvents.CurrentRow.Index.ToString());
        /*    if (dgvParts.Rows != null)
            {
                dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;
             }
            */
        }

        private void btnNew_Click(object sender, EventArgs e) //Добавить в расписание мероприятие
        {
            this.Hide();
            AllEventsForm allEventsForm = new AllEventsForm(_authForm, _adminMainForm, this) { Visible = true }; //Открываем форму всех мероприятий
        }

        private void btnMaterials_Click(object sender, EventArgs e) //Материалы к мероприятию
        {
            if (dgvEvents.CurrentRow.Cells[0].Value != null)
            {
                // dgvEvents.Rows[dgvEvents.CurrentRow.Index].Selected = true;

                // MessageBox.Show(dgvEvents.CurrentRow.Cells[0].Value.ToString());
                DateEvent ev = new DateEvent(Convert.ToInt32(dgvEvents.CurrentRow.Cells[0].Value),
                    Convert.ToString(dgvEvents.CurrentRow.Cells[1].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[2].Value),
                    Convert.ToString(dgvEvents.CurrentRow.Cells[4].Value), Convert.ToString(dgvEvents.CurrentRow.Cells[3].Value));

                this.Hide();
                MaterialForm materialForm = new MaterialForm(_authForm, _adminMainForm, this, ev, _idUser) { Visible = true }; //Открываем форму с материалами
            }
            else
            {
                MessageBox.Show("Выберите мероприятие!");
            }
            
        }

        private void btnMore_Click(object sender, EventArgs e) //Подробнее об участнике
        {
            try
            {
                int idAcc;

                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();

                string sql = "SELECT activity.id_account " +
                   "FROM account " +
                   "JOIN activity " +
                   "ON account.id_account = activity.id_account " +
                   "WHERE activity.id_activity = @id ";

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = dgvParts.CurrentRow.Cells[0].Value;

                MySqlDataReader patrs = command.ExecuteReader();

                patrs.Read();
                idAcc = Convert.ToInt32(patrs[0]);

                patrs.Close();
                conn.Close();



                this.Hide();
                AccEventForm accEventForm = new AccEventForm(_authForm, _adminMainForm, this, idAcc) { Visible = true }; //Переход на форму отображения мероприятий конкретного  пользователя

            }
            catch
            {
                MessageBox.Show("Выберите участника!");
                this.Show();
            }
        }
    }
}
