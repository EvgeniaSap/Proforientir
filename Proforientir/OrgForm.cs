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
    public partial class OrgForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;


        public OrgForm()
        {
            InitializeComponent();
        }

        public OrgForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            _adminMainForm.Show(); //Переход на форму всех мероприятий
        }

        private void OrgForm_Load(object sender, EventArgs e)
        {
            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID"; //текст в шапке
            column0.Width = 40; //ширина колонки
            column0.Name = "Id"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column0.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Название"; //текст в шапке
            column1.Width = 260; //ширина колонки
            column1.Name = "Name"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Тип организции";
            column2.Width = 143; //ширина колонки
            column2.Name = "Type";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputOrgs();
        }

        public void OutputOrgs() //Выводим в DataGridView новые значения
        {
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_organizer, name_organizer, name_organization_type " +
               "FROM organizer " +
               "JOIN organization_type " +
               "ON organizer.id_organization_type = organization_type.id_organization_type ";
            
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader date_event = command.ExecuteReader();
            
            while (date_event.Read())
            {
                dataGridView1.Rows.Add(date_event[0].ToString(), date_event[1].ToString(), date_event[2].ToString());
            }

            date_event.Close();
            conn.Close();
        }

        private void btnOrg_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddOrgForm addOrgForm = new AddOrgForm(_authForm, _adminMainForm, this) { Visible = true }; //Открытие формы добавления организатора
           
        }

        private void OrgForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _adminMainForm.Show(); //Переход на форму всех мероприятий
        }

        private void btnDel_Click(object sender, EventArgs e) //Удалить организатра
        {
            try
            {
                DialogResult result = MessageBox.Show(
                      "Вы уверены, что хотите удалить организатора?",
                      "Сообщение",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Information,
                      MessageBoxDefaultButton.Button1,
                      MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // MessageBox.Show(_tick[dataGridView1.CurrentRow.Index].ToString());
                        MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                        string sql = "DELETE FROM organizer WHERE id_organizer = @id";

                        MySqlCommand command = new MySqlCommand(sql, conn);
                        command.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
                        command.Connection.Open();
                        command.ExecuteNonQuery();
                        command.Connection.Close();

                        dataGridView1.Rows.Clear();
                        OutputOrgs();
                    }
                    catch 
                    {
                        MessageBox.Show("Невозможно удалить. Информация об организаторе используется для мероприятий.");
                    }
                }
                this.TopMost = true;

            }
            catch
            {
                MessageBox.Show("Выберите организатора!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }
    }
}
