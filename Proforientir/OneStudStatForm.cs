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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Proforientir
{
    public partial class OneStudStatForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню для администратора;
        private StudViewForm _studViewForm; //Форма просмотра всех студентов;
        private AccEventForm _accEventForm; //Форма информации о мероприятиях студента;
        private int _idStud; //Индекс студента, о котором отображать информацию;
        private int _idDegr, _yearEnt; //Индекс ученой степени и год поступления;
        

        public OneStudStatForm()
        {
            InitializeComponent();
        }

        public OneStudStatForm(AuthForm authForm, AdminMainForm adminMainForm, StudViewForm studViewForm, AccEventForm accEventForm, int id)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _studViewForm = studViewForm;
            _accEventForm = accEventForm;
            _idStud = id;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void OneStudStatForm_Load(object sender, EventArgs e) //Загрузка
        {
            chbStud.Tag = 1;
            chbCurse.Tag = 2;
            chbAll.Tag = 3;

            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            //в среднем поучаствовал каждый абитуриент
            string sql = "SELECT id_degree, entrance " +
                "FROM student " +
                "WHERE id_student =  @id ";

            MySqlCommand command = new MySqlCommand(sql, conn);
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idStud;
            MySqlDataReader points = command.ExecuteReader();

            points.Read();

            _idDegr = Convert.ToInt32(points[0]);
            _yearEnt = Convert.ToInt32(points[1]);
            
            points.Close();
            conn.Close();
        }

        private void OneStudStatForm_FormClosing(object sender, FormClosingEventArgs e) //Закрыть
        {
            _accEventForm.Show();
        }

        private List<int> enterDisp(GroupBox group) //Возвращает значение выбранного элемента GroupBox;
        {
            List<int> buff = new List<int>();

            foreach (Control control in group.Controls)
            {
                if (((CheckBox)control).Checked)
                {
                    buff.Add(int.Parse(control.Tag.ToString()));
                }
            }
            return buff;
        }

        private void btnGraph_Click(object sender, EventArgs e) //Построить графики
        {
            List<int> buff = enterDisp(gbActiv);
            if (buff.Count != 0)
            {
                List<Proforientir.StudStatForm.MyPoint> graph = new List<Proforientir.StudStatForm.MyPoint>(); //Список точек для графика

                //Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

                chPage.Series = new SeriesCollection {
                                    new LineSeries { Title = "Студент", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                    new LineSeries { Title = "Среднее по курсу", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                    new LineSeries { Title = "Среднее по всем студентам", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                 };
                foreach (int g in buff)
                {
                    if (g == 1) //график студента
                    {
                        graph = getPoints(1); //Получаем точки
                        
                        foreach (Proforientir.StudStatForm.MyPoint p in graph)
                        {
                            chPage.Series[0].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));

                        }
                    }
                    else if (g == 2) //график курса
                    {
                        graph = getPoints(2); //Получаем точки
                       
                        foreach (Proforientir.StudStatForm.MyPoint p in graph)
                        {
                            chPage.Series[1].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));

                        }

                    }
                    else if (g == 3) //график всех студентов
                    {
                        graph = getPoints(3); //Получаем точки
                        
                        foreach (Proforientir.StudStatForm.MyPoint p in graph)
                        {
                            chPage.Series[2].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));

                        }
                    }
                }

                if (chPage.Series[2].Values.Count == 0)
                {
                    chPage.Series.RemoveAt(2);
                }
                if (chPage.Series[1].Values.Count == 0)
                {
                    chPage.Series.RemoveAt(1);
                }
                if (chPage.Series[0].Values.Count == 0)
                {
                    chPage.Series.RemoveAt(0);
                }
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один график для построения.");
            }
        }

        private List<Proforientir.StudStatForm.MyPoint> getPoints(int keyDisp) //Точки
        {
            List<Proforientir.StudStatForm.MyPoint> buff = new List<Proforientir.StudStatForm.MyPoint>(); //Список точек для графика

            switch (keyDisp) //какой график
            {
                case 1: //график: активность конкретного студента
                    
                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();
                    string sql = "SELECT COUNT(activity.id_account), YEAR(date_event) AS ye " +
                        "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan "+
                        "WHERE student.id_student =  @id " +
                        "GROUP BY ye " +
                        "ORDER BY ye ";

                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idStud;
                    MySqlDataReader points = command.ExecuteReader();

                    while (points.Read())
                    {
                        buff.Add(new Proforientir.StudStatForm.MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0])));
                    }
                    
                    points.Close();
                    conn.Close();

                    return buff;

                case 2: //активность студентов того же курса

                    MySqlConnection conn1 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn1.Open();
                    
                    string sql1 = "SELECT AVG(ev.act), ev.ye " +
                         "FROM (SELECT COUNT(activity.id_activity) AS act, activity.id_account, YEAR(date_event) AS ye " +
                        "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                         "WHERE student.id_degree = @degr AND entrance = @year " +
                           "GROUP BY activity.id_account, ye) AS ev " +
                     "GROUP BY ev.ye " +
                     "ORDER BY ev.ye";


                   /* string sql1 = "SELECT COUNT(activity.id_account), date_event "+
                         "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan "+
                         "WHERE student.id_degree =  @degr AND entrance = @year "+
                     "GROUP BY student.id_degree, entrance, date_event ";*/
                    

                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);
                     command1.Parameters.Add("@degr", MySqlDbType.VarChar).Value = _idDegr;
                    command1.Parameters.Add("@year", MySqlDbType.VarChar).Value = _yearEnt;

                    MySqlDataReader points1 = command1.ExecuteReader();
                    
                    while (points1.Read())
                    {
                        
                       buff.Add(new Proforientir.StudStatForm.MyPoint(Convert.ToInt32(points1[1]), Convert.ToInt32(points1[0])));
                       
                    }
                    points1.Close();
                    conn1.Close();

                    return buff;

                case 3: //активность всех студетов по годам


                    MySqlConnection conn2 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn2.Open();

                    string sql2 = "SELECT AVG(ev.act), ev.ye " +
                         "FROM (SELECT COUNT(activity.id_activity) AS act, activity.id_account, YEAR(date_event) AS ye " +
                        "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                           "GROUP BY activity.id_account, ye) AS ev " +
                     "GROUP BY ev.ye " +
                     "ORDER BY ev.ye ";

                    MySqlCommand command2 = new MySqlCommand(sql2, conn2);
                    MySqlDataReader points2 = command2.ExecuteReader();
                    while (points2.Read())
                    {

                        buff.Add(new Proforientir.StudStatForm.MyPoint(Convert.ToInt32(points2[1]), Convert.ToInt32(points2[0])));

                    }
                    points2.Close();
                    conn2.Close();
                    
                    return buff;
            }
            return buff;
        }
    }
}
