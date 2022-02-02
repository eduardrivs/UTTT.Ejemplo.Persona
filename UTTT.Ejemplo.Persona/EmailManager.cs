using System;
using System.Configuration;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace UTTT.Ejemplo.Persona
{
    public class EmailManager
    {

        private String _eMail;

        public EmailManager(String email)
        {
            this._eMail = email;
        }

        public void enviarMensaje(String mensaje)
        {
            var fromAddress = new MailAddress("eduardo.rivas.uttt@gmail.com");
            var toAddress = new MailAddress(_eMail);
            const string fromPassword = "Uurxi!5b.F8tAYQ";
            const string subject = "ERROR en sitio http://www.EduardoRivas.somee.com";
            var body = "Error del "+System.DateTime.Now.ToString()+"\n\n"+mensaje;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}