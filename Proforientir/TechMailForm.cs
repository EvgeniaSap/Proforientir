using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proforientir
{
    public partial class TechMailForm : Form
    {
        private User _user; //Пользователь, загрузивший форму;

        public TechMailForm()
        {
            InitializeComponent();
        }

        public TechMailForm(User user)
        {
            _user = user;

            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) //Назад
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e) //Отправить
        {
            if (!string.IsNullOrEmpty(richtxtLet.Text))
            {
                string letter = "Описание ошибки: \n";
                letter += richtxtLet.Text;
                if (_user != null)
                {
                    letter += "\n\nОт пользователя - id: " + _user.Id_account + ", name: " + _user.Full_name + ". \n";
                }

                try
                {
                    SendMail new_mail = new SendMail();
                    new_mail.SendTech(letter).GetAwaiter();
                    MessageBox.Show("Спасибо за содействие!");

                }
                catch
                {
                    MessageBox.Show("Что-то не так с соединением с Интернетом!");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Отсутствует текст сообщения.");
            }
        }

        private void TechMailForm_Load(object sender, EventArgs e) //Загрузка
        {
            labelName.Text += _user.Full_name;
        }
    }
}
