using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;

namespace UTTT.Ejemplo.Persona
{
    public class EmailManager
    {

        private String _eMail;

        public EmailManager(String email)
        {
            this._eMail = email;
        }

        public void enviarMensaje()
        {
            MailMessage correo = new MailMessage();
            Configuration c = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)c.GetSectionGroup("system.net/mailSettings");
            correo.From = new System.Net.Mail.MailAddress(settings.Smtp.From, settings.Smtp.Network.UserName, System.Text.Encoding.UTF8); //Correo de salida
            correo.To.Add(_eMail); //Correo destino
            correo.Subject = "ERROR en aplicacion http://www.EduardoRivas.somee.com"; //Asunto
            StringBuilder sb = new StringBuilder();
            sb.Append("ERROR INTERNO: "+DateTime.Now.ToString());
            sb.Append(Environment.NewLine);
            sb.Append(PersonaPrincipal._ultimoError);
            sb.Append(Environment.NewLine);
            correo.Body = sb.ToString(); //Mensaje del correo
            correo.IsBodyHtml = true;
            correo.Priority = MailPriority.Normal;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = settings.Smtp.Network.DefaultCredentials;
            smtp.Host = settings.Smtp.Network.Host; //Host del servidor de correo
            smtp.Port = settings.Smtp.Network.Port; //Puerto de salida
            smtp.Credentials = new System.Net.NetworkCredential(settings.Smtp.From, settings.Smtp.Network.Password); //Cuenta de correo
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = settings.Smtp.Network.EnableSsl;//True si el servidor de correo permite ssl
            smtp.Send(correo);
        }
    }
}