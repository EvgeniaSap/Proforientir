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
    public partial class AddOrgForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private OrgForm _orgForm; //Форма перечня мероприятий;
        private AddEventForm _addEventForm; //Форма добавления нового организатора
        private string _selectedPosit; //Выбранный тип организатора;


        public AddOrgForm()
        {
            InitializeComponent();
        }

        public AddOrgForm(AuthForm authForm, AdminMainForm adminMainForm, OrgForm orgForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _orgForm = orgForm;
            _selectedPosit = "";

            InitializeComponent();
        }

        public AddOrgForm(AuthForm authForm, AdminMainForm adminMainForm, AddEventForm addEventForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _addEventForm = addEventForm;
            _selectedPosit = "";

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void AddOrgForm_Load(object sender, EventArgs e) //Загрузка
        {
            cmbType.Items.Add("");
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_organization_type, name_organization_type " +
                "FROM organization_type ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbType.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void AddOrgForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            if (_orgForm!=null)
            {
                _orgForm.Enabled = true; //Переход на форму перечня организаторов
            }
            else if (_addEventForm != null)
            {
                _addEventForm.Enabled = true; //Переход на форму добавления нового мероприятия
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPosit = cmbType.SelectedItem.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e) //Добавление нового организатора
        {
            if (!string.IsNullOrEmpty(txtName.Text)) //Проверка введенного названия
            {
                if (!string.IsNullOrEmpty(txtType.Text) && _selectedPosit != "")
                {
                    MessageBox.Show("Определитесь с типом организатора.");
                    txtType.Text = "";
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtType.Text))
                    {
                        int compareResult = 0;
                        foreach (string s in cmbType.Items)
                        {
                            if (s != "")
                            {
                                int id = s.IndexOf('.') + 2;
                                string str = s.Substring(id, s.Length - id);
                                compareResult = String.Compare(txtType.Text.ToString(), str, StringComparison.OrdinalIgnoreCase);
                                //txtType.Text == s.Substring(_selectedPosit.IndexOf('.') + 2, s.Length - 1))
                                if (compareResult == 0)
                                {
                                    MessageBox.Show("Вы ввели уже существующий тип.");
                                    txtType.Text = "";
                                    _selectedPosit = s;
                                }
                            }
                        }

                        if(_selectedPosit != "")
                        {
                            AddOrg(_selectedPosit.Substring(0, _selectedPosit.IndexOf('.')));
                        }
                        else
                        {
                            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                            string sql = "INSERT INTO organization_type (name_organization_type) " +
                                           "VALUES (@name)";

                            MySqlCommand command = new MySqlCommand(sql, conn);
                            command.Parameters.AddWithValue("@name", txtType.Text.ToString());

                            command.Connection.Open();
                            command.ExecuteNonQuery();
                            command.Connection.Close();
                            MessageBox.Show("Добавлен новый тип организатора.");

                            conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                            conn.Open();

                            sql = "SELECT id_organization_type " +
                                "FROM organization_type " +
                                "WHERE name_organization_type = @name";

                            command = new MySqlCommand(sql, conn);
                            command.Parameters.AddWithValue("@name", txtType.Text.ToString());
                            MySqlDataReader type = command.ExecuteReader();
                            type.Read();
                            string newtype = Convert.ToString(type[0]);
                            
                            type.Close();
                            conn.Close();
                            AddOrg(newtype);
                        }
                    }
                    else if (_selectedPosit != "")
                    {
                        AddOrg(_selectedPosit.Substring(0, _selectedPosit.IndexOf('.')));
                    }
                    else
                    {
                        MessageBox.Show("Введите или выберите тип.");
                    }

                }

            }
            else
            {
                MessageBox.Show("Введите название организации.");
            }
        }

        private void AddOrg(string type) //Добавление организатора в бд
        {
            bool eqName = false;
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  name_organizer " +
                "FROM organizer ";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                if (Convert.ToString(posit[0]) == txtName.Text.ToString())
                {
                    eqName = true;
                }
             }
            posit.Close();
            conn.Close();


            if(eqName == false)
            {
                conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                sql = "INSERT INTO organizer (name_organizer, id_organization_type) " +
                               "VALUES (@name, @id)";

                command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", txtName.Text.ToString());
                command.Parameters.AddWithValue("@id", type);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();

                MessageBox.Show("Организатор успешно добавлен.");


                if (_orgForm != null)
                {
                    this.Close();
                    _orgForm.Enabled = true; //Переход на форму перчня организаторов
                    _orgForm.dataGridView1.Rows.Clear();
                    _orgForm.OutputOrgs();
                }
                else if (_addEventForm != null)
                {
                    this.Close();
                    _addEventForm.Enabled = true; //Переход на форму добавления нового мероприятия
                    _addEventForm.cmbOrg.Items.Clear();
                    _addEventForm.OutputCmbOrg();
                }
               
            }
            else
            {
                MessageBox.Show("Организатор с таким именем уже существует.");
            }
        }
    }
}
