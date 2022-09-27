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
using System.Web;
using System.IO;

namespace Proforientir
{
    public partial class StudViewForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private string _selectedPosit; //Выбранная ученая степень;
        private int _keyGrad; //Ключ "отображать только выпускников";

        public StudViewForm()
        {
            InitializeComponent();
        }

        public StudViewForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _selectedPosit = "";
            _keyGrad = 0;

            InitializeComponent();
        }

        public StudViewForm(AuthForm authForm, AdminMainForm adminMainForm, int k)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _selectedPosit = "";
            _keyGrad = k;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void StudViewForm_Load(object sender, EventArgs e) //Загрузка
        {
            if (_keyGrad ==1)
            {
                label1.Text = "Информация о выпускниках";
                labelStud.Text = "Все выпускники:";
                btnActiv.Visible = false;
                btnUpdate.Visible = false;
            }
            else
            {
                labelStud.Text = "Все студенты:";
            }
            OutputDegree(); //Вывод ученых степеней

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 50; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "ФИО"; //текст в шапке
            column1.Width = 300; //ширина колонки
            column1.Name = "FIO"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Год поступления";
            column2.Width = 100; //ширина колонки
            column2.Name = "Date1";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Средний балл";
            column3.Width = 100; //ширина колонки
            column3.Name = "Ex";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Ученая степень";
            column4.Width = 100; //ширина колонки
            column4.Name = "St";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Год окончания";
            column5.Width = 100; //ширина колонки
            column5.Name = "Date2";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            var column6 = new DataGridViewColumn();
            column6.HeaderText = "Год отчисления";
            column6.Width = 100; //ширина колонки
            column6.Name = "Date3";
            column6.CellTemplate = new DataGridViewTextBoxCell();

            dgvStud.Columns.Add(column0);
            dgvStud.Columns.Add(column1);
            dgvStud.Columns.Add(column2);
            dgvStud.Columns.Add(column3);
            dgvStud.Columns.Add(column4);
            dgvStud.Columns.Add(column5);
            dgvStud.Columns.Add(column6);

            dgvStud.EnableHeadersVisualStyles = false;
            dgvStud.ColumnHeadersDefaultCellStyle.Font = new Font(dgvStud.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16
            OutputStud(); //Выводим пользователей
        }

        private void OutputDegree() //Вывод ученых степеней
        {
            cmbDegr.Items.Add("0. все");
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

        public void OutputStud() //Выводим пользователей
        {
            DateTime date_now = DateTime.Today; //Дата сейчас
            int year_now = Convert.ToInt32(date_now.ToString().Substring(6, 4));

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT student.id_student, FIO, entrance, exam_score, name_degree, expulsion, ending " +
                "FROM account " +
                "JOIN student " +
               "ON account.id_account = student.id_account " +
               "JOIN degree " +
               "ON student.id_degree = degree.id_degree ";// +
              // "WHERE ending >= @year ";
            if (_keyGrad == 1)
            {
                sql += "WHERE ending <= @year ";
            }
            else
            {
                sql += "WHERE ending >= @year ";
            }

            if (_selectedPosit != "" && _selectedPosit != "0. все")
            {
                sql += "AND student.id_degree = @id ";

                if (txtFIO.Text != "")
                {
                    sql += "AND FIO LIKE @fio ";
                }
            }
            else if (txtFIO.Text != "")
            {
                sql += "AND FIO LIKE @fio ";
            }

           // sql += "ORDER BY entrance DESC ";

            if (_keyGrad == 1)
            {
                sql += "ORDER BY ending DESC ";
            }
            else
            {
                sql += "ORDER BY entrance DESC ";
            }

            // MessageBox.Show(sql);

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@year", MySqlDbType.VarChar).Value = year_now.ToString();
            if (_selectedPosit != "" && _selectedPosit != "0. все")
            {
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _selectedPosit.Substring(0, _selectedPosit.IndexOf('.'));

            }
            if (txtFIO.Text != "")
            {
                command.Parameters.Add("@fio", MySqlDbType.VarChar).Value = "%" + txtFIO.Text.ToString() + "%";
            }
            
            MySqlDataReader patrs = command.ExecuteReader();
            
            while (patrs.Read())
            {
                if (patrs[5].ToString() == "0" && patrs[6].ToString() == "0")
                {
                    dgvStud.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString(), "-", "-");
                }
                else if (patrs[5].ToString() != "0" && patrs[6].ToString() == "0")
                {
                    dgvStud.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString(), "-", patrs[5].ToString());
                }
                else if (patrs[5].ToString() == "0" && patrs[6].ToString() != "0")
                {
                    dgvStud.Rows.Add(patrs[0].ToString(), patrs[1].ToString(), patrs[2].ToString(), patrs[3].ToString(), patrs[4].ToString(), patrs[6].ToString(), "-");
                }

            }

            patrs.Close();
            conn.Close();

        }

        private void StudViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _adminMainForm.Show();
        }

        private void cmbDegr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = cmbDegr.SelectedItem.ToString();
            if (_selectedPosit != "0. все")
            {
                labelStud.Text = "Cтуденты - " + _selectedPosit.Substring(_selectedPosit.IndexOf('.') + 2, _selectedPosit.Length - _selectedPosit.IndexOf('.') - 2) + ":";
                if (_keyGrad == 1)
                {
                    labelStud.Text = "Выпускники - " + _selectedPosit.Substring(_selectedPosit.IndexOf('.') + 2, _selectedPosit.Length - _selectedPosit.IndexOf('.') - 2) + ":";
                }
            }
            else
            {
                labelStud.Text = "Все студенты:";
                if (_keyGrad == 1)
                {
                    labelStud.Text = "Все выпускники:";
                }
            }

            if (dgvStud.Rows != null)
            {
                dgvStud.Rows.Clear();
            }
            OutputStud(); //Выводим пользователей
        }

        private void btnUpdate_Click(object sender, EventArgs e) //Добавить нового
        {
            string path = "";
            string nameFile = @"..\..\path.txt";

            FileInfo file = new FileInfo(nameFile);
            if (file.Exists != false) //Если файл существует
            {
                StreamReader streamReader = new StreamReader(nameFile); //Открываем файл для чтения
                string str = ""; //Объявляем переменную, в которую будем записывать текст из файла

                while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                {
                    str = streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла

                    path = str;
                }
            }

            System.Diagnostics.Process.Start(path+"/www/bin/php/php5.6.40/php.exe", "C:/wamp/www/parseMAI.php");
            this.Hide();
            AddStudForm addStudForm = new AddStudForm(_authForm, _adminMainForm, this) { Visible = true }; //переход в форму добавления
        }
        
        private void btnSearch_Click(object sender, EventArgs e) //Поиск
        {
            if (txtFIO.Text != "")
            {
                if (dgvStud.Rows != null)
                {
                    dgvStud.Rows.Clear();
                }
                OutputStud(); //Выводим пользователей
            }
            else
            {
                MessageBox.Show("Необходимо ввести параметр для поиска.");
            }
        }

        private void btnUpd_Click(object sender, EventArgs e) //Изменить
        {
            if (_keyGrad == 1) //если отображали выпускников
            {
                if (dgvStud.CurrentRow.Cells[0].Value != null)
                {
                    this.Hide();
                    EditGradForm editGradForm = new EditGradForm(_authForm, _adminMainForm, this, Convert.ToInt32(dgvStud.CurrentRow.Cells[0].Value),
                        "Выпускник "+Convert.ToString(dgvStud.CurrentRow.Cells[5].Value) + ". " + Convert.ToString(dgvStud.CurrentRow.Cells[1].Value)) { Visible = true };  //Переход на форму редактирования информации о выпускнике
                }
                else
                {
                    MessageBox.Show("Сначала выберите выпускника из списка.");
                }
            }
            else
            {
                if (dgvStud.CurrentRow.Cells[0].Value != null)
                {
                    this.Hide();
                    EditStudForm editStudForm = new EditStudForm(_authForm, _adminMainForm, this, Convert.ToInt32(dgvStud.CurrentRow.Cells[0].Value)) { Visible = true }; //Переход на форму редактирования информации о студенте
                }
                else
                {
                    MessageBox.Show("Сначала выберите студента из списка.");
                }
            }
        }

        private void dgvStud_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvStud.Rows[dgvStud.CurrentRow.Index].Selected = true;
        }

        private void btnActiv_Click(object sender, EventArgs e) //Активность студента
        {
            try
            {
                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();
                string sql = "SELECT  student.id_account " +
                    "FROM student WHERE student.id_student = @id ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(dgvStud.CurrentRow.Cells[0].Value);

                MySqlDataReader posit = command.ExecuteReader();

                posit.Read();
                
                int id = Convert.ToInt32(posit[0]);

                posit.Close();
                conn.Close();

                this.Hide();
                AccEventForm accEventForm = new AccEventForm(_authForm, _adminMainForm, this, id, Convert.ToInt32(dgvStud.CurrentRow.Cells[0].Value)) { Visible = true }; //Переход на форму отображения мероприятий конкретного сотрудника
            }
            catch
            {
                MessageBox.Show("Выберите студента!");
                this.Show();
            }
        }
    }
}
