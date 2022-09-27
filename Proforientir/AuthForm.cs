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
using System.Security.Cryptography;
using System.IO;

namespace Proforientir
{
    public partial class AuthForm : Form
    {
        private RegFormCode _regForm; //Форма регистрации;
        private AdminMainForm _adminMainForm; //Форма главного меню для администратора;

        public AuthForm()
        {
            InitializeComponent();
        }

    /*    public AuthForm(AdminMainForm adminMainForm)
        {
            _adminMainForm = adminMainForm;
            InitializeComponent();
        }*/

        private void btnEnter_Click(object sender, EventArgs e) //Кнопка "Войти"
        {
            if (!string.IsNullOrEmpty(txtLogin.Text)) //Проверка введенного логина;
            {
                if (!string.IsNullOrEmpty(txtPassw.Text)) //Проверка введенного пароля;
                {
                    //Хеширование пароля
                    string passw = Convert.ToString(txtPassw.Text) + "ydVrg4c65baSks33mfQv0zP7dftm5";
                    byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(passw);
                    byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
                    string hashedPass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                    try
                    {
                        MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        conn.Open();


                        string sql = "SELECT  id_account, account.id_account_type, FIO, name_account_type  " +
                            "FROM account " +
                             "JOIN account_type " +
                             "ON account.id_account_type = account_type.id_account_type " +
                                "WHERE login = @log  AND password = @pass";

                        //   string sql = String.Format("SELECT id_account FROM account WHERE login = '{0}'", Convert.ToString(textBox1.Text));

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add("@log", MySqlDbType.VarChar).Value = Convert.ToString(txtLogin.Text);
                        //  command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hashedPass;
                        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = hashedPass;
                        MySqlDataReader user = command.ExecuteReader();

                        if (user.Read())
                        {
                            string nameFile = @"..\..\units.txt";

                            FileInfo file = new FileInfo(nameFile);
                            List<string> units = new List<string>();

                            if (file.Exists != false) //Если файл существует
                            {
                                string host = "";
                                using (StreamReader streamReader = new StreamReader(nameFile)) //Открываем файл для чтения
                                {
                                    host = streamReader.ReadLine(); 
                                }


                                using (StreamWriter streamWriter = new StreamWriter(nameFile)) //Открываем файл для чтения
                                {
                                    for (int i =0; i<3;i++)
                                    {
                                        if (i==1)
                                        {
                                            streamWriter.WriteLine(txtLogin.Text);
                                        }
                                        else if (i==2)
                                        {
                                            streamWriter.WriteLine(txtPassw.Text);
                                        }
                                        else if (i==0)
                                        {
                                            streamWriter.WriteLine(host);
                                        }
                                    }
                                }
                            }




                            User auth_user = new User(Convert.ToInt32(user[0]), Convert.ToString(user[2]), Convert.ToInt32(user[1]), Convert.ToString(user[3]));

                            if (auth_user.Id_acc_level == 1)
                            {
                                this.Visible = false;
                                _adminMainForm = new AdminMainForm(this, auth_user) { Visible = true }; //Переход в главную форму админа;
                            }
                            else if (auth_user.Id_acc_level == 2 || auth_user.Id_acc_level == 3)
                            {
                                this.Visible = false;
                                UserMainForm _userMainForm = new UserMainForm(this, auth_user) { Visible = true }; //Переход в личный кабинет пользователя;

                            }
                            else
                            {
                                MessageBox.Show("Вы не зарегистрированы!");
                            }
                            
                            txtLogin.Clear();
                            txtPassw.Clear();
                            
                        }
                        else
                        {
                            MessageBox.Show("Пользователь не найден!");
                        }

                        user.Close();
                        conn.Close();

                    }
                    catch //(Exception ex)
                    {
                        MessageBox.Show("Отсутствует соединение с сервером.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль.");
                }
            }

            else
            {
                MessageBox.Show("Введите логин.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e) //Выход из системы
        {
            Close();
        }

        private void btnReg_Click(object sender, EventArgs e) //Форма регистрации, если есть письмо
        {
            this.Visible = false;
            _regForm = new RegFormCode(this) { Visible = true }; //Переход в главную форму админа;

        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtPassw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 32) return;
            else
                e.Handled = true;
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
           // System.Diagnostics.Process.Start("C:/wamp/bin/php/php7.3.1/php.exe", "C:/Users/PC/Documents/Visual Studio 2015/Projects/Proforientir/WebParse/parseMAI.php");

            /*if (_adminMainForm != null)
            {

            _adminMainForm.Close();
            }*/
        }

        private void btnTechSup_Click(object sender, EventArgs e) //Написать в техподдержку
        {
            TechMailForm techMailForm = new TechMailForm() { Visible = true };
        }
    }
}
