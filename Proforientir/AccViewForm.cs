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
    public partial class AccViewForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;

        public AccViewForm()
        {
            InitializeComponent();
        }

        public AccViewForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;

            InitializeComponent();
        }

        private void AccViewForm_Load(object sender, EventArgs e) //Загрузка
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

            var column11 = new DataGridViewColumn();
            column11.HeaderText = "Уровень доступа";
            column11.Width = 70; //ширина колонки
            column11.Name = "Level";
            column11.CellTemplate = new DataGridViewTextBoxCell();

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

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Статус аккаунта";
            column4.Width = 60; //ширина колонки
            column4.Name = "St";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Активация";
            column5.Width = 90; //ширина колонки
            column5.Name = "Activ";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dgvAccs.Columns.Add(column0);
            dgvAccs.Columns.Add(column1);
            dgvAccs.Columns.Add(column11);
            dgvAccs.Columns.Add(column2);
            dgvAccs.Columns.Add(column3);
            dgvAccs.Columns.Add(column4);
            dgvAccs.Columns.Add(column5);

            dgvAccs.EnableHeadersVisualStyles = false;
            dgvAccs.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAccs.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputAccs();
        }

        public void OutputAccs() //Выводим в DataGridView новые значения
        {

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_account, name_account_type, FIO, login, mail, status, activation " +
               "FROM account " +
               "JOIN account_type " +
               "ON account.id_account_type = account_type.id_account_type "+
               "ORDER BY account.id_account_type, FIO ";

            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader empls = command.ExecuteReader();

            while (empls.Read())
            {
                string str1 = "";

               // MessageBox.Show(empls[5].ToString() + " " + "0");
                if (empls[5].ToString() != "False")
                {
                    str1 = "Удален";
                }

                string str2 = "Активирован";
                if (empls[6].ToString() == "0")
                {
                    str2 = "Не активирован";
                }
                
                dgvAccs.Rows.Add(empls[0].ToString(), empls[2].ToString(), empls[1].ToString(), empls[3].ToString(), empls[4].ToString(), str1, str2);
            }

            empls.Close();
            conn.Close();
        }

        private void AccViewForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _adminMainForm.Show(); //Переход на форму админа
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void btnStatus_Click(object sender, EventArgs e) //Изменить статус аккаунта
        {
            try
            {
                DialogResult result = MessageBox.Show(
                      "Вы уверены, что хотите изменить статус доступа в систему?",
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

                        if (dgvAccs.CurrentRow.Cells[5].Value.ToString() == "Удален" )
                        {
                            command.Parameters.AddWithValue("@st", false);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@st", true);
                        }
                        
                        command.Parameters.AddWithValue("@id", dgvAccs.CurrentRow.Cells[0].Value);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        dgvAccs.Rows.Clear();
                        OutputAccs();
                   
                }
                this.TopMost = true;

            }
            catch
            {
                MessageBox.Show("Выберите аккаунт!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAccs.Rows[dgvAccs.CurrentRow.Index].Selected = true;
        }

        private void btnEdit_Click(object sender, EventArgs e) //Изменить данные
        {
            this.Hide();
            EditAccForm editAccForm = new EditAccForm(_authForm, _adminMainForm, this, Convert.ToInt32(dgvAccs.CurrentRow.Cells[0].Value)) { Visible = true }; //Переход на форму изменения инфы об аккаунте
        }

        private void btnSend_Click(object sender, EventArgs e) //Пригласить в систему
        {
            if (dgvAccs.CurrentRow.Cells[6].Value.ToString() != "Активирован") {
                try
                {
                    Random rnd = new Random();
                    //Получить очередное (в данном случае - первое) случайное число
                    int code = rnd.Next(10000, 99999);


                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    string sql = "UPDATE account SET activation = @act " +
                        "WHERE id_account = @id";
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    command.Parameters.AddWithValue("@act", code);
                    command.Parameters.AddWithValue("@id", dgvAccs.CurrentRow.Cells[0].Value.ToString());

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    try
                    {
                        SendMail new_mail = new SendMail(dgvAccs.CurrentRow.Cells[4].Value.ToString(), dgvAccs.CurrentRow.Cells[1].Value.ToString());
                        new_mail.SendRegCode(code).GetAwaiter();
                        MessageBox.Show("Пользователю отправлено приглашение.");

                    }
                    catch
                    {
                        MessageBox.Show("Проверьте адрес электронной почты!");
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Что-то пошло не так!");
                }
            }
            else
            {
                MessageBox.Show("Аккаунт пользователя уже активирован!");
            }
        }
    }
}
