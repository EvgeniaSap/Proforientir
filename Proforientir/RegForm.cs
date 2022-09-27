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
    public partial class RegForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню для администратора;
        private EmplViewForm _emplViewForm; //Форма перечня сотрудников;
        private User _user; //Пользователь, загрузивший форму;
        private int _key; //Ключ с типом добавляемого пользователя
        private string _selectedPosit; //Выбранный тип пользователя

        public RegForm()
        {
            InitializeComponent();
        }

        public RegForm(AuthForm authForm, AdminMainForm adminMainForm, EmplViewForm emplViewForm, User user)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _emplViewForm = emplViewForm;
            _user = user;
            _key = 0;
            _selectedPosit = "";

            InitializeComponent();
        }

        public RegForm(AuthForm authForm, AdminMainForm adminMainForm, EmplViewForm emplViewForm, User user, int k)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _emplViewForm = emplViewForm;
            _user = user;
            _key = k;
            _selectedPosit = "";

            InitializeComponent();
        }
        
        private void btnBack_Click(object sender, EventArgs e) //Кнопка назад
        {
            this.Close();
            _emplViewForm.Show();
        }

        private void cmbAccType_SelectedIndexChanged(object sender, EventArgs e) //Выбор типа доступа
        {
            _selectedPosit = cmbAccType.SelectedItem.ToString();
        }
        
        private void btnSendInvit_Click(object sender, EventArgs e) //Отправить новому пользователю пригласительное письмо
        {
            if (!string.IsNullOrEmpty(txtLname.Text) && !string.IsNullOrEmpty(txtFname.Text) && !string.IsNullOrEmpty(txtPatron.Text)) //Проверка введенного ФИО
            {
                if (!string.IsNullOrEmpty(txtMail.Text)) //Проверка введенной почты 
                {
                    if (_selectedPosit != "") //Проверка выбранного типа
                    {
                        try
                        {
                            Random rnd = new Random();
                            //Получить очередное (в данном случае - первое) случайное число
                            int code = rnd.Next(10000, 99999);

                            string name = txtLname.Text + " " + txtFname.Text + " " + txtPatron.Text; //формируем строку с ФИО


                            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                            string sql = "INSERT INTO account (id_account_type,FIO,login,password,status,mail,activation) VALUES (@id,@name,@lg,@pass,@st,@em,@code)";

                            MySqlCommand command = new MySqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@id", _selectedPosit.Substring(0, _selectedPosit.IndexOf('.'))); //value combobox
                            command.Parameters.AddWithValue("@name", name);
                            command.Parameters.AddWithValue("@lg", Convert.ToString(""));
                            command.Parameters.AddWithValue("@pass", Convert.ToString(""));
                            command.Parameters.AddWithValue("@st", Convert.ToString(0));
                            command.Parameters.AddWithValue("@em", Convert.ToString(txtMail.Text));
                            command.Parameters.AddWithValue("@code", Convert.ToString(code));

                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();

                            try
                            {
                                SendMail new_mail = new SendMail(Convert.ToString(txtMail.Text), name);
                                new_mail.SendRegCode(code).GetAwaiter();
                                MessageBox.Show("Пользователю отправлено приглашение.");

                            }
                            catch
                            {
                                MessageBox.Show("Проверьте адрес электронной почты!");
                            }
                            
                            this.Close();
                            _emplViewForm.Show();
                            
                        }
                        catch
                        {
                            MessageBox.Show("Видимо что-то пошло не так. Проверьте введенный адрес.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите тип пользователя.");
                    }
                }
                else
                {
                    MessageBox.Show("Введите почту.");
                }
            }

            else
            {
                MessageBox.Show("Введите ФИО.");
            }
        
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_account_type, name_account_type " +
                "FROM account_type ";

            if (_key == 2)
            {
                sql += "WHERE id_account_type = @id";
            }
            
            MySqlCommand command = new MySqlCommand(sql, conn);

            if (_key == 2)
            {
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _key;
            }

            MySqlDataReader posit = command.ExecuteReader();
            

            while (posit.Read())
            {
                cmbAccType.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
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

        private void RegForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _emplViewForm.Show();
        }
    }
}
