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
    public partial class EditStudForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private StudViewForm _studViewForm; //Форма просмотра всех студентов;
        private int _idStud; //Индекс редактируемого студента;
        private int _idAcc; //Индекс связанного аккаунта;
        private string _selectedPosit; //Выбранная ученая степень;
        private int _grad; //Студент - выпускник;
        private int _idGrad; //Индекс выпускника;

        public EditStudForm()
        {
            InitializeComponent();
        }

        public EditStudForm(AuthForm authForm, AdminMainForm adminMainForm, StudViewForm studViewForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _studViewForm = studViewForm;
            _idStud = id;
            _grad = 0;
            _idGrad = 0;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void EditStudForm_Load(object sender, EventArgs e) //Загрузка формы
        {
            OutputDegree(); //Вывод ученых степеней

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT FIO, mail, id_degree, exam_score, entrance, expulsion, ending, student.id_account " +
                "FROM student "+
                "JOIN account "+
                "ON student.id_account = account.id_account "+
                "WHERE id_student = @id ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idStud.ToString();
            MySqlDataReader posit = command.ExecuteReader();

            posit.Read();
            string fio = Convert.ToString(posit[0]);
            txtLN.Text = fio.Substring(0, fio.IndexOf(" "));
            fio = fio.Substring(fio.IndexOf(" ")+1, fio.Length - 1 - fio.IndexOf(" "));
            txtFN.Text = fio.Substring(0, fio.IndexOf(" "));
          fio = fio.Substring(fio.IndexOf(" ") + 1, fio.Length - 1 - fio.IndexOf(" "));
            txtP.Text = fio;

            txtMail.Text = Convert.ToString(posit[1]);
            _idAcc = Convert.ToInt32(posit[7]);

            txtEx.Text= Convert.ToString(posit[3]);
            txtYear.Text = Convert.ToString(posit[4]);

            if (Convert.ToString(posit[5]) != "0")
            {
               txtDel.Text = Convert.ToString(posit[5]);
            }

            txtEnd.Text = Convert.ToString(posit[6]);

            cmbDegr.SelectedItem = cmbDegr.Items[Convert.ToInt32(Convert.ToString(posit[2]))-1];

            posit.Close();
            conn.Close();


            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            sql = "SELECT id_graduate " +
                "FROM graduate " +
                "WHERE id_student = @id ";
            command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idStud.ToString();
            posit = command.ExecuteReader();

            posit.Read();

           try
            {
                _idGrad = Convert.ToInt32(Convert.ToString(posit[0]));
                checkBox1.Checked = true;
            }
            catch
            {
                checkBox1.Checked = false;
                _grad = 0;
            }

            posit.Close();
            conn.Close();


        }

        private void OutputYearEnd() //Вывод года окончания
        {
            string degr = _selectedPosit.Substring(0, _selectedPosit.IndexOf('.'));
            int year = Convert.ToInt32(txtYear.Text);
            //int year_end = 0;

            if (degr == "1") //бакалавр
            {
                txtEnd.Text = (year + 4).ToString();

            }
            else if (degr == "2") //магистр
            {
                txtEnd.Text = (year + 2).ToString();
            }
            else //аспирант
            {
                txtEnd.Text = (year + 3).ToString();
            }
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

        private void EditStudForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _studViewForm.Show();
        }

        private void cmbDegr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = cmbDegr.SelectedItem.ToString();
            OutputYearEnd(); //Вывод года окончания
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //Выпускник
        {
            if (_grad == 1)
            {
                _grad = 0;
            }
            else
            {
                _grad = 1;
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

        private void txtEx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void txtDel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) | e.KeyChar == 8) return;
            else
                e.Handled = true;
        }

        private void btnAddStud_Click(object sender, EventArgs e) //Сохранить изменения
        {
            OutputYearEnd(); //Вывод года окончания

            if (!string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text) && !string.IsNullOrEmpty(txtP.Text)
                && !string.IsNullOrEmpty(txtEx.Text) && !string.IsNullOrEmpty(txtYear.Text) && 
                _selectedPosit != "")
            {
                string name = txtLN.Text + " " + txtFN.Text + " " + txtP.Text;
                string degr = _selectedPosit.Substring(0, _selectedPosit.IndexOf('.'));
                int year = Convert.ToInt32(txtYear.Text);
                DateTime date_now = DateTime.Today; //Дата сейчас
                 int year_now = Convert.ToInt32(date_now.ToString().Substring(6, 4));
                if (year > 2000 && year <= year_now)
                {
                    if (txtDel.Text != "")
                    {
                        int yearDel = Convert.ToInt32(txtDel.Text);
                        if (yearDel >= year && yearDel <= Convert.ToInt32(txtEnd.Text))
                        {

                            saveChanges(name, degr, year, yearDel);
                        }
                        else
                        {
                            MessageBox.Show("Проверьте введенный год отчисления.");
                        }
                    }
                    else
                    {
                        saveChanges(name, degr, year, 0);


                    }
                }
                else
                {
                    MessageBox.Show("Проверьте введенный год поступления.");
                }


            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }


        }

        private void saveChanges(string name, string degr, int year, int yearDel)
        {

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            string sql = "UPDATE account SET FIO = @fio, mail = @em " +
                "WHERE id_account = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("@fio", name);
            command.Parameters.AddWithValue("@em", Convert.ToString(txtMail.Text));
            command.Parameters.AddWithValue("@id", _idAcc);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            sql = "UPDATE student SET id_degree = @degr, exam_score = @ex, entrance = @y1, expulsion = @y2, ending = @y3 " +
                "WHERE id_student = @id";
            command = new MySqlCommand(sql, conn);

            command.Parameters.AddWithValue("@degr", degr);
            command.Parameters.AddWithValue("@ex", Convert.ToString(txtEx.Text));
            command.Parameters.AddWithValue("@y1", year);
            command.Parameters.AddWithValue("@y2", yearDel);
            command.Parameters.AddWithValue("@y3", txtEnd.Text);
            command.Parameters.AddWithValue("@id", _idStud);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            if (_grad == 1 && _idGrad == 0)
            {
                conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                sql = "INSERT INTO graduate (id_student, job) VALUES (@id, @name)";

                command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", _idStud);
                command.Parameters.AddWithValue("@name", 2);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            MessageBox.Show("Изменения сохранены.");
        }
    }
}
