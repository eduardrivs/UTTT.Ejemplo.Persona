using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UTTT.Ejemplo.Persona
{
    public partial class ErrorPage1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //edel.meza@uttt.edu.mx
            EmailManager ob = new EmailManager("19300671@uttt.edu.mx");
            ob.enviarMensaje(PersonaPrincipal._ultimoError.ToString());
        }
    }
}