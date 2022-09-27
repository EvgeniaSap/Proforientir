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
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Download;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Web;

namespace Proforientir
{
    public partial class AdminMainForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private User _user; //Пользователь, загрузивший форму;

        public AdminMainForm()
        {
            InitializeComponent();
        }

        public AdminMainForm(AuthForm authForm, User user) //Переход с формы авторизации
        {
            _authForm = authForm;
            _user = user;

            InitializeComponent();
        }
        
        private void сотрудникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmplViewForm empl_view = new EmplViewForm(_authForm, this, _user) { Visible = true }; //Открываем форму для просмотра сотрудников

        }

        private void студентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudViewForm studViewForm = new StudViewForm(_authForm, this) { Visible = true }; //Открываем форму для просмотра всех студентов
        }

        private void выпускникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudViewForm studViewForm = new StudViewForm(_authForm, this, 1) { Visible = true }; //Открываем форму для просмотра студентов, но с ключом "выпускники"
        }

        private void всеПользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccViewForm фccViewFormm = new AccViewForm(_authForm, this) { Visible = true }; //Открываем форму для просмотра пользователей
   }

        private void переченьВсехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllEventsForm allEventsForm = new AllEventsForm(_authForm, this) { Visible = true }; //Открываем форму для просмотра перечня всех меропниятий
        }

        private void планПроведенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ScheduleForm sched = new ScheduleForm(_authForm, this) { Visible = true }; //Открываем форму для просмотра плана проведения

        }

        private void организаторыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrgForm org = new OrgForm(_authForm, this) { Visible = true }; //Открываем форму с организаторами мероприятий
        }

        private void результатыАнкетированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List<GoogleDriveFiles> _files = new List<GoogleDriveFiles>(); //Все файлы с диска;

            DriveService service = GoogleDriveFilesRepository.GetService();

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, webViewLink)";

            //get file list. все файлы
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            //List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Name == "Анкетирование 2020")
                    {
                        //dgvFiles.Rows.Add(file.Id, file.Name, file.Size, file.CreatedTime);
                        // MessageBox.Show(file.Name + " (" + file.WebViewLink + ")");
                        //System.Diagnostics.Process.Start(file.WebViewLink);
                        System.Diagnostics.Process.Start("https://docs.google.com/forms/d/1Zqgesfd1YzvdamTEu1RXAD_7R6zGAGicJhGT2nDnDNU/edit#responses");
                    }
                }
            }
            else
            {
                MessageBox.Show("Файлы не найдены.");
            }

        }
        
        private void статистикаОСтудентахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudStatForm studStatForm = new StudStatForm(_authForm, this) { Visible = true }; //Открываем форму со статистикой
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
             this.Close();
          
            _authForm.Visible = true; //Переход на форму авторизации
        }

        private void AdminMainForm_Load(object sender, EventArgs e) //Загрузка формы
        {
            lblFIO.Text = _user.Name_acc_level + ": " + _user.Full_name;

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 50; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Мероприятие"; //текст в шапке
            column1.Width = 300; //ширина колонки
                                                //column1.ReadOnly = true; //значение в этой колонке нельзя править
            column1.Name = "Event"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
                                    //column1.Frozen = true; //флаг, что данная колонка всегда отображается на своем месте
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки
            
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Дата и время";
            column2.Width = 170; //ширина колонки
            column2.Name = "DateT";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputPlanEvent();
        }

        private void OutputPlanEvent() //Выводим в DataGridView новые значения
        {
            DateTime date_now = DateTime.Today; //Дата сейчас

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT id_action_plan, action_plan.id_event, date_event, name_event, time_event " +
               "FROM action_plan " +
               "JOIN event " +
               "ON action_plan.id_event = event.id_event " +
               "WHERE date_event >= @date "+
               "ORDER BY date_event, time_event";

            string date_n = Convert.ToString(date_now).Substring(0, 10);
            string date = date_n.Substring(6, 4) + "." + date_n.Substring(3, 2) + "." + date_n.Substring(0, 2);
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date;


            MySqlDataReader date_event = command.ExecuteReader();


            while (date_event.Read())
            {
               // MessageBox.Show(date_event[2].ToString());
                dataGridView1.Rows.Add(date_event[1].ToString(), date_event[3].ToString(), date_event[2].ToString().Substring(0,10) + " "+ date_event[4].ToString());
            }
            
            date_event.Close();
            conn.Close();

        }

        private void AdminMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authForm.Visible = true;
        }

        private void btnTechSup_Click(object sender, EventArgs e) //Письмо в техподдержку
        {
            TechMailForm techMailForm = new TechMailForm(_user) { Visible = true };
          //  MessageBox.Show("Форма для письма в техподдержку");
        }

        private void button1_Click(object sender, EventArgs e) //Подробнее о мероприятии
        {
            this.Hide();
            ScheduleForm scheduleForm = new ScheduleForm(_authForm, this, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value)) { Visible = true }; //Переход на форму расписания конкретного мероприятия

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentRow.Index].Selected = true;
        }

        private void btnChen_Click(object sender, EventArgs e) //Изменить учетную запись
        {
            this.Hide();
            EditAccForm editAccForm = new EditAccForm(_authForm, this, _user.Id_account) { Visible = true }; //Переход на форму изменения инфы об аккаунте

        }
        
    }
}
