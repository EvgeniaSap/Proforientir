using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Download;
using System.IO;
using System.Web;
using MySql.Data.MySqlClient;


namespace Proforientir
{
    public partial class MaterialForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private ScheduleForm _scheduleForm; //Форма плана проведения;
        private UserMainForm _userMainForm; //Форма личного кабинета пользователя;
        private EventForEmplForm _eventForEmplForm; //Форма редактирования информации о мероприятии пользователем;
        private DateEvent _dateEv; //Выбранное мероприятие
        private List<GoogleDriveFiles> _files; //Все файлы с диска;
        private int _idUser; //Индекс уровня доступа пользователя;

        public static string[] Scopes = { DriveService.Scope.Drive };
        public static string ApplicationName = "Proforientir";


        public MaterialForm()
        {
            InitializeComponent();
        }

        public MaterialForm(AuthForm authForm, AdminMainForm adminMainForm, ScheduleForm scheduleForm, DateEvent ev, int us)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _scheduleForm = scheduleForm;
            _dateEv = ev;
            _idUser = us;

            InitializeComponent();
        }

        public MaterialForm(AuthForm authForm, UserMainForm userMainForm, EventForEmplForm eventForEmplForm, DateEvent ev, int us)
        {
            _authForm = authForm;
            _userMainForm = userMainForm;
            _eventForEmplForm = eventForEmplForm;
            _dateEv = ev;
            _idUser = us;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }
        
        private void MaterialForm_Load(object sender, EventArgs e)
        {
           // this.TopMost = true;
            labelEv.Text = _dateEv.Info_event.Category + " '" + _dateEv.Info_event.Name_event + "' \n" +
                _dateEv.Datetime_event + " " + _dateEv.Info_event.Name_organizer;

            if (_adminMainForm == null)
            {
                btnAdd.Visible = false;
                btnDel.Visible = false;
            }
            if (_idUser == 2 && _userMainForm!=null)
            {
                btnAdd.Visible = true;
                btnDel.Visible = true;
            }

            var column0 = new DataGridViewColumn();
            column0.HeaderText = "ID";
            column0.Width = 50; //ширина колонки
            column0.Name = "Id";
            column0.CellTemplate = new DataGridViewTextBoxCell();

            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Имя файла"; //текст в шапке
            column1.Width = 300; //ширина колонки
            column1.Name = "Event"; //текстовое имя колонки, его можно использовать вместо обращений по индексу
            column1.CellTemplate = new DataGridViewTextBoxCell(); //тип нашей колонки

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Размер";
            column2.Width = 100; //ширина колонки
            column2.Name = "Categ";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Дата загрузки";
            column3.Width = 140; //ширина колонки
            column3.Name = "Org";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            dgvFiles.Columns.Add(column0);
            dgvFiles.Columns.Add(column1);
            dgvFiles.Columns.Add(column2);
            dgvFiles.Columns.Add(column3);

            dgvFiles.EnableHeadersVisualStyles = false;
            dgvFiles.ColumnHeadersDefaultCellStyle.Font = new Font(dgvFiles.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            OutputFiles(); //Вывод информации о файлах

            /*   DriveService service = GetService();


               string pageToken = null;
               // Define parameters of request.
               FilesResource.ListRequest listRequest = service.Files.List();
               listRequest.PageSize = 1;
               listRequest.Fields = "nextPageToken, files(name)";

               listRequest.PageToken = pageToken;
                listRequest.Q = "mimeType='image/png'";
               // List files.

               var request = listRequest.Execute();

               if (request.Files != null && request.Files.Count > 0)
               {
                   foreach (var file in request.Files)
                   {
                       MessageBox.Show(file.Name);
                   }
                  // pageToken = request.NextPageToken;

                 //  if (request.NextPageToken!=null)
                 //  {

                  // }

               }
               else
               {
                   MessageBox.Show("No files found.");
               }*/




            // IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;
            // Console.WriteLine("Files:");
            /*if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    MessageBox.Show(file.Name + " (" + file.Id +")");
                }
            }
            else
            {
                MessageBox.Show("No files found.");
            }*/
            // Console.Read();
        }

        private void OutputFiles() //Вывод информации о файлах
        {
            List<string> buff_id = new List<string>();
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();

            string sql = "SELECT path " +
               "FROM material " +
               "WHERE id_action_plan = @id ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _dateEv.Id_schedule;

            MySqlDataReader patrs = command.ExecuteReader();


            while (patrs.Read())
            {
                buff_id.Add(patrs[0].ToString());
            }

            patrs.Close();
            conn.Close();
            
            _files = new List<GoogleDriveFiles>();

            _files = GoogleDriveFilesRepository.GetDriveFiles();

            if (_files != null && _files.Count > 0)
            {
                foreach (var file in _files)
                {
                    foreach (string s in buff_id)
                    {
                        if (s == file.Id)
                        {
                            dgvFiles.Rows.Add(file.Id, file.Name, file.Size, file.CreatedTime);
                        }
                    }
                   // MessageBox.Show(file.Name + " (" + file.Id + ")");
                }
            }
            else
            {
                MessageBox.Show("Файлы не найдены.");
            }
            
        }

        /*  private async Task Run()
          {
              // Create the service.
              var service = new DiscoveryService(new BaseClientService.Initializer
              {
                  ApplicationName = "Discovery Sample",
                  ApiKey = "[YOUR_API_KEY_HERE]",
              });

              // Run the request.
              Console.WriteLine("Executing a list request...");
              var result = await service.Apis.List().ExecuteAsync();

              // Display the results.
              if (result.Items != null)
              {
                  foreach (DirectoryList.ItemsData api in result.Items)
                  {
                      Console.WriteLine(api.Id + " - " + api.Title);
                  }
              }
          }*/

        /*   public static DriveService BuildService()
           {
               string SERVICE_ACCOUNT_EMAIL = "XXXXX@developer.gserviceaccount.com";
               string SERVICE_ACCOUNT_PKCS12_FILE_PATH = @"\YYYYYYY.p12";

               return new DriveService(new BaseClientService.Initializer()
               {
                   HttpClientInitializer = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(SERVICE_ACCOUNT_EMAIL)
                   {
                       Scopes = new[] { DriveService.Scope.Drive }
                   }.FromCertificate(new X509Certificate2(SERVICE_ACCOUNT_PKCS12_FILE_PATH, "notasecret", X509KeyStorageFlags.Exportable))),
                   ApplicationName = "applicationName"
               });
           }

           public static void insertFile(String filePath)
           {
               Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
               body.Title = Path.GetFileNameWithoutExtension(filePath);
               body.MimeType = MimeMapping.GetMimeMapping(filePath);

               MemoryStream stream = new MemoryStream(System.IO.File.ReadAllBytes(filePath));
               FilesResource.InsertMediaUpload request = BuildService().Files.Insert(body, stream, body.MimeType);
               request.Upload();
           }*/

        private void MaterialForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            if (_eventForEmplForm != null)
            {
                _eventForEmplForm.Show();
            }
            else
            {
                _scheduleForm.Show();
            }
        }

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvFiles.Rows[dgvFiles.CurrentRow.Index].Selected = true;
        }

        private void btnSave_Click(object sender, EventArgs e) //Скачать файл с диска на комп
        {
            //MessageBox.Show(DownloadGoogleFile(dgvFiles.CurrentRow.Cells[0].Value.ToString()));
            string path = @"C:\Users\PC\Downloads";
            DownloadGoogleFile(dgvFiles.CurrentRow.Cells[0].Value.ToString(), path);

        }
        
        //Download file from Google Drive by fileId.
        public static void DownloadGoogleFile(string fileId, string FolderPath)
        {
            DriveService service = GoogleDriveFilesRepository.GetService();

             FilesResource.GetRequest request = service.Files.Get(fileId);

            string FileName = request.Execute().Name;
              string FilePath = System.IO.Path.Combine(FolderPath, FileName);

            MemoryStream stream1 = new MemoryStream();
            
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            MessageBox.Show(Convert.ToString(progress.BytesDownloaded));
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            MessageBox.Show("Download complete.");
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            MessageBox.Show("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream1);

            using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                fileStream.Write(stream1.GetBuffer(), 0, stream1.GetBuffer().Length);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e) //Добавить файл на диск
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            MessageBox.Show(filename);

            string id = FileUpload(filename);

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            string sql = "INSERT INTO material (id_action_plan, path) VALUES (@id, @jj)";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", _dateEv.Id_schedule);
            command.Parameters.AddWithValue("@jj", id);

            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            if (dgvFiles.Rows.Count != 0)
            {
                dgvFiles.Rows.Clear();
            }
            OutputFiles(); //Вывод информации о файлах

        }

        public static string FileUpload(string fileName) //Загрузить файл на диск
        {
            DriveService service = GoogleDriveFilesRepository.GetService();
            //string path = Path.Combine(FolderPath, fileName);

            var fileMetaData = new Google.Apis.Drive.v3.Data.File();
            fileMetaData.Name = Path.GetFileName(fileName);
             fileMetaData.MimeType = MimeMapping.GetMimeMapping(fileName);
            FilesResource.CreateMediaUpload request;

            using (var stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                request = service.Files.Create(fileMetaData, stream, fileMetaData.MimeType);
               // request.Fields = "id";
                request.Upload();
            }

            var file = request.ResponseBody;

            return file.Id;
        }

        private void btnDel_Click(object sender, EventArgs e) //Удалить файл с диска
        {
            GoogleDriveFilesRepository.DeleteFile(dgvFiles.CurrentRow.Cells[0].Value.ToString());

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
            string sql = "DELETE FROM material WHERE id_action_plan = @id AND path = @jj ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.AddWithValue("@id", _dateEv.Id_schedule);
            command.Parameters.AddWithValue("@jj", dgvFiles.CurrentRow.Cells[0].Value.ToString());
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            if (dgvFiles.Rows.Count!=0)
            {
                dgvFiles.Rows.Clear();
            }
            OutputFiles(); //Вывод информации о файлах
            
        }
    }
}
//c# OpenFileDialog
// Client ID
//354581522035 - umv2jvmviqr2ngt1rbehn4s56i8vk61n.apps.googleusercontent.com
// Client Secret
//Eo - 0CYQs9BN3j_mhjtUB - jtP

//типы мимов
//https://stackoverflow.com/questions/4212861/what-is-a-correct-mime-type-for-docx-pptx-etc