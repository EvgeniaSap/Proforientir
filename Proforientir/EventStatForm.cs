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
    public partial class EventStatForm : Form
    {
        private AuthForm _authForm; //Форма авторизации;
        private AdminMainForm _adminMainForm; //Форма главного меню админа;
        private AllEventsForm _allEventsForm; //Форма всех мероприятий;
        private int _idEvent; //Индекс конкретного мероприятия;
        private string _name; //Название конкретного мероприятия;

        public EventStatForm()
        {
            InitializeComponent();
        }

        public EventStatForm(AuthForm authForm, AdminMainForm adminMainForm, AllEventsForm allEventsForm, int id, string str)
        {
            _authForm = authForm;
            _adminMainForm = adminMainForm;
            _allEventsForm = allEventsForm;
            _idEvent = id;
            _name = str;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void EventStatForm_Load(object sender, EventArgs e) //Загрузка
        {
            labelName.Text += " '" + _name + "'";
            radioButton1.Tag = 1;
            radioButton2.Tag = 2;

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

        private void EventStatForm_FormClosing(object sender, FormClosingEventArgs e) //Закрытие
        {
            _allEventsForm.Show();
        }

        private void btnGraph_Click(object sender, EventArgs e) //Построить график
        {
            if (chPage.Series.Count != 0)
            {
                chPage.Series.Clear();
            }

            List<Proforientir.StudStatForm.MyPoint> graph = new List<Proforientir.StudStatForm.MyPoint>(); //Список точек для графика

            int keyDesp = enterDisp(gbAbit); //Получаем ключ отображения, который выбрал пользователь
            if (keyDesp != -1)
            {
                
                    graph = getPoints(keyDesp); //Получаем точки

                if (graph[0].Xstr == "")
                {
                    chPage.Series.Add(_name);

                    foreach (Proforientir.StudStatForm.MyPoint p in graph)
                    {
                        chPage.Series[_name].Points.AddXY(p.Xpoint, p.Ypoint);
                    }
                }
                else
                {
                    chPage.Series.Add("мероприятия");

                    foreach (Proforientir.StudStatForm.MyPoint p in graph)
                    {
                        chPage.Series["мероприятия"].Points.AddXY(p.Xstr, p.Ypoint);
                    }
                }
                
               
            }
            else
            {
                MessageBox.Show("Выберите режим отображения.");
            }

        }

        private List<Proforientir.StudStatForm.MyPoint> getPoints(int keyDisp) //Точки 
        {
            List<Proforientir.StudStatForm.MyPoint> buff = new List<Proforientir.StudStatForm.MyPoint>(); //Список точек для графика
            
            switch (keyDisp) //режим отображения
            {
                case 1: //график посещений мероприятия

                    MySqlConnection conn = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn.Open();
                    string sql = "SELECT COUNT(activity.id_activity), YEAR(date_event) AS year " +
                        "FROM activity " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                           "WHERE action_plan.id_event =  @id " +
                            "GROUP BY year " +
                                "ORDER BY year ";
                   
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    
                        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = _idEvent;
                    
                    MySqlDataReader points = command.ExecuteReader();

                    while (points.Read())
                    {
                        
                            buff.Add(new Proforientir.StudStatForm.MyPoint(Convert.ToInt32(points[1]), Convert.ToInt32(points[0])));
                        
                    }
                    points.Close();
                    conn.Close();

                    return buff;

                case 2: //все мероприятия

                    MySqlConnection conn1 = BDUtils.GetDBConnection(); //Получаем объект, подключенный к бд;

                    conn1.Open();

                    string sql1 = "SELECT AVG(act.parts), name_event " +
                        "FROM event "+
                        "JOIN ("+
                        "SELECT COUNT(activity.id_activity) AS parts, YEAR(date_event) AS year, action_plan.id_event AS id " +
                        "FROM activity " +
                        "JOIN action_plan " +
                        "ON activity.id_action_plan = action_plan.id_action_plan " +
                            "GROUP BY id, year " +
                                "ORDER BY year) AS act "+
                                "ON event.id_event = act.id "+
                                "GROUP BY name_event ";
                    
                    MySqlCommand command1 = new MySqlCommand(sql1, conn1);
                   
                    MySqlDataReader points1 = command1.ExecuteReader();

                    while (points1.Read())
                    {
                        buff.Add(new Proforientir.StudStatForm.MyPoint(Convert.ToString(points1[1]), Convert.ToInt32(points1[0])));

                    }
                    points1.Close();
                    conn1.Close();

                    return buff;
            }
            return buff;
        }

    }
}
