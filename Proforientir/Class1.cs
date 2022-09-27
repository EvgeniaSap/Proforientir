using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proforientir
{
    public class User
    {
        public int Id_account { set; get; } //ID пользователя
        public string Full_name { set; get; } //ФИО пользователя
        public int Id_acc_level { set; get; } //ID уровня доступа
        public string Name_acc_level { set; get; } //Название уровня доступа
        public string Email { set; get; } //Почта
        public Student Info_student { set; get; } //Данные о студенте, если пользователь - студент
        public List<DateEvent> Personal_sched { set; get; } //Расписание мероприятий, в которых участвует;

        public User()
        {
            Info_student = new Student();
            Personal_sched = new List<DateEvent>();
        }

        public User(int id_acc, string full, int id_level, string name_level)
        {
            Id_account = id_acc;
            Full_name = full;
            Id_acc_level = id_level;
            Name_acc_level = name_level;

            Info_student = new Student();
            Info_student = null;
            Personal_sched = new List<DateEvent>();
        }

        public User(int id_acc, string full, int id_level, string name_level, int year1, int year2, int year3, int score, string dir)
        {
            Id_account = id_acc;
            Full_name = full;
            Id_acc_level = id_level;
            Name_acc_level = name_level;

            Info_student = new Student(year1, year2, year3, score, dir);
            
            Personal_sched = new List<DateEvent>();
        }

        public User(string full, int id_level, int id, int year1, int year2, int year3, int score, string dir)
        {
            Full_name = full;
            Id_acc_level = id_level;

            Info_student = new Student(id, year1, year2, year3, score, dir);

            Personal_sched = new List<DateEvent>();
        }

        public User(int id_acc, string full, int id_level, string name_level, string mail)
        {
            Id_account = id_acc;
            Full_name = full;
            Id_acc_level = id_level;
            Name_acc_level = name_level;
            Email = mail;
        }
    }

    public class Student
    {
        public int Id_student { set; get; } //Индекс студента
        public int Entrance_year { set; get; } //Год поступления
        public int Expulsion_year { set; get; } //Год отчисления
        public int End_year { set; get; } //Год окончания
        public int Exam_score { set; get; } //Средний балл ЕГЭ
        public string Direction { set; get; } //Направление подготовки
        public List<Event> Achievement { set; get; } //Список мероприятий, в которых участвовал студент до поступления

        public Student()
        {
            Achievement = new List<Event>();
        }

        public Student(int year1, int year2, int year3, int score, string dir)
        {
            Entrance_year = year1;
            Expulsion_year = year2;
            End_year = year3;
            Exam_score = score;
            Direction = dir;

            Achievement = new List<Event>();
        }

        public Student(int id, int year1, int year2, int year3, int score, string dir)
        {
            Id_student = id;
            Entrance_year = year1;
            Expulsion_year = year2;
            End_year = year3;
            Exam_score = score;
            Direction = dir;

            Achievement = new List<Event>();
        }

    }

    public class Event
    {
        public int Id_event { set; get; } //ID мероприятия
        public string Name_event { set; get; } //Название мероприятия
        public string Name_organizer { set; get; } //Название организатора
        public string Type_organizer { set; get; } //Тип организатора
        public int Id_сategory { set; get; } //ID категории
        public string Category { set; get; } //Название категории

        public Event()
        {

        }

        public Event(int id, string name, string type, int id_cat, string cat_name)
        {
            Id_event = id;
            Name_organizer = name;
            Type_organizer = type;
            Id_сategory = id_cat;
            Category = cat_name;
        }

        public Event(string name, string org, string cat_name)
        {
            Name_event = name;
             Name_organizer = org;
            Category = cat_name;
        }

        public Event(int id, string name, string cat_name, string type)
        {
            Id_event = id;
            Name_event = name;
            Name_organizer = type;
            Category = cat_name;
        }
    }

    public class DateEvent
    {
        public int Id_schedule { set; get; } //ID мероприятия в общем расписании
        public Event Info_event { set; get; } //Данные о мероприятии 
        public string Datetime_event { set; get; } //Дата и время проведения мероприятия
        Dictionary<User, string> Members { set; get; } //Список участников
        //массив с материалами

        public DateEvent()
        {
            Info_event = new Event();
            //Datetime_event = new DateTime();
            Members = new Dictionary<User, string>();
            //dic.Add("YAndeX", my_list[0]);
           // dic.Add("GooGle", my_list[1]);
        }

        public DateEvent(int id_sched, string dt_ev, int id, string name, string type, int id_cat, string cat_name)
        {
            Id_schedule = id_sched;
            Info_event = new Event(id, name, type, id_cat, cat_name);

           // Datetime_event = new DateTime();
            Datetime_event = dt_ev;

            Members = new Dictionary<User, string>();
            
        }

        public DateEvent(int id_sched, string dt_ev, string name, string org, string cat_name)
        {
            Id_schedule = id_sched;
            Info_event = new Event( name, org, cat_name);

            // Datetime_event = new DateTime();
            Datetime_event = dt_ev;

            Members = new Dictionary<User, string>();

        }
    }

    public class Questionnaire
    {
        public int Id_quest { set; get; } //ID анкеты
        public int Id_degree { set; get; } //ID научной степени
        public string Name_degree { set; get; } //Название научной степени
        public int Course { set; get; } //Курс обучения
        public int Level_interest { set; get; } //Уровень заинтересованности в специальности
        public int Сontined_study { set; get; } //В планах продолжить обучение
        public int Job_now { set; get; } //Работает сейчас 
        public int Job_plan { set; get; } //Планирует работать по специальности 
        public int Quest_year { set; get; } //Год проведения анкетирования

        public Questionnaire()
        {

        }

        public Questionnaire(int id_quest, int id_degree, int course, int level, int study, int job1, int job2, int year)
        {
            Id_quest = id_quest;
            Id_degree = id_degree;
            Name_degree = "";
            Course = course;
            Level_interest = level;
            Сontined_study = study;
            Job_now = job1;
            Job_plan = job2;
            Quest_year = year;
        }

    }

}
