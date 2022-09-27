using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Proforientir
{
    public class SendMail
    {
        MailAddress FromAddress { set; get; } //Адрес отправителя
        public MailAddress ToAddress { set; get; } //Адрес получателя
        public string FIO { set; get; } //ФИО получателя
        MailMessage NewMessage { set; get; } //Сообщение
        SmtpClient Client { set; get; } //Клиент SMTP

        public SendMail(string towho, string fio)
        {
            FromAddress = new MailAddress("proforientirsyst@gmail.com", "ProforientirSystem");
            ToAddress = new MailAddress(towho);
            FIO = fio;
        }

        public SendMail()
        {
            FromAddress = new MailAddress("proforientirsyst@gmail.com", "ProforientirSystem");
            ToAddress = new MailAddress("proforientirsyst@gmail.com", "ProforientirSystem");
            FIO = "";
        }

        public async Task SendRegCode(int code)
        {
           // Random rnd = new Random();
            //Получить очередное (в данном случае - первое) случайное число
          //  int code = rnd.Next(10000, 99999);

            NewMessage = new MailMessage(FromAddress, ToAddress);

            NewMessage.Subject = "Доступ в систему Профориентир.";
            NewMessage.Body = "Здравствуйте, " + FIO + "! \n\n" +
                "Вам разрешен доступ в систему кафедры 319 Профориентир.\n" +
                "Для завершения регистрации используйте код " + code + ".\n" +
                "Скорее присоединяйтесь!" +
                "\n\n\n\n\n\n" + "С уважением, администрация кафедры 319.\n\n"+
                "Если у Вас появились вопросы, пишите на нашу почту: "+ FromAddress.Address;

            Client = new SmtpClient("smtp.gmail.com", 587);
            Client.Credentials = new NetworkCredential(FromAddress.Address, "prof*431or");
            Client.EnableSsl = true;

            await Client.SendMailAsync(NewMessage);
           
        }

        public async Task SendNewEvent(DateEvent ev)
        {
            NewMessage = new MailMessage(FromAddress, ToAddress);

            NewMessage.Subject = "Участие в мероприятии.";
            NewMessage.Body = "Здравствуйте, " + FIO + "! \n\n" +
                "Вы записаны на участие: "+ ev.Info_event.Category +" '"+ ev.Info_event.Name_event+ "'.\n" +
                "Мероприятие будет проходить " + ev.Datetime_event + ".\n" +
                "Организатор: " + ev.Info_event.Name_organizer + ".\n" +
                "За подробной информацией обращайтей в администрацию кафедры 319 или по указанному в конце письма адресу." +
                "\n\n\n\n\n\n" + "С уважением, администрация кафедры 319.\n\n" +
                "Если у Вас появились вопросы, пишите на нашу почту: " + FromAddress.Address;

            Client = new SmtpClient("smtp.gmail.com", 587);
            Client.Credentials = new NetworkCredential(FromAddress.Address, "prof*431or");
            Client.EnableSsl = true;

            await Client.SendMailAsync(NewMessage);

        }

        public async Task SendTech(string letter)
        {
            NewMessage = new MailMessage(FromAddress, ToAddress);

            NewMessage.Subject = "Обращение в Техподдержку.";
            NewMessage.Body = letter;

            Client = new SmtpClient("smtp.gmail.com", 587);
            Client.Credentials = new NetworkCredential(FromAddress.Address, "prof*431or");
            Client.EnableSsl = true;

            await Client.SendMailAsync(NewMessage);

        }
    }
    

}
