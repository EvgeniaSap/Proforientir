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
    public partial class AddCatForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        //private AllEventsForm _allEventsForm; //Форма всех мероприятий;
        private AddEventForm _addEventForm; //Форма добавления мероприятия;
        private string _selectedPosit; //Выбранная категория;

        public AddCatForm()
        {
            InitializeComponent();
        }

        public AddCatForm(AuthForm authForm, AdminMainForm adminMainForm, AddEventForm addEventForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _addEventForm = addEventForm;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _addEventForm.Enabled = true; //Переход на форму добавления нового мероприятия
            _addEventForm.cmbCat.Items.Clear();
            _addEventForm.OutputCmbCat(); 
        }

        private void AddCatForm_Load(object sender, EventArgs e)
        {
            OutputCateg(); 
        }

        private void OutputCateg() //Вывод категорий в listbox
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_category, name_category " +
                "FROM category ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                lbCat.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void AddCatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _addEventForm.Enabled = true; //Возвращение к форме добавления мероприятия
        }

        private void btnAddCat_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCName.Text)) //Проверка введенного названия
            {
                bool eqName = false;
                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();
                string sql = "SELECT  name_category " +
                    "FROM category ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader posit = command.ExecuteReader();

                while (posit.Read())
                {
                    if (Convert.ToString(posit[0]) == txtCName.Text.ToString())
                    {
                        eqName = true;
                    }
                }
                posit.Close();
                conn.Close();


                if (eqName == false)
                {
                    conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    sql = "INSERT INTO category (name_category) VALUES (@name)";

                    command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@name", txtCName.Text.ToString());

                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    lbCat.Items.Clear();
                    OutputCateg();
                }
                else
                {
                    MessageBox.Show("Категория с таким названием уже существует.");
                }
            }
            else
            {
                MessageBox.Show("Введите название новой категории.");
            }
            txtCName.Text = "";
        }

        private void lbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = lbCat.SelectedItem.ToString();
        }
    }
}
