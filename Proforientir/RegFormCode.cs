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

namespace Proforientir
{
    public partial class RegFormCode : Form
    {
        private AuthForm _authForm; //Форма авторизации
        private int _key; //Ключ для отображения компонентов
        private User _newUser; //Новый пользователь
        private RegFormCode _reloudReg; //Форма для продолжения регистрации

        public RegFormCode(AuthForm authForm)
        {
            _authForm = authForm;
            _key = 1;

            InitializeComponent();
        }

        public RegFormCode(AuthForm authForm, int k, User u)
        {
            _authForm = authForm;
            _key = k;
            _newUser = u;

            InitializeComponent();
        }

        private void txtPatron_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void RegFormCode_Load(object sender, EventArgs e)
        {
            if (_key == 1)
            {
                txtPatron.Visible = true;
                txtLname.Visible = true;
                txtFname.Visible = true;
                txtCode.Visible = true;
                txtCode.Enabled = true;
                txtLogin.Visible = false;
                txtLogin.Enabled = false;
                label3.Visible = false;
                label2.Visible = false;
                txtPass1.Visible = false;
                txtPass2.Visible = false;
                labelF.Text = "Введите фамилию:";
                labelN.Text = "Введите имя:";
                labelP.Text = "Введите отчество:";
                labelCM.Text = "Введите код из сообщения:";
                btnReg.Text = "Проверить приглашение";
                label1.Text = "Регистрация пользователя";
            }
            else if (_key == 2)
            {
                label1.Text = "Продолжение регистрации";
                labelF.Text = "Ваше ФИО:";
                labelN.Text = "Ваша должность:";
                labelP.Text = "Ваша почта:";
                labelCM.Text = "Введите логин:";
                btnReg.Text = "Регистрация";
                txtPatron.Visible = true;
                txtPatron.Text = _newUser.Email;
                txtLname.ReadOnly = true;
                txtLname.Text = _newUser.Full_name;
                txtFname.ReadOnly = true;
                txtFname.Text = _newUser.Name_acc_level;
                txtCode.Visible = false;
                txtCode.Enabled = false;
                txtLogin.Visible = true;
                txtLogin.Enabled = true;
                label3.Visible = true;
                label2.Visible = true;
                txtPass1.Visible = true;
                txtPass2.Visible = true;
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (_key == 1)
            {
                if (!string.IsNullOrEmpty(txtLname.Text) && !string.IsNullOrEmpty(txtFname.Text) && !string.IsNullOrEmpty(txtPatron.Text)) //Проверка введенного ФИО
                {
                    if (!string.IsNullOrEmpty(txtCode.Text)) //Проверка введенного кода
                    {
                        string name = txtLname.Text + " " + txtFname.Text + " " + txtPatron.Text; //формируем строку с ФИО

                        try { 
                        MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        conn.Open();

                        string sql = "SELECT  id_account, account.id_account_type, name_account_type, FIO, mail, activation " +
                           "FROM account " +
                           "JOIN account_type " +
                         "ON account.id_account_type = account_type.id_account_type " +
                           "WHERE status = '0' AND activation = @code AND FIO = @name";

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.Add("@code", MySqlDbType.VarChar).Value = Convert.ToString(txtCode.Text);
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        MySqlDataReader user = command.ExecuteReader();

                        if (user.Read())
                        {
                            _newUser = new User(Convert.ToInt32(user[0]), user[3].ToString(), Convert.ToInt32(user[1]), user[2].ToString(), user[4].ToString());

                            MessageBox.Show("Верный код.");
                            _key = 2;
                            _reloudReg = new RegFormCode(_authForm, 2, _newUser) { Visible = true }; //Перезагрузка формы регистрации;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Совпадений не найдено, проверьте введенные данные.");
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
                        MessageBox.Show("Введите код из сообщения.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите ФИО.");
                }
            }
            else if (_key == 2)
            {

                if (!string.IsNullOrEmpty(txtLname.Text) && !string.IsNullOrEmpty(txtFname.Text) && !string.IsNullOrEmpty(txtPatron.Text)) //Проверка введенного ФИО
                {
                    if (!string.IsNullOrEmpty(txtLogin.Text) && !string.IsNullOrEmpty(txtPass1.Text) && !string.IsNullOrEmpty(txtPass2.Text)) //Проверка введенного логина и пароля
                    {
                        if (Convert.ToString(txtPass1.Text) == Convert.ToString(txtPass2.Text)) //Проверка на совпадение введенных паролей
                        {
                            //Хеширование пароля
                            string passw = Convert.ToString(txtPass1.Text) + "ydVrg4c65baSks33mfQv0zP7dftm5";
                            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(passw);
                            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
                            string hashedPass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                            try
                            {
                                //Исправляем запись
                                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                                string sql = "UPDATE account SET mail = @em, activation = @activ, login = @lg, password = @pass " +
                                    "WHERE id_account = @id";
                                MySqlCommand command = new MySqlCommand(sql, conn);

                                command.Parameters.AddWithValue("@em", Convert.ToString(txtPatron.Text));
                                command.Parameters.AddWithValue("@activ", "");
                                command.Parameters.AddWithValue("@lg", Convert.ToString(txtLogin.Text));
                                command.Parameters.AddWithValue("@pass", hashedPass);
                                command.Parameters.AddWithValue("@id", _newUser.Id_account);

                                command.Connection.Open();
                                command.ExecuteNonQuery();
                                command.Connection.Close();

                                conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                                sql = "GRANT ALL PRIVILEGES ON *.* TO '" + txtLogin.Text + "'@'%' IDENTIFIED BY '" + txtPass2.Text + "' WITH GRANT OPTION";
                                command = new MySqlCommand(sql, conn);
                                
                                command.Connection.Open();
                                command.ExecuteNonQuery();
                                command.Connection.Close();
                                
                                MessageBox.Show("Регистрация прошла успешно.");

                            }
                            catch //(Exception ex)
                            {
                                MessageBox.Show("Отсутствует соединение с сервером.");
                            }
                            this.Close();
                            _authForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Повторно введенный пароль не совпадает.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите логин или пароль.");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте, все ли поля заполнены!");
                }
            }
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtPass1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 32) return;
            else
                e.Handled = true;
        }

        private void txtPass2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 32) return;
            else
                e.Handled = true;
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
            _authForm.Show();
        }

        private void RegFormCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authForm.Show();
        }
    }
}
