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
    public partial class AddEventForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private AllEventsForm _allEventsForm; //Форма всех мероприятий;
        private string _selectedPositCat; //Выбранная категория;
        private string _selectedPositOrg; //Выбранный организатор;

        public AddEventForm()
        {
            InitializeComponent();
        }

        public AddEventForm(AuthForm authForm, AdminMainForm adminMainForm, AllEventsForm allEventsForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _allEventsForm = allEventsForm;
            _selectedPositCat = "";
            _selectedPositOrg = "";

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _allEventsForm.cmbCat.Items.Clear();
            _allEventsForm.OutputCmbCat();
        }

        private void AddEventForm_Load(object sender, EventArgs e)
        {
            OutputCmbOrg();
            OutputCmbCat();
        }

        public void OutputCmbOrg()
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_organizer, name_organizer " +
                "FROM organizer ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbOrg.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        public void OutputCmbCat()
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_category, name_category " +
                "FROM category ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbCat.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void AddEventForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _allEventsForm.Enabled = true;
        }

        private void btnAddOrg_Click(object sender, EventArgs e) //Добавить организатора
        {
            this.Enabled = false;
            AddOrgForm addOrgForm = new AddOrgForm(_authForm, _adminMainForm, this) { Visible = true }; //Открытие формы добавления организатора

        }

        private void btnAddCat_Click(object sender, EventArgs e) //Добавить категорию
        {
            this.Enabled = false;
            AddCatForm addCatForm = new AddCatForm(_authForm, _adminMainForm, this) { Visible = true }; //Открытие формы добавления категории
        }

        private void btnAddEvent_Click(object sender, EventArgs e) //Добавить мероприятие
        {
            if (!string.IsNullOrEmpty(txtName.Text) && _selectedPositOrg != "" && _selectedPositCat != "") //Проверка введенного 
            {
                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                conn.Open();
                string sql = "SELECT id_event, name_event, event.id_category, event.id_organizer " +
               "FROM organization_type " +
               "JOIN organizer " +
               "ON organization_type.id_organization_type = organizer.id_organization_type " +
                "JOIN event " +
               "ON organizer.id_organizer = event.id_organizer " +
                "JOIN category " +
               "ON event.id_category = category.id_category " +
               "WHERE name_event = @name AND event.id_category = @idC AND event.id_organizer = @idO";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Convert.ToString(txtName.Text);
                command.Parameters.Add("@idC", MySqlDbType.VarChar).Value = _selectedPositCat.Substring(0, _selectedPositCat.IndexOf('.'));
                command.Parameters.Add("@idO", MySqlDbType.VarChar).Value = _selectedPositOrg.Substring(0, _selectedPositOrg.IndexOf('.'));
                MySqlDataReader posit = command.ExecuteReader();

                try
                {
                    posit.Read();
                    posit[0].ToString();
                    MessageBox.Show("Такое мероприятие уже существует.");
                    posit.Close();
                    conn.Close();
                    txtName.Text = "";
                }
                catch
                {
                    posit.Close();
                    conn.Close();

                    conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    sql = "INSERT INTO event (name_event, id_category, id_organizer) VALUES (@name, @idC, @idO)";

                    command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@name", txtName.Text.ToString());
                    command.Parameters.AddWithValue("@idC", _selectedPositCat.Substring(0, _selectedPositCat.IndexOf('.')));
                    command.Parameters.AddWithValue("@idO", _selectedPositOrg.Substring(0, _selectedPositOrg.IndexOf('.')));
                   
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();

                    this.Close();
                    _allEventsForm.dataGridView1.Rows.Clear();
                    _allEventsForm.OutputAllEvent();
                    _allEventsForm.cmbCat.Items.Clear();
                    _allEventsForm.OutputCmbCat();
                }
                
            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }

        }

        private void cmbOrg_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositOrg = cmbOrg.SelectedItem.ToString();
        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositCat = cmbCat.SelectedItem.ToString();
        }
    }
}
