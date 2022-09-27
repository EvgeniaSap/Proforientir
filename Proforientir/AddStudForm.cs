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
using System.IO;

namespace Proforientir
{
    public partial class AddStudForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private StudViewForm _studViewForm; //Форма просмотра студентов;
        private string _selectedPosit; //Выбранный временной интервал приказов;
        private string _selectedPositDeg; //Выбранная ученая степень;
        //string _selectedPositOrd; //Выбранный приказ;
        List<Order> _orders; //Список лет и связанные с ними приказы;
        private string _idAbit; //Индекс абитуриента;

        public AddStudForm()
        {
            InitializeComponent();
        }

        public AddStudForm(AuthForm authForm, AdminMainForm adminMainForm, StudViewForm studViewForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _studViewForm = studViewForm;
            _selectedPosit = "";
            _selectedPositDeg = "";
           // _selectedPositOrd = "";
            _orders = new List<Order>();

            InitializeComponent();
        }

        public class Order //Вложенный класс для хранения приказов за определенный год
        {
            public string Year_orders { set; get; } //Год приказов
            public Dictionary<string, string> Orders { set; get; } //Список приказов с ссылками на них

            public Order(string year)
            {
                Year_orders = year;
                Orders = new Dictionary<string, string>();
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void AddStudForm_Load(object sender, EventArgs e) //Загрузка
        {
            OutputDegree(); //Вывод ученых степеней
            string nameFile = @"C:\Users\PC\Documents\Visual Studio 2015\Projects\Proforientir\WebParse\pdfstud.txt";

            FileInfo file = new FileInfo(nameFile);
            if (file.Exists != false) //Если файл существует
            {
                StreamReader streamReader = new StreamReader(nameFile); //Открываем файл для чтения
                string str = ""; //Объявляем переменную, в которую будем записывать текст из файла
                int i = 0;
               
                while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                {
                    str = streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла

                    if (str.Substring(0, 21) == "Приказы о зачислении ")
                    {
                        _orders.Add(new Proforientir.AddStudForm.Order(str));
                        i++;
                    }
                    else
                    {
                        _orders[i-1].Orders.Add(str, streamReader.ReadLine());
                    }
                }
            }
            else MessageBox.Show("Файл отсутствует!");

            foreach (Order ord in _orders)
            {
                cmbOrdYear.Items.Add(ord.Year_orders);
            }

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название"; //текст в шапке
            column1.Width = 800; //ширина колонки
            column1.Name = "Event"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            dgvOrds.Columns.Add(column1);
            dgvOrds.EnableHeadersVisualStyles = false;
            dgvOrds.ColumnHeadersDefaultCellStyle.Font = new Font(dgvOrds.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "ID"; //текст в шапке
            column2.Width = 50; //ширина колонки
            column2.Name = "Id"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column2.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column31 = new DataGridViewColumn();
            column31.HeaderText = "Фамилия"; //текст в шапке
            column31.Width = 100; //ширина колонки
            column31.Name = "F"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column31.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column32 = new DataGridViewColumn();
            column32.HeaderText = "Имя"; //текст в шапке
            column32.Width = 100; //ширина колонки
            column32.Name = "I"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column32.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column33 = new DataGridViewColumn();
            column33.HeaderText = "Отчество"; //текст в шапке
            column33.Width = 100; //ширина колонки
            column33.Name = "O"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column33.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "Дата регистрации"; //текст в шапке
            column4.Width = 70; //ширина колонки
            column4.Name = "Date"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column4.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "Город рождения"; //текст в шапке
            column5.Width = 70; //ширина колонки
            column5.Name = "Town"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column5.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            

            dgvAbit.Columns.Add(column2);
            dgvAbit.Columns.Add(column31);
            dgvAbit.Columns.Add(column32);
            dgvAbit.Columns.Add(column33);
            dgvAbit.Columns.Add(column4);
            dgvAbit.Columns.Add(column5);

            dgvAbit.EnableHeadersVisualStyles = false;
            dgvAbit.ColumnHeadersDefaultCellStyle.Font = new Font(dgvAbit.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16
            OutputAbit(); //Вывод абитуриентов
        }

        private void AddStudForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _studViewForm.Show();
        }

        private void cmbOrdYear_SelectedIndexChanged(object sender, EventArgs e) //Выбор года
        {
            _selectedPosit = cmbOrdYear.SelectedItem.ToString();
           
            if (dgvOrds.Rows != null)
            {
                dgvOrds.Rows.Clear();
            }
            OutputOrds(); //Выводим приказы
            txtYear.Text = _selectedPosit.Substring(_selectedPosit.IndexOf('2'),4);
        }

        private void OutputOrds() //Вывод названий приказов
        {
            foreach (Order yord in _orders)
            {
                if (yord.Year_orders == _selectedPosit)
                {
                    foreach (KeyValuePair<string, string> ord in yord.Orders)
                    {
                        dgvOrds.Rows.Add(ord.Key);
                    }

                }
            }
        }
        
        private void btnAddStud_Click(object sender, EventArgs e) //Добавить информацию о студенте
        {
            if (!string.IsNullOrEmpty(txtFN.Text) && !string.IsNullOrEmpty(txtLN.Text) && !string.IsNullOrEmpty(txtP.Text)
                && !string.IsNullOrEmpty(txtEx.Text) && !string.IsNullOrEmpty(txtYear.Text) && _selectedPositDeg !="" ) //Проверка введенного 
            {
                try
                {
                    int ex = Convert.ToInt32(txtEx.Text);
                    int year = Convert.ToInt32(txtYear.Text);
                    string name = txtLN.Text + " " + txtFN.Text + " " + txtP.Text;
                    string degr = _selectedPositDeg.Substring(0, _selectedPositDeg.IndexOf('.'));
                    int year_end = 0;
                    //DateTime date_now = DateTime.Today; //Дата сейчас
                    // int year_now = Convert.ToInt32(date_now.ToString().Substring(6, 4));

                    if (degr == "1") //бакалавр
                    {
                        year_end = year + 4;

                    }
                    else if (degr == "2") //магистр
                    {
                        year_end = year + 2;
                    }
                    else //аспирант
                    {
                        year_end = year + 3;
                    }
                     

                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();


                    string sql = "SELECT student.id_account, id_account_type, FIO, exam_score, entrance, id_degree " +
                        "FROM account " +
                         "JOIN student " +
                         "ON account.id_account = student.id_account " +
                            "WHERE FIO = @name AND exam_score = @ex AND entrance = @ye AND id_account_type = @id AND id_degree =  @degr";
                    
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("@ex", MySqlDbType.VarChar).Value = ex.ToString();
                    command.Parameters.Add("@ye", MySqlDbType.VarChar).Value = year.ToString();
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = 3;
                    command.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;
                    MySqlDataReader stud = command.ExecuteReader();
                    

                    try
                    {
                        stud.Read();
                        stud[0].ToString();
                        MessageBox.Show("Информация о студенте уже есть в системе.");
                        stud.Close();
                        conn.Close();
                        txtFN.Text = "";
                        txtLN.Text = "";
                        txtP.Text = "";
                        txtEx.Text = "";
                    }
                    catch
                    {
                        stud.Close();
                        conn.Close();

                        conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        sql = "INSERT INTO account (id_account_type, FIO, login, password, status, mail, activation) VALUES (@id, @name, @lg, @pass, @st, @em, @activ)";

                        command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue("@id", 3);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@lg", "");
                        command.Parameters.AddWithValue("@pass", "");
                        command.Parameters.AddWithValue("@st", 0);
                        command.Parameters.AddWithValue("@em", "");
                        command.Parameters.AddWithValue("@activ", "0");

                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                        conn.Open();
                        
                        sql = "SELECT id_account, id_account_type, FIO " +
                            "FROM account " +
                             "WHERE FIO = @name AND id_account_type = @id ";

                        command = new MySqlCommand(sql, conn);
                        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = 3;
                        stud = command.ExecuteReader();
                        stud.Read();
                        string id_new = stud[0].ToString();
                        stud.Close();
                        conn.Close();

                        conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        sql = "INSERT INTO student (id_account, id_degree, exam_score, entrance, expulsion, ending) VALUES (@id1, @id2, @ex, @1, @2, @3)";

                        command = new MySqlCommand(sql, conn);

                        command.Parameters.AddWithValue("@id1", id_new);
                        command.Parameters.AddWithValue("@id2", degr);
                        command.Parameters.AddWithValue("@ex", ex.ToString());
                        command.Parameters.AddWithValue("@1", year);
                        command.Parameters.AddWithValue("@2", 0);
                        command.Parameters.AddWithValue("@3", year_end);

                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        if (dgvAbit.CurrentRow.Cells[0].Value != null && 
                                (_idAbit !="" || (txtFN.Text == dgvAbit.CurrentRow.Cells[2].Value.ToString() && txtLN.Text == dgvAbit.CurrentRow.Cells[1].Value.ToString() &&
                            txtP.Text == dgvAbit.CurrentRow.Cells[3].Value.ToString())))
                        {
                            if (_idAbit == "")
                            {
                                _idAbit = dgvAbit.CurrentRow.Cells[0].Value.ToString();
                            }

                            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                            conn.Open();

                            sql = "SELECT id_student " +
                                "FROM student " +
                                 "ORDER BY id_student DESC ";

                            command = new MySqlCommand(sql, conn);
                            stud = command.ExecuteReader();
                            stud.Read();
                            string id_stud = stud[0].ToString();
                            stud.Close();
                            conn.Close();

                            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                            sql = "INSERT INTO stud_enroll (id_student, idPerson) VALUES (@id1, @id2)";

                            command = new MySqlCommand(sql, conn);

                            command.Parameters.AddWithValue("@id1", id_stud);
                            command.Parameters.AddWithValue("@id2", _idAbit);

                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();

                        }


                        // MessageBox.Show("Студент успешно добавлен.");

                        DialogResult result = MessageBox.Show(
                      "Студент успешно добавлен. Вернуться к списку студентов?",
                      "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                            _studViewForm.dgvStud.Rows.Clear();
                            _studViewForm.OutputStud();
                        }
                        else
                        {
                            txtFN.Text = "";
                            txtLN.Text = "";
                            txtP.Text = "";
                            txtEx.Text = "";
                        }
                        this.TopMost = true;
                        
                    }
                }
                catch
                {
                    MessageBox.Show("Убедитесь, что указали верные параметы.");
                }
            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }
        }

        private void OutputDegree() //Вывод ученых степеней
        {
            //cmbDegr.Items.Add("0. все");
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

        private void OutputAbit() //Вывод абитуриентов
        {
            if (dgvAbit.Rows != null)
            {
                dgvAbit.Rows.Clear();
            }

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT idPerson, LastName, FirstName, MiddleName, CreateDate, BirthPlace " +
                "FROM person ";
              //  "JOIN personcontacts " +
             //   "ON person.idPerson = personcontacts.PersonID ";
                //"WHERE Value LIKE '%@%' OR Value2 LIKE '%@%' ";

            if (txtAbit.Text!="")
            {
                sql += "WHERE LastName LIKE @l OR FirstName LIKE @f OR MiddleName LIKE @m ";
            }

            sql += "ORDER BY CreateDate DESC ";

            MySqlCommand command = new MySqlCommand(sql, conn);

            if (txtAbit.Text != "")
            {
                command.Parameters.Add("@l", MySqlDbType.VarChar).Value = "%" + txtAbit.Text.ToString() + "%";
                command.Parameters.Add("@f", MySqlDbType.VarChar).Value = "%" + txtAbit.Text.ToString() + "%";
                command.Parameters.Add("@m", MySqlDbType.VarChar).Value = "%" + txtAbit.Text.ToString() + "%";
            }

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                dgvAbit.Rows.Add(Convert.ToString(posit[0]), Convert.ToString(posit[1]), Convert.ToString(posit[2]),
                    Convert.ToString(posit[3]), Convert.ToString(posit[4]), Convert.ToString(posit[5]));
            }

            posit.Close();
            conn.Close();
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

        private void cmbDegr_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositDeg = cmbDegr.SelectedItem.ToString();
        }

        private void dgvOrds_CellClick(object sender, DataGridViewCellEventArgs e) //Выбор конкретного приказа
        {
            dgvOrds.Rows[dgvOrds.CurrentRow.Index].Selected = true;


            string _selectedPositOrd = dgvOrds.CurrentRow.Cells[0].Value.ToString();
            string url = "";
            foreach (Order yord in _orders)
            {
                if (yord.Year_orders == _selectedPosit)
                {
                    url = yord.Orders[_selectedPositOrd]; //Поиск ссылки на выбранный приказ
                }
            }
            System.Diagnostics.Process.Start(url);
        }

        private void dgvAbit_CellClick(object sender, DataGridViewCellEventArgs e) //Выбор абитуриента
        {
            dgvAbit.Rows[dgvAbit.CurrentRow.Index].Selected = true;

            txtLN.Text = dgvAbit.CurrentRow.Cells[1].Value.ToString();
                txtFN.Text = dgvAbit.CurrentRow.Cells[2].Value.ToString();
            txtP.Text = dgvAbit.CurrentRow.Cells[3].Value.ToString();

            _idAbit = dgvAbit.CurrentRow.Cells[0].Value.ToString();
        }

        private void txtLN_TextChanged(object sender, EventArgs e) //Изменение текста
        {
            _idAbit = "";
        }

        private void txtFN_TextChanged(object sender, EventArgs e)
        {
            _idAbit = "";
        }

        private void txtP_TextChanged(object sender, EventArgs e)
        {
            _idAbit = "";
        }

        private void btnSearch_Click(object sender, EventArgs e) //Поиск
        {
            OutputAbit(); //Вывод абитуриентов
        }
    }
}
