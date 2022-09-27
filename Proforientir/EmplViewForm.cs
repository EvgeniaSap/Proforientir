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
    public partial class EmplViewForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню для администратора;
        private User _user; //Пользователь, загрузивший форму;

        public EmplViewForm()
        {
            InitializeComponent();
        }

        public EmplViewForm(AuthForm authForm, AdminMainForm adminMainForm, User user)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _user = user;

            InitializeComponent();
        }

        private void EmplView_Load(object sender, EventArgs e)
        {
            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID"; //текст в шапке
            column0.Width = 40; //ширина колонки
            column0.Name = "Id"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column0.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ФИО"; //текст в шапке
            column1.Width = 250; //ширина колонки
            column1.Name = "FIO"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            //Height
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Логин";
            column2.Width = 50; //ширина колонки
            column2.Name = "Log";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Почта";
            column3.Width = 150; //ширина колонки
            column3.Name = "Mail";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputEmpls();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _adminMainForm.Show(); //Переход к главной форме админа;
        }

        private void btnNewEmpl_Click(object sender, EventArgs e) //Добавление нового сотрудника
        {
            this.Hide();
            RegForm empl_view = new RegForm(_authForm, _adminMainForm, this, _user, 2) { Visible = true }; //Открываем форму для просмотра сотрудников

        }

        private void OutputEmpls() //Выводим в DataGridView новые значения
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT  id_account, id_account_type, FIO, login, mail " +
               "FROM account " +
               "WHERE id_account_type != '3' AND status = '0'";
            
            MySqlCommand command = new MySqlCommand(sql, conn);
            
            MySqlDataReader empls = command.ExecuteReader();
            
            while (empls.Read())
            {
                dataGridView1.Rows.Add(empls[0].ToString(), empls[2].ToString(), empls[3].ToString(), empls[4].ToString());
            }

            empls.Close();
            conn.Close();
        }

        private void EmplViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _adminMainForm.Show();
        }

        private void btnDeny_Click(object sender, EventArgs e) //Лишить доступа в систему
        {
            try
            {
                DialogResult result = MessageBox.Show(
                      "Вы уверены, что хотите лишить сотрудника доступа в систему?",
                      "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    
                        MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                        string sql = " UPDATE account SET status = @st WHERE id_account = @id";

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@st", 1);
                        command.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        dataGridView1.Rows.Clear();
                        OutputEmpls();
                   
                }
                this.TopMost = true;

            }
            catch
            {
                MessageBox.Show("Выберите сотрудника!");
            }
            
        }

        private void btnCheckEvent_Click(object sender, EventArgs e) //Участие в мероприятиях
        {
            try
            {
                this.Hide();
                AccEventForm accEventForm = new AccEventForm(_authForm, _adminMainForm, this, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)) { Visible = true }; //Переход на форму отображения мероприятий конкретного сотрудника
            }
            catch
            {
                MessageBox.Show("Выберите сотрудника!");
                this.Show();
            }

        }
    }
}
