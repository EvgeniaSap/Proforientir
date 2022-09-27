using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace Proforientir
{
    class BDUtils
    {
        public static string host;
        public static string database;
        public static string username;
        public static string password;

        public static MySqlConnection GetDBConnection()
        {
            /*  string host = "localhost";*/
            GetUnits();
            int port = 3306;
            database = "career_guidance";
           // username = "root";
           // password = "";

            return BDmySQL.GetDBConnection(host, port, database, username, password);
        }

        public static void GetUnits()
        {
            string nameFile = @"..\..\units.txt";

            FileInfo file = new FileInfo(nameFile);
            List<string> units = new List<string>();

            if (file.Exists != false) //Если файл существует
            {
                using (StreamReader streamReader = new StreamReader(nameFile)) //Открываем файл для чтения
                {
                    string str = ""; //Объявляем переменную, в которую будем записывать текст из файла

                    while (!streamReader.EndOfStream) //Цикл длиться пока не будет достигнут конец файла
                    {
                        str = streamReader.ReadLine(); //В переменную str по строчно записываем содержимое файла
                        units.Add(str);
                        // host = str;
                    }
                }
            }

            if (units.Count !=0)
            {
                host = units[0];
                username = units[1];
                password = units[2];
            }
        }
    }
}
