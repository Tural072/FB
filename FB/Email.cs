using System.Net;
using System.Net.Mail;


namespace FB
{
    static class SendMail
    {
        public static void SendEmail(string content, string message)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("inheretancefake@gmail.com", "StepItAcademy"),
                EnableSsl = true,
            };

            smtpClient.Send("inheretancefake@gmail.com", "inheretancefake@gmail.com", message, content);

        }
    }
}
