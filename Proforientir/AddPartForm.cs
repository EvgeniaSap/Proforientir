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
    public partial class AddPartForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private ScheduleForm _scheduleForm; //Форма главного меню админа;
        private EventForEmplForm _eventForEmplForm; //Форма редактирования информации о мероприятии пользователем;
        //  private string _idActionPlan; //Мероприятие из плана;
        private DateEvent _dateEv; //Мероприятие из плана;
        private string _selectedPositType; //Выбранный тип пользователя;
        private string _selectedPositDeg; //Выбранныая ученая степень;
        private string _selectedPositRole; //Выбранныая ученая степень;

        public AddPartForm()
        {
            InitializeComponent();
        }

        public AddPartForm(AuthForm authForm, AdminMainForm adminMainForm, ScheduleForm scheduleForm, DateEvent ev)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _scheduleForm = scheduleForm;
            _dateEv = ev;
            _selectedPositType = "";
            _selectedPositDeg = "";
            _selectedPositRole = "";

            InitializeComponent();
        }

        public AddPartForm(AuthForm authForm, AdminMainForm adminMainForm, EventForEmplForm eventForEmplForm, DateEvent ev)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _eventForEmplForm = eventForEmplForm;
            _dateEv = ev;
            _selectedPositType = "";
            _selectedPositDeg = "";
            _selectedPositRole = "";

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddPartForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            labelEv.Text = _dateEv.Info_event.Category + " '"+_dateEv.Info_event.Name_event + "' \n"+
                _dateEv.Datetime_event+" " + _dateEv.Info_event.Name_organizer;

            label3.Visible = false;
            cmbDegr.Visible = false;

            OutputAccType(); //Вывод типов аккаунтов
            OutputDegree(); //Вывод ученых степеней
            
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ФИО";
            column1.Width = 170; //ширина колонки
            column1.Name = "Name";
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Тип пользователя";
            column2.Width = 120; //ширина колонки
            column2.Name = "Type";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Ученая степень";
            column3.Width = 120; //ширина колонки
            column3.Name = "Degr";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 50; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();
            
            dgvPart.Columns.Add(column0);
            dgvPart.Columns.Add(column1);
            dgvPart.Columns.Add(column2);
            dgvPart.Columns.Add(column3);

            dgvPart.EnableHeadersVisualStyles = false;
            dgvPart.ColumnHeadersDefaultCellStyle.Font = new Font(dgvPart.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputParts(); //Выводим пользователей
            OutputRole();

            if (_adminMainForm == null)
            {
                cmbTypeAcc.Enabled = false;
                cmbTypeAcc.SelectedIndex = cmbTypeAcc.Items.Count - 1;
            }
        }

        private void OutputRole() //Вывод ролей
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT id_role, name_role " +
                "FROM role ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbRole.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void OutputAccType() //Вывод типов аккаунтов
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_account_type, name_account_type " +
                "FROM account_type ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbTypeAcc.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void OutputDegree() //Вывод ученых степеней
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_degree, name_degree " +
                "FROM degree ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbDegr.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void AddPartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_eventForEmplForm != null)
            {
                _eventForEmplForm.Enabled = true;
            }
            else
            {
                _scheduleForm.Enabled = true;
            }
        }

        private void cmbTypeAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositType = cmbTypeAcc.SelectedItem.ToString();
            if (_selectedPositType == "3. студент")
            {
                label3.Visible = true;
                cmbDegr.Visible = true;
                _selectedPositDeg = "";
                cmbDegr.SelectedItem = null;
            }
            else
            {
                label3.Visible = false;
                cmbDegr.Visible = false;
                _selectedPositDeg = "";
            }
            if (dgvPart.Rows != null)
            {
                dgvPart.Rows.Clear();
            }
            OutputParts(); //Выводим пользователей
        }

        public void OutputParts() //Выводим пользователей
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT account.id_account, FIO, name_account_type, account.id_account_type ";

            if (_selectedPositType == "3. студент")
            {
                sql += ", name_degree ";
            }

            sql += "FROM account_type " +
               "JOIN account " +
               "ON account_type.id_account_type = account.id_account_type ";

            if (_selectedPositType == "3. студент")
            {
                sql += "JOIN student " +
               "ON account.id_account = student.id_account " +
               "JOIN degree " +
               "ON student.id_degree = degree.id_degree ";
            }

            if (_selectedPositType != "")
            {
                sql += "WHERE account.id_account_type = @idAcc ";
            }

            if (_selectedPositType == "3. студент" && _selectedPositDeg != "")
            {
                sql += "AND student.id_degree = @idDeg ";
            }

            sql += "ORDER BY account.id_account_type ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            if (_selectedPositType != "")
            {
                command.Parameters.Add("@idAcc", MySqlDbType.VarChar).Value = _selectedPositType.Substring(0, _selectedPositType.IndexOf('.'));

                if (_selectedPositType == "3. студент" && _selectedPositDeg != "")
                {
                    command.Parameters.Add("@idDeg", MySqlDbType.VarChar).Value = _selectedPositDeg.Substring(0, _selectedPositDeg.IndexOf('.'));
                }
            }

            MySqlDataReader patrs = command.ExecuteReader();


            while (patrs.Read())
            {
                if (_selectedPositType != "")
                {
                    if (_selectedPositType == "3. студент")
                    {
                        dgvPart.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), patrs[4].ToString());
                    }
                    else
                    {
                        dgvPart.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), "-");
                    }
                }
                else
                {
                    dgvPart.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), "-");
                }
               
            }

            patrs.Close();
            conn.Close();

        }

        private void cmbDegr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDegr.SelectedItem != null)
            {
                _selectedPositDeg = cmbDegr.SelectedItem.ToString();

            }
            if (dgvPart.Rows != null)
            {
                dgvPart.Rows.Clear();
            }
            OutputParts(); //Выводим пользователей
        }

        private void dgvPart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPart.Rows[dgvPart.CurrentRow.Index].Selected = true;
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            if (dgvPart.CurrentRow.Cells[0].Value != null && _selectedPositRole!="") //Проверка введенного 
            {
                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();
                string sql = "SELECT id_activity, activity.id_action_plan, activity.id_role, activity.id_account " +
               "FROM account " +
               "JOIN activity " +
               "ON account.id_account = activity.id_account " +
               "JOIN action_plan " +
               "ON activity.id_action_plan = action_plan.id_action_plan " +
               "JOIN role " +
               "ON activity.id_role = role.id_role " +
               "WHERE activity.id_action_plan = @idP AND activity.id_role = @idR AND activity.id_account = @idA ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@idP", MySqlDbType.VarChar).Value = _dateEv.Id_schedule.ToString();
                command.Parameters.Add("@idR", MySqlDbType.VarChar).Value = _selectedPositRole.Substring(0, _selectedPositRole.IndexOf('.'));
                command.Parameters.Add("@idA", MySqlDbType.VarChar).Value = dgvPart.CurrentRow.Cells[0].Value;
                MySqlDataReader posit = command.ExecuteReader();

                try
                {
                    posit.Read();
                    posit[0].ToString();
                    MessageBox.Show("Данный пользователь уже исполняет выбранную роль в мероприятии.");
                    posit.Close();
                    conn.Close();
                }
                catch
                {
                    posit.Close();
                    conn.Close();

                    conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    sql = "INSERT INTO activity (id_action_plan, id_role, id_account) VALUES (@idP, @idR, @idA)";

                    command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@idP", _dateEv.Id_schedule.ToString());
                    command.Parameters.AddWithValue("@idR", _selectedPositRole.Substring(0, _selectedPositRole.IndexOf('.')));
                    command.Parameters.AddWithValue("@idA", dgvPart.CurrentRow.Cells[0].Value);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    DateTime date_now = DateTime.Today; //Дата сейчас
                    if ((Convert.ToInt32(Convert.ToString(date_now).Substring(6, 4)) < Convert.ToInt32(_dateEv.Datetime_event.Substring(6, 4))) ||
                       (Convert.ToInt32(Convert.ToString(date_now).Substring(6, 4)) == Convert.ToInt32(_dateEv.Datetime_event.Substring(6, 4)) &&
                       Convert.ToInt32(Convert.ToString(date_now).Substring(3, 2)) <= Convert.ToInt32(_dateEv.Datetime_event.Substring(3, 2))) ||
                       (Convert.ToInt32(Convert.ToString(date_now).Substring(6, 4)) == Convert.ToInt32(_dateEv.Datetime_event.Substring(6, 4)) &&
                       Convert.ToInt32(Convert.ToString(date_now).Substring(3, 2)) == Convert.ToInt32(_dateEv.Datetime_event.Substring(3, 2)) &&
                        Convert.ToInt32(Convert.ToString(date_now).Substring(0, 2)) <= Convert.ToInt32(_dateEv.Datetime_event.Substring(0, 2))))
                    {
                        try
                        {
                            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        conn.Open();
                        sql = "SELECT mail, FIO " +
                       "FROM account " +
                       "WHERE id_account = @id ";
                       command = new MySqlCommand(sql, conn);
                       command.Parameters.Add("@id", MySqlDbType.VarChar).Value = dgvPart.CurrentRow.Cells[0].Value;
                        posit = command.ExecuteReader();

                        posit.Read();

                        
                            SendMail new_mail = new SendMail(Convert.ToString(posit[0].ToString()), posit[1].ToString());
                            new_mail.SendNewEvent(_dateEv).GetAwaiter();
                            MessageBox.Show("Пользователю отправлено уведомление.");

                            posit.Close();
                            conn.Close();
                        }
                        catch
                        {
                            MessageBox.Show("Проверьте адрес электронной почты! Уведомление не отправлено.");
                        }
                        
                    }

                    this.Close();
                    _scheduleForm.dgvParts.Rows.Clear();
                    _scheduleForm.OutputParts();
                }
            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositRole = cmbRole.SelectedItem.ToString();
        }
    }
}
