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
    public partial class AddEntryShedForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private ScheduleForm _scheduleForm; //Форма полного расписания;
        private AllEventsForm _allEventsForm; //Форма всех мероприятий;
        private Event _eventToAdd; //Мероприятие из перечня;
        private string _selectedPositС; //Выбранная дата;
        private string _selectedPositH; //Выбранные часы;
        private string _selectedPositM; //Выбранные минуты;

        public AddEntryShedForm()
        {
            InitializeComponent();
        }

        public AddEntryShedForm(AuthForm authForm, AdminMainForm adminMainForm, ScheduleForm scheduleForm, AllEventsForm allEventsForm, Event ev)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _scheduleForm = scheduleForm;
            _allEventsForm = allEventsForm;
            _eventToAdd = ev;
            _selectedPositС = "";
            _selectedPositH = "";
            _selectedPositM = "";
            
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void AddEntryShedForm_Load(object sender, EventArgs e) //Загрузка
        {
            labelEv.Text += " "+ _eventToAdd.Category + " '" + _eventToAdd.Name_event + "' \n" +
                 "Организатор " + _eventToAdd.Name_organizer;

            for (int i = 0; i < 60; i++) //Заполняем время
            {
                if (i < 10)
                {
                    cmbM.Items.Add("0" + i);
                }
                else
                {
                    cmbM.Items.Add(i.ToString());
                }
                i = i + 4;
            }
            for (int i = 8; i < 21; i++)
            {
                if (i < 10)
                {
                    cmbH.Items.Add("0" + i);
                }
                else
                {
                    cmbH.Items.Add(i.ToString());
                }
            }

        }

        private void AddEntryShedForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _allEventsForm.Show();
        }

        private void btnNewEntry_Click(object sender, EventArgs e) //Добавить в расписание
        {
            if (_selectedPositС != "" && _selectedPositH != "" && _selectedPositM != "")
            {
                string date = _selectedPositС.Substring(6, 4)+"."+ _selectedPositС.Substring(3, 2) + "." + _selectedPositС.Substring(0, 2);
                string time = _selectedPositH + ":" + _selectedPositM;

                MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                //conn.Open();
                string sql = "INSERT INTO action_plan (id_event, date_event, time_event) VALUES (@id, @date, @time)";

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@id", _eventToAdd.Id_event.ToString());
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@time", time);

                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
                
                this.Close();

                _scheduleForm.dgvEvents.Rows.Clear();
                _scheduleForm.OutputEvents();
                
            }
            else
            {
                MessageBox.Show("Убедитесь, что указали все необходимые параметры.");
            }
        }

        private void mCalendar_DateSelected(object sender, DateRangeEventArgs e) //Календарь
        {
            _selectedPositС = e.End.ToString();
          //  MessageBox.Show(_selectedPositС.Substring(0, 10));
        }

        private void cmbH_SelectedIndexChanged(object sender, EventArgs e) //Часы
        {
            _selectedPositH = cmbH.SelectedItem.ToString();
        }

        private void cmbM_SelectedIndexChanged(object sender, EventArgs e) //Минуты
        {
            _selectedPositM = cmbM.SelectedItem.ToString();
        }
    }
}
