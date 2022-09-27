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
    public partial class EditAccForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private AccViewForm _accViewForm; //Форма просмотра пользователей;
        private UserMainForm _userMainForm; //Форма личного кабинета пользователя;
        private int _idAcc; //Индекс аккаунта;
        private string _selectedPosit; //Выбранный уровень доступа;

        public EditAccForm()
        {
            InitializeComponent();
        }

        public EditAccForm(AuthForm authForm, AdminMainForm adminMainForm, AccViewForm accViewForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _accViewForm = accViewForm;
            _idAcc = id;
            _selectedPosit = "";

            InitializeComponent();
        }

        public EditAccForm(AuthForm authForm, AdminMainForm adminMainForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _idAcc = id;
            _selectedPosit = "";

            InitializeComponent();
        }

        public EditAccForm(AuthForm authForm, UserMainForm userMainForm, int id)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _idAcc = id;
            _selectedPosit = "";

            InitializeComponent();
        }

        private void EditAccForm_Load(object sender, EventArgs e) //Загрузка
        {
            OutputAccType(); //Вывод уровней доступа
            cmbAccType.Enabled = false;

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT FIO, mail, account.id_account_type, login " +
                "FROM account " +
                "JOIN account_type " +
                "ON account.id_account_type = account_type.id_account_type " +
                "WHERE id_account = @id ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idAcc.ToString();
            MySqlDataReader posit = command.ExecuteReader();

            posit.Read();
            string fio = Convert.ToString(posit[0]);
            txtLN.Text = fio.Substring(0, fio.IndexOf(" "));
            fio = fio.Substring(fio.IndexOf(" ") + 1, fio.Length - 1 - fio.IndexOf(" "));
            txtFN.Text = fio.Substring(0, fio.IndexOf(" "));
            fio = fio.Substring(fio.IndexOf(" ") + 1, fio.Length - 1 - fio.IndexOf(" "));
            txtP.Text = fio;

            txtMail.Text = Convert.ToString(posit[1]);
           
            cmbAccType.SelectedItem = cmbAccType.Items[Convert.ToInt32(Convert.ToString(posit[2])) - 1];

            if (_accViewForm == null)
            {
                label4.Visible = true;
                txtLogin.Visible = true;
                txtLogin.Text = Convert.ToString(posit[3]);
                label5.Visible = true;
                txtPassw1.Visible = true;
                label6.Visible = true;
                txtPassw2.Visible = true;
            }


            posit.Close();
            conn.Close();
        }

        private void OutputAccType() //Вывод уроней доступа
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_account_type, name_account_type " +
                "FROM account_type ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbAccType.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void EditAccForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            if (_accViewForm!=null)
            {
                _accViewForm.Show();
            }
            else if (_userMainForm != null)
            {
                _userMainForm.Show();
            }
            else
            {
                _adminMainForm.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e) //Сохранить изменения
        {
            if (!string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text) && !string.IsNullOrEmpty(txtP.Text)
               && !string.IsNullOrEmpty(txtMail.Text) && _selectedPosit != "")
            {
                string name = txtLN.Text + " " + txtFN.Text + " " + txtP.Text;
                string type = _selectedPosit.Substring(0, _selectedPosit.IndexOf('.'));

                if (_accViewForm != null)
                {
                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    string sql = "UPDATE account SET FIO = @fio, mail = @em, id_account_type = @idAcc " +
                        "WHERE id_account = @id";
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    command.Parameters.AddWithValue("@fio", name);
                    command.Parameters.AddWithValue("@em", Convert.ToString(txtMail.Text));
                    command.Parameters.AddWithValue("@idAcc", type);
                    command.Parameters.AddWithValue("@id", _idAcc);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    MessageBox.Show("Изменения сохранены.");
                    this.Close();
                    _accViewForm.dgvAccs.Rows.Clear();
                    _accViewForm.OutputAccs();
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtLogin.Text)) //Проверка введенного логина и пароля
                    {
                        if (Convert.ToString(txtPassw1.Text) == Convert.ToString(txtPassw2.Text)) //Проверка на совпадение введенных паролей
                        {
                                //Хеширование пароля
                                string passw = Convert.ToString(txtPassw1.Text) + "ydVrg4c65baSks33mfQv0zP7dftm5";
                                byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(passw);
                                byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
                                string hashedPass = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                            
                            //Исправляем запись
                            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                            string sql = "UPDATE account SET FIO = @fio, mail = @em, id_account_type = @idAcc, login = @lg ";
                                if (txtPassw1.Text!="")
                            {
                                sql += ", password = @pass ";
                            }

                            sql += "WHERE id_account = @id";
                            MySqlCommand command = new MySqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@fio", name);
                            command.Parameters.AddWithValue("@em", Convert.ToString(txtMail.Text));
                            command.Parameters.AddWithValue("@idAcc", type);
                            command.Parameters.AddWithValue("@lg", Convert.ToString(txtLogin.Text));
                            if (txtPassw1.Text != "")
                            {
                                command.Parameters.AddWithValue("@pass", hashedPass);
                            }
                            
                            command.Parameters.AddWithValue("@id", _idAcc);

                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();

                            MessageBox.Show("Изменения сохранены.");
                            this.Close();
                            _adminMainForm.lblFIO.Text = _selectedPosit.Substring(_selectedPosit.IndexOf('.')+2, _selectedPosit.Length - 2- _selectedPosit.IndexOf('.')) +
                                ": " + name;
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
            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }
        }

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | Char.IsLetter(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtPassw1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 32) return;
            else
                e.Handled = true;
        }

        private void txtPassw2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 32) return;
            else
                e.Handled = true;
        }

        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = cmbAccType.SelectedItem.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }
    }
}
