using System;
using System.Net;
using System.Windows;
using System.Net.Mail;

namespace MailSender.WPFTest
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            var host = "smtp.yandex.ru";
            var port = 25;

            var user_name = "User name"; //UserNameEditor.Text;
            var password = "Password"; //PasswordEditor.SecurePassword;

            var msg = "Hello World!!! " + DateTime.Now;

            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(user_name, password);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("shmachilin@yandex.ru", "Павел");
                    message.To.Add(new MailAddress("shmachilin@gmail.com", "Павел"));
                    message.Subject = "Заголовок письма от " + DateTime.Now;
                    message.Body = msg;
                    //message.Attachments.Add(new Attachment());

                    try
                    {
                        client.Send(message);
                        MessageBox.Show("Почта успешно отправлена",
                            "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message,
                            "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
