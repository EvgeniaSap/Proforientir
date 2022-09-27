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
using System.IO;

namespace Proforientir
{
    public partial class StudStatForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private string _selectedPositDeg1; //Выбранная ученая степень на стр1;
        private string _selectedPositDeg2; //Выбранная ученая степень на стр2;

        public StudStatForm()
        {
            InitializeComponent();
        }

        public StudStatForm(AuthForm authForm, AdminMainForm adminMainForm)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _selectedPositDeg1 = "";
            _selectedPositDeg2 = "";

            InitializeComponent();

          /*  chPage2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(2015,10), //первая точка первой линии
                        new ObservablePoint(2016,7),
                        new ObservablePoint(2017,3),
                        new ObservablePoint(2018,6),
                        new ObservablePoint(2019,8),
                    },
                    PointGeometrySize = 15
                },

                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(2015,1), //первая точка первой линии
                        new ObservablePoint(2016,7),
                        new ObservablePoint(2017,5),
                        new ObservablePoint(2018,2),
                        new ObservablePoint(2019,2),
                    },
                    PointGeometrySize = 15
                }

            };*/
        }

        public class MyPoint //Точки для отображения грaфика
        {
            public int Xpoint { set; get; } //Координата х
            public int Ypoint { set; get; } //Координата y
            public int Series { set; get; } //Индекс графика, если нужно отобразить несколько
            public string Xstr { set; get; } //Координата х

            public MyPoint(int x, int y)
            {
                Xpoint = x;
                Ypoint = y;
                Series = 0; //если один график
                Xstr = "";
            }

            public MyPoint(int x, int y, int s)
            {
                Xpoint = x;
                Ypoint = y;
                Series = s;
            }

            public MyPoint(string x, int y)
            {
                Xstr = x;
                Ypoint = y;
                Series = 0; //если один график
            }
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void StudStatForm_Load(object sender, EventArgs e) //Загрузка
        {
            OutputDegree(); //Вывод ученых степеней

            //Отображение графиков стр1;
            radioButtonEx.Tag = 1;  
            radioButtonCount.Tag = 2;

            //Отображение графиков стр2;
            radioButtonBefore.Tag = 1;
            radioButtonInTime.Tag = 2;

            //Отображение графиков стр3;
            radioButtonGrad.Tag = 1;
            radioButtonLB.Tag = 2;

            //График ось х стр2
            radioButtonYear.Tag = 1;
            radioButtonCurs.Tag = 2;

            gbDraphX.Enabled = false;
            
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "";
            column1.Width = 190; //ширина колонки
            column1.Name = "Name";
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "";
            column2.Width = 70; //ширина колонки
            column2.Name = "Count";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            dataGraph.Columns.Add(column1);
            dataGraph.Columns.Add(column2);
            dataGraph.EnableHeadersVisualStyles = false;
            dataGraph.ColumnHeadersDefaultCellStyle.Font = new Font(dataGraph.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Regular); //жирный курсив размера 16

            
        }

        private void OutputDegree() //Вывод ученых степеней
        {
            cmbDegr1.Items.Add("0. все");
            cmbDegr2.Items.Add("0. все");
            MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

            conn.Open();
            string sql = "SELECT  id_degree, name_degree " +
                "FROM degree ";
            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader posit = command.ExecuteReader();

            while (posit.Read())
            {
                cmbDegr1.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
                cmbDegr2.Items.Add(Convert.ToString(posit[0]) + ". " + Convert.ToString(posit[1]));
            }

            posit.Close();
            conn.Close();
        }

        private void StudStatForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _adminMainForm.Show();
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

       /* private List<MyPoint> getPoints(int keyDisp, int keyGr)
        {
            List<MyPoint> buff = new List<MyPoint>(); //Список точек для графика
            string degr = _selectedPositDeg.Substring(0, _selectedPositDeg.IndexOf('.')); //id ученой степени

            switch (keyDisp) //режим отображения
            {
                case 1: //график средний балл

                    if (keyGr == 1) //по годам поступления
                    {
                        MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        conn.Open();
                        string sql = "SELECT AVG(exam_score), entrance " +
                            "FROM student " +
                            "WHERE id_degree =  @degr " +
                                "GROUP BY entrance ";

                        /* DateTime date_now = DateTime.Today; //Дата сейчас
                         string date_n = Convert.ToString(date_now).Substring(0, 10);
                         string date = date_n.Substring(6, 4);

                         sql += " act, (entrance - @date) AS curse " +
                         "FROM student " +
                         "JOIN stud_enroll " +
                         "ON student.id_student = stud_enroll.id_student " +
                         "JOIN "+
                         "(SELECT   "+
                         "WHERE id_degree =  @degr " +
                             "GROUP BY entrance ";*/

                 /*       MySqlCommand command = new MySqlCommand(sql, conn);

                        command.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;

                        MySqlDataReader points = command.ExecuteReader();

                        while (points.Read())
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0])));
                        }
                        points.Close();
                        conn.Close();
                    }
                    else if (keyGr == 2) // по курсу
                    {
                        buff.Add(new MyPoint(0, 0));
                    }
                    
                    return buff;

                case 2: //график активность во время учебы

                    MySqlConnection conn1 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn1.Open();
                    string sql1 = "SELECT СOUNT(activity.id_account), ";

                    if (keyGr == 1) //по годам поступления
                    {
                        sql1 += "date_event ";
                    }
                    else if (keyGr == 2) // по курсу
                    {
                        sql1 += "(entrance - @date) AS curse ";
                    }


                    sql1 += "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                            "WHERE student.id_degree =  @degr ";// +

                    if (keyGr == 1) //по годам поступления
                    {
                        sql1 += "GROUP BY date_event ";
                    }
                    else if (keyGr == 2) // по курсу
                    {
                        sql1 += "GROUP BY curse ";
                    }
                    
                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);
                    command1.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;

                    MySqlDataReader points1 = command1.ExecuteReader();

                    while (points1.Read())
                    {
                        buff.Add(new MyPoint(Convert.ToInt32(points1[1]), Convert.ToInt32(points1[0])));
                    }
                    points1.Close();
                    conn1.Close();

                    return buff;

                case 3: //график активность до поступления

                    MySqlConnection conn2 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn2.Open();
                    string sql2 = "SELECT СOUNT(activity.id_account), ";

                    if (keyGr == 1) //по годам поступления
                    {
                        sql2 += "date_event ";
                    }
                    else if (keyGr == 2) // по курсу
                    {
                        sql2 += "(entrance - @date) AS curse ";
                    }


                    sql2 += "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                            "WHERE student.id_degree =  @degr ";// +

                    if (keyGr == 1) //по годам поступления
                    {
                        sql2 += "GROUP BY date_event ";
                    }
                    else if (keyGr == 2) // по курсу
                    {
                        sql2 += "GROUP BY curse ";
                    }

                    MySqlCommand command2 = new MySqlCommand(sql1, conn1);
                    command2.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;

                    MySqlDataReader points2 = command2.ExecuteReader();

                    while (points2.Read())
                    {
                        buff.Add(new MyPoint(Convert.ToInt32(points2[1]), Convert.ToInt32(points2[0])));
                    }
                    points2.Close();
                    conn2.Close();

                    return buff;

                    

            }


            return buff;
        }*/

     /*   private void btnDel_Click(object sender, EventArgs e) //Построить график
        {
            int keyDesp = enterDisp(gbAbit); //Получаем ключ отображения, который выбрал пользователь
            List<int> keysStat = new List<int>(); //Список ключей для определения графиков, которые хочет отобразить пользователь
            List<MyPoint> graph = new List<MyPoint>(); //Список точек для графика

            if (_selectedPositDeg != "")
            {
               // string degr = _selectedPositDeg.Substring(0, _selectedPositDeg.IndexOf('.')); //id ученой степени

                if (keyDesp != -1)
                {
                    keysStat = enterGraph(gbDraphStat); //Получаем ключи, какой график строить

                    if (keysStat.Count != 0)
                    {
                        foreach (int k in keysStat)
                        {
                            graph = getPoints(k, keyDesp); //Получаем точки



                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите, какой график необходимо построить.");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите режим отображения.");
                }
            }
            else
            {
                MessageBox.Show("Выберите ученую степень студентов.");
            }

        }*/



        //ДЛЯ СТРАНИЦЫ 1

        private void cmbDegr1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositDeg1 = cmbDegr1.SelectedItem.ToString();
        }

        private void btnDel1_Click(object sender, EventArgs e) //Кнопак построить график стр1
        {
            if(chPage1.Series.Count !=0)
            {
                chPage1.Series.Clear();
            }

            List<MyPoint> graph = new List<MyPoint>(); //Список точек для графика

            int keyDesp = enterDisp(gbAbit); //Получаем ключ отображения, который выбрал пользователь
            if (keyDesp != -1)
            {
                if (_selectedPositDeg1 != "")
                {

                    graph = getPoints1(keyDesp); //Получаем точки

                    if (_selectedPositDeg1.Substring(0, _selectedPositDeg1.IndexOf('.')) == "0")
                    {
                        chPage1.Series.Add("бакалавриат");
                        chPage1.Series.Add("магистратура");
                        chPage1.Series.Add("аспирантура");
                        foreach (MyPoint p in graph)
                        {
                            if (p.Series == 1)
                            {
                                chPage1.Series["бакалавриат"].Points.AddXY(p.Xpoint, p.Ypoint);
                            }
                            else if (p.Series == 2)
                            {
                                chPage1.Series["магистратура"].Points.AddXY(p.Xpoint, p.Ypoint);
                            }
                            else
                            {
                                chPage1.Series["аспирантура"].Points.AddXY(p.Xpoint, p.Ypoint);
                            }
                        }
                    }
                    else
                    {
                        string name = _selectedPositDeg1.Substring(_selectedPositDeg1.IndexOf('.') + 2, _selectedPositDeg1.Length - _selectedPositDeg1.IndexOf('.') - 2);
                        chPage1.Series.Add(name);
                        foreach (MyPoint p in graph)
                        {
                            chPage1.Series[name].Points.AddXY(p.Xpoint, p.Ypoint);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Выберите позицию из перечня ученых степеней студентов.");
                }
            }
            else
            {
                MessageBox.Show("Выберите режим отображения.");
            }
        }

        private List<MyPoint> getPoints1(int keyDisp) //Точки для стр1
        {
            List<MyPoint> buff = new List<MyPoint>(); //Список точек для графика
            string degr = _selectedPositDeg1.Substring(0, _selectedPositDeg1.IndexOf('.')); //id ученой степени

            switch (keyDisp) //режим отображения
            {
                case 1: //график средний балл

                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();
                    string sql = "SELECT AVG(exam_score), entrance, id_degree " +
                        "FROM student " +
                            //  "WHERE id_degree =  @degr " +
                            "GROUP BY id_degree, entrance " +
                                "ORDER BY id_degree ";
                    if (degr!="0")
                    {
                        sql = "SELECT AVG(exam_score), entrance " +
                            "FROM student " +
                            "WHERE id_degree =  @degr " +
                                "GROUP BY entrance ";
                    }


                    MySqlCommand command = new MySqlCommand(sql, conn);
                    if (degr != "0")
                    {
                        command.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;
                    }
                    MySqlDataReader points = command.ExecuteReader();

                    while (points.Read())
                    {
                        if (degr != "0")
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0])));
                        }
                        else
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0]), Convert.ToInt32(points[2])));
                        }
                    }
                    points.Close();
                    conn.Close();

                    return buff;

                case 2: //количество поступивших
                    
                        MySqlConnection conn1 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                        conn1.Open();
                        string sql1 = "SELECT COUNT(id_student), entrance, id_degree " +
                        "FROM student " +
                            "GROUP BY id_degree, entrance " +
                                "ORDER BY id_degree ";

                    if (degr != "0")
                    {
                        sql = "SELECT COUNT(id_student), entrance " +
                            "FROM student " +
                            "WHERE id_degree =  @degr " +
                                "GROUP BY entrance ";
                    }

                    
                        MySqlCommand command1 = new MySqlCommand(sql1, conn1);
                    if (degr != "0")
                    {
                        command1.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;
                    }

                    MySqlDataReader points1 = command1.ExecuteReader();

                        while (points1.Read())
                        {

                        if (degr != "0")
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points1[1]), Convert.ToInt32(points1[0])));
                        }
                        else
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points1[1]), Convert.ToInt32(points1[0]), Convert.ToInt32(points1[2])));
                        }
                    }
                        points1.Close();
                        conn1.Close();

                        return buff;
            }
            return buff;
        }


        //ДЛЯ СТРАНИЦЫ 2

        private void cmbDegr2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPositDeg2 = cmbDegr2.SelectedItem.ToString();
        }

        private void btnGraph2_Click(object sender, EventArgs e) //Кнопка построить график для стр2
        {
            if (chPage2.Series.Count != 0)
            {
                chPage2.Series.Clear();
            }

            List<MyPoint> graph = new List<MyPoint>(); //Список точек для графика
                                                       // int keysStat = new List<int>(); //Список ключей для определения оси Y, которые хочет отобразить пользователь
            int keyDesp = enterDisp(gbActiv); //Получаем ключ отображения, который выбрал пользователь 
            if (_selectedPositDeg2 != "")
            {
                if (keyDesp != -1)
                {
                    if (keyDesp == 1) //активность до поступления
                    {
                        graph = getPoints2(keyDesp, 0); //Получаем точки

                        if (_selectedPositDeg2.Substring(0, _selectedPositDeg2.IndexOf('.')) == "0")
                        {
                            chPage2.Series = new SeriesCollection {
                                new LineSeries { Title = "бакалавриат", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                new LineSeries { Title = "магистратура", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                new LineSeries { Name  = "аспирантура", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 }
                        };

                            foreach (MyPoint p in graph)
                            {
                                if (p.Series == 1)
                                {
                                    chPage2.Series[0].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                }
                                else if (p.Series == 2)
                                {
                                    chPage2.Series[1].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                }
                                else
                                {
                                    chPage2.Series[2].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                }
                            }
                            if (chPage2.Series[2].Values.Count == 0)
                            {
                                chPage2.Series.RemoveAt(2);
                            }
                            if (chPage2.Series[1].Values.Count == 0)
                            {
                                /* foreach (ObservablePoint p in chPage2.Series[0].Values)
                                 {
                                     chPage2.Series[1].Values.Add(new ObservablePoint(p.X, 0));

                                 }*/
                                chPage2.Series.RemoveAt(1);
                            }

                        }
                        else
                        {
                            string name = _selectedPositDeg2.Substring(_selectedPositDeg2.IndexOf('.') + 2, _selectedPositDeg2.Length - _selectedPositDeg2.IndexOf('.') - 2);

                            chPage2.Series = new SeriesCollection {
                                    new LineSeries { Title = name, Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                 };
                            foreach (MyPoint p in graph)
                            {
                                chPage2.Series[0].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));

                            }
                        }
                    }
                    else if (keyDesp == 2) //активность в течении учебы
                    {
                        int keysStat = enterDisp(gbDraphX); //Получаем ключи, какая ось х
                        if (keysStat != -1)
                        {
                            graph = getPoints2(keyDesp, keysStat); //Получаем точки

                            if (_selectedPositDeg2.Substring(0, _selectedPositDeg2.IndexOf('.')) == "0")
                            {
                                 chPage2.Series = new SeriesCollection {
                                     new LineSeries { Title = "бакалавриат", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                     new LineSeries { Title = "магистратура", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                     new LineSeries { Title = "аспирантура", Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },

                                 };
                                
                                foreach (MyPoint p in graph)
                                {
                                    if (p.Series == 1)
                                    {
                                        chPage2.Series[0].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                    }
                                    else if (p.Series == 2)
                                    {
                                        chPage2.Series[1].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                    }
                                    else
                                    {
                                        chPage2.Series[2].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));
                                    }
                                }
                                if (chPage2.Series[2].Values.Count == 0)
                                {
                                    chPage2.Series.RemoveAt(2);
                                }
                                if (chPage2.Series[1].Values.Count == 0)
                                {
                                    /* foreach (ObservablePoint p in chPage2.Series[0].Values)
                                     {
                                         chPage2.Series[1].Values.Add(new ObservablePoint(p.X, 0));

                                     }*/
                                    chPage2.Series.RemoveAt(1);
                                }
                            }
                            else
                            {
                                string name = _selectedPositDeg2.Substring(_selectedPositDeg2.IndexOf('.') + 2, _selectedPositDeg2.Length - _selectedPositDeg2.IndexOf('.') - 2);

                                chPage2.Series = new SeriesCollection {
                                    new LineSeries { Title = name, Values = new ChartValues<ObservablePoint>(), PointGeometrySize = 15 },
                                 };
                                foreach (MyPoint p in graph)
                                {
                                    chPage2.Series[0].Values.Add(new ObservablePoint(p.Xpoint, p.Ypoint));

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Выберите параметр для оси x.");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Выберите режим отображения.");
                }
            }
            else
            {
                MessageBox.Show("Выберите позицию из перечня ученых степеней студентов.");
            }

        }

        private List<MyPoint> getPoints2(int keyDisp, int keysStat) //Точки для стр2
        {
            List<MyPoint> buff = new List<MyPoint>(); //Список точек для графика
            string degr = _selectedPositDeg2.Substring(0, _selectedPositDeg2.IndexOf('.')); //id ученой степени

            switch (keyDisp) //режим отображения
            {
                case 1: //график активность до поступления

                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();
                    //в среднем поучаствовал каждый абитуриент
                    string sql = "SELECT AVG(ev.act), entrance, id_degree " +
                        "FROM student " +
                        "JOIN stud_enroll " +
                        "ON student.id_student = stud_enroll.id_student " +
                        "JOIN person " +
                         "ON stud_enroll.idPerson = person.idPerson " +
                         "JOIN "+
                         "(SELECT COUNT(idPersonOlympiad) AS act, PersonID " +
                         "FROM  personolympiad " +
                         "GROUP BY PersonID) AS ev " +
                         "ON person.idPerson = ev.PersonID " +
                          "GROUP BY id_degree, entrance " +
                                "ORDER BY id_degree ";
                    
                    if (degr != "0")
                    {
                        sql = "SELECT AVG(ev.act), entrance " +
                        "FROM student " +
                        "JOIN stud_enroll " +
                        "ON student.id_student = stud_enroll.id_student " +
                        "JOIN person " +
                         "ON stud_enroll.idPerson = person.idPerson " +
                         "JOIN " +
                         "(SELECT COUNT(idPersonOlympiad) AS act, PersonID " +
                         "FROM  personolympiad " +
                         "GROUP BY PersonID) AS ev " +
                         "ON person.idPerson = ev.PersonID " +
                         "WHERE id_degree =  @degr " +
                          "GROUP BY entrance ";
                    }
                    
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    if (degr != "0")
                    {
                        command.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr;
                    }
                    MySqlDataReader points = command.ExecuteReader();

                    while (points.Read())
                    {
                        if (degr != "0")
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0])));
                        }
                        else
                        {
                            buff.Add(new MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0]), Convert.ToInt32(points[2])));
                            
                        }
                    }
                    points.Close();
                    conn.Close();

                    return buff;

                case 2: //активность во время учебы
                    
                    MySqlConnection conn2 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;
                    
                    conn2.Open();

                    /*string sql2 = "SELECT COUNT(activity.id_account), ";

                    if (keysStat == 1) //по годам обучения
                    {
                        sql2 += "YEAR(date_event) AS ye, student.id_degree ";
                    }
                    else if (keysStat == 2) // по курсу
                    {
                        sql2 += "entrance, student.id_degree, YEAR(date_event) AS ye ";
                    }
                    
                    sql2 += "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan ";
                    if (degr != "0")
                    {
                        sql2 += "WHERE student.id_degree =  @degr ";
                    }

                    if (keysStat == 1) //по годам обучения
                    {
                        sql2 += "GROUP BY student.id_degree, ye ";
                    }
                    else if (keysStat == 2) // по курсу
                    {
                        sql2 += "GROUP BY student.id_degree, entrance, ye ";
                    }*/

                    string sql2 = "";

                    if (keysStat == 1) //по годам обучения
                    {
                        sql2 += "SELECT AVG(ev.act), ev.ye, iddegr " +
                         "FROM (SELECT COUNT(activity.id_activity) AS act, YEAR(date_event) AS ye, student.id_degree AS iddegr " +
                        "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan ";
                        if (degr != "0")
                        {
                            sql2 += "WHERE student.id_degree =  @degr ";
                        }

                        sql2 += "GROUP BY ye, iddegr) AS ev " +
                     "GROUP BY ev.ye, iddegr " +
                     "ORDER BY ev.ye, iddegr ";
                    }
                    else if (keysStat == 2) // по курсу
                    {
                        sql2 += "SELECT AVG(ev.act), entrance, iddegr, ye  " +
                         "FROM (SELECT COUNT(activity.id_activity) AS act, YEAR(date_event) AS ye, student.id_degree AS iddegr, entrance " +
                        "FROM student " +
                        "JOIN account " +
                        "ON student.id_account = account.id_account " +
                        "JOIN activity " +
                        "ON account.id_account = activity.id_account " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan ";
                        if (degr != "0")
                        {
                            sql2 += "WHERE student.id_degree =  @degr ";
                        }
                        sql2 += "GROUP BY iddegr, entrance, ye) AS ev " +
                     "GROUP BY ev.ye, iddegr, entrance " +
                     "ORDER BY entrance, ev.ye, iddegr ";
                    }

                    MySqlCommand command2 = new MySqlCommand(sql2, conn2);
                    if (degr != "0")
                    { command2.Parameters.Add("@degr", MySqlDbType.VarChar).Value = degr; }

                    MySqlDataReader points2 = command2.ExecuteReader();

                    DateTime date_now = DateTime.Today; //Дата сейчас
                    int date = Convert.ToInt32(Convert.ToString(date_now).Substring(6, 4));
                    while (points2.Read())
                    {
                        if (degr != "0")
                        {
                            if (keysStat == 2) // по курсу
                            {
                                int curse_date = Convert.ToInt32(points2[3]) - Convert.ToInt32(points2[1]); //курс
                                int curse = date - Convert.ToInt32(points2[1]);
                                /* if ((Convert.ToInt32(points2[2])==1 && curse<=4)|| (Convert.ToInt32(points2[2]) == 2 && curse <= 2)||
                                     (Convert.ToInt32(points2[2]) == 3 && curse <= 3))
                                 {
                                   MessageBox.Show(curse_date.ToString()+ " "+ Convert.ToString(points2[0]));
                                     buff.Add(new MyPoint(curse, Convert.ToInt32(points2[0])));
                                 }*/
                                if (curse_date >= 0 && ((Convert.ToInt32(points2[2]) == 1 && curse_date <= 4) || (Convert.ToInt32(points2[2]) == 2 && curse_date <= 2) ||
                                    (Convert.ToInt32(points2[2]) == 3 && curse_date <= 3)))
                                {
                                    if (curse_date == 0)
                                    {
                                        curse_date = 1;
                                    }
                                    
                                    if (buff.Count != 0)
                                    {
                                        bool eq = false;
                                        foreach (MyPoint p in buff)
                                        {
                                            if (p.Xpoint == curse_date)
                                            {
                                                p.Ypoint += Convert.ToInt32(points2[0]);
                                                eq = true;
                                            }
                                        }

                                        if (eq == false)
                                        {
                                            buff.Add(new MyPoint(curse_date, Convert.ToInt32(points2[0])));
                                        }
                                    }
                                    else
                                    {
                                         buff.Add(new MyPoint(curse_date, Convert.ToInt32(points2[0])));
                                    }
                                }
                            }
                            else
                            {
                                buff.Add(new MyPoint(Convert.ToInt32(Convert.ToString(points2[1])), Convert.ToInt32(points2[0])));
                            }
                        }
                        else
                        {
                            if (keysStat == 2) // по курсу
                            {
                                int curse_date = Convert.ToInt32(points2[3]) - Convert.ToInt32(points2[1]); //курс
                                int curse = date - Convert.ToInt32(points2[1]);

                                if (curse_date >= 0 && ((Convert.ToInt32(points2[2]) == 1 && curse_date <= 4) || (Convert.ToInt32(points2[2]) == 2 && curse_date <= 2) ||
                                    (Convert.ToInt32(points2[2]) == 3 && curse_date <= 3)))
                                {
                                    if (curse_date == 0)
                                    {
                                        curse_date = 1;
                                    }
                                    
                                    if (buff.Count != 0)
                                    {
                                        bool eq = false;
                                        foreach (MyPoint p in buff)
                                        {
                                            if (p.Xpoint == curse_date && p.Series == Convert.ToInt32(points2[2]))
                                            {
                                                p.Ypoint += Convert.ToInt32(points2[0]);
                                                eq = true;
                                            }
                                        }
                                        if (eq == false)
                                        {
                                            buff.Add(new MyPoint(curse_date, Convert.ToInt32(points2[0]), Convert.ToInt32(points2[2])));
                                        }
                                    }
                                    else
                                    {
                                        buff.Add(new MyPoint(curse_date, Convert.ToInt32(points2[0]), Convert.ToInt32(points2[2])));
                                    }
                                }
                            }
                            else
                            {
                                buff.Add(new MyPoint(Convert.ToInt32(Convert.ToString(points2[1])), Convert.ToInt32(points2[0]), Convert.ToInt32(points2[2])));
                            }
                        }
                    }
                    points2.Close();
                    conn2.Close();

                    return buff;
            }
            return buff;
        }

        private void radioButtonInTime_CheckedChanged(object sender, EventArgs e) //отображение gb оси х
        {
            bool i = radioButtonInTime.Checked;

            if (i)
            {
                gbDraphX.Enabled = true;
            }
            else
            {
                gbDraphX.Enabled = false;
            }
        }


        //ДЛЯ СТРАНИЦЫ 3

        private void btnGraph3_Click(object sender, EventArgs e) //Кнопка построить график
        {
            if (chPage3.Series.Count != 0)
            {
                chPage3.Series.Clear();
            }

            if (dataGraph.Rows != null)
            {
                dataGraph.Rows.Clear();
            }
            // List<MyPoint> graph = new List<MyPoint>(); //Список точек для графика

            int keyDesp = enterDisp(gbAfter); //Получаем ключ отображения, который выбрал пользователь 
            if (keyDesp != -1)
            {
                getPoints3(keyDesp); //Получаем точки

               // if (keyDesp == 1) //выпускники
                //{
                    if (dataGraph.Rows.Count != 0)
                    {
                          Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

                          SeriesCollection series = new SeriesCollection();
                          int i = 0;
                          while (i < dataGraph.Rows.Count-1)
                          {
                              series.Add(new PieSeries() { Title = dataGraph.Rows[i].Cells[0].Value.ToString(),
                              Values = new ChartValues<int> { Convert.ToInt32(dataGraph.Rows[i].Cells[1].Value) },
                              DataLabels=true, LabelPoint = labelPoint});
                              chPage3.Series = series;
                              i++;
                          }
                       
                    }
                    else
                    {
                        MessageBox.Show("Данные отсутствуют.");
                    }

               // }

            }
            else
            {
                MessageBox.Show("Выберите режим отображения.");
            }
        }

        private void getPoints3(int keyDisp) //Точки для стр3
        {
            List<MyPoint> buff = new List<MyPoint>(); //Список точек для графика
            
            switch (keyDisp) //режим отображения
            {
                case 1: //диаграмма выпускники
                    
                    dataGraph.Columns[0].HeaderText = "Количество";
                    dataGraph.Columns[1].HeaderText = "Работа";

                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();
                    string sql = "SELECT COUNT(id_student), job " +
                         "FROM  graduate " +
                         "GROUP BY job " +
                             "ORDER BY job ";
                    
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    
                    MySqlDataReader points = command.ExecuteReader();

                    while (points.Read())
                    {
                        if (Convert.ToInt32(points[1]) == 0)
                        {
                            dataGraph.Rows.Add("Не по специальности", Convert.ToInt32(points[0]));
                        }
                        else if (Convert.ToInt32(points[1]) == 1)
                        {
                            dataGraph.Rows.Add("По специальности", Convert.ToInt32(points[0]));
                        }
                        else
                        {
                            dataGraph.Rows.Add("Неизвестно", Convert.ToInt32(points[0]));
                        }

                    }
                    points.Close();
                    conn.Close();

                    break;

                case 2: //рынок труда

                    dataGraph.Columns[0].HeaderText = "Сфера";
                    dataGraph.Columns[1].HeaderText = "Количество вакансий";

                    MySqlConnection conn1 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn1.Open();
                    string sql1 = "SELECT SUM(count), name_field " +
                         "FROM  labor_market " +
                         "JOIN field " +
                         "ON labor_market.id_field = field.id_field " +
                         "GROUP BY labor_market.id_field ";

                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);

                    MySqlDataReader points1 = command1.ExecuteReader();

                    while (points1.Read())
                    {
                        dataGraph.Rows.Add(points1[1].ToString(), Convert.ToInt32(points1[0]));
                        
                    }
                    points1.Close();
                    conn1.Close();

                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) //Парсер по сайтам вакансий
        {
            string path = "";
            string nameFile = @"..\..\path.txt";

            FileInfo file = new FileInfo(nameFile);
            if (file.Exists != false) //Если файл существует
            {
                StreamReader streamReader = new StreamReader(nameFile); //Открываем файл для чтения
                string str = ""; //Объявляем переменную, в которую будем записывать текст из файла

                while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                {
                    str = streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла

                    path = str;
                }
            }
            
            System.Diagnostics.Process.Start(path + "/www/bin/php/php5.6.40/php.exe", "C:/wamp/www/labmarket.php");
           
        }

        private void radioButtonLB_CheckedChanged(object sender, EventArgs e) //Нажатие на пунку "рынок труда"
        {
            if (btnUpdate.Visible == false)
            {
                btnUpdate.Visible = true;
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }
    }
}
