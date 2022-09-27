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
    public partial class EditGradForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private StudViewForm _studViewForm; //Форма отображения выпускников;
        private int _idStud; //Индекс студента;
        private string _name; //Текст для лейбла;
        private int _update; //Параметр для обновления записи в бд;

        public EditGradForm()
        {
            InitializeComponent();
        }

        public EditGradForm(AuthForm authForm, AdminMainForm adminMainForm, StudViewForm studViewForm, int id, string str)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _studViewForm = studViewForm;
            _idStud = id;
            _name = str;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void EditGradForm_Load(object sender, EventArgs e) //Загрузка
        {
            labelName.Text = _name;
            radioButtonT.Tag = 1;
            radioButtonF.Tag = 0;
            radioButtonUn.Tag = 2;

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT job " +
                "FROM graduate WHERE id_student = @id";
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idStud;

            MySqlDataReader posit = command.ExecuteReader();

            try
            {
                posit.Read();

                if (Convert.ToInt32(posit[0]) == Convert.ToInt32(radioButtonT.Tag))
                {
                    radioButtonT.Checked = true;
                }
                else if(Convert.ToInt32(posit[0]) == Convert.ToInt32(radioButtonF.Tag))
                {
                    radioButtonF.Checked = true;
                }
                else if (Convert.ToInt32(posit[0]) == Convert.ToInt32(radioButtonUn.Tag))
                {
                    radioButtonUn.Checked = true;
                }
                _update = 1;
                posit.Close();
                conn.Close();
            }
            catch
            {
                _update = 0;
                posit.Close();
                conn.Close();
            }
    
        }

        private int enterDisp(GroupBox group) //Возвращает значение выбранного элемента GroupBox;
        {
            foreach (Control control in group.Controls)
            {
                if (((RadioButton)control).Checked)
                {
                    return int.Parse(control.Tag.ToString());
                }
            }
            return -1;
        }

        private void EditGradForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _studViewForm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e) //Сохранить изменения
        {
            int job = enterDisp(gbGrad);
            if (job != -1)
            {
                if (_update == 0) //вставить новую запись
                {
                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    string sql = "INSERT INTO graduate (id_student, job) VALUES (@id, @jj)";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@id", _idStud);
                    command.Parameters.AddWithValue("@jj", job);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
                else //обновить имеющуюся
                {
                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    string sql = "UPDATE graduate SET job = @jj " +
                        "WHERE id_student = @id";
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    command.Parameters.AddWithValue("@jj", job);
                    command.Parameters.AddWithValue("@id", _idStud);

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }

                MessageBox.Show("Изменения сохранены.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Выберите информацию о работе выпускника!");
            }
        }
    }
}
