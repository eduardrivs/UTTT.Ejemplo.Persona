﻿#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UTTT.Ejemplo.Linq.Data.Entity;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Collections;
using UTTT.Ejemplo.Persona.Control;
using UTTT.Ejemplo.Persona.Control.Ctrl;
using System.Text.RegularExpressions;

#endregion

namespace UTTT.Ejemplo.Persona
{
    public partial class PersonaManager : System.Web.UI.Page
    {
        #region Variables

        private SessionManager session = new SessionManager();
        private int idPersona = 0;
        private UTTT.Ejemplo.Linq.Data.Entity.Persona baseEntity;
        private DataContext dcGlobal = new DcGeneralDataContext();
        private int tipoAccion = 0;

        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.Response.Buffer = true;
                this.session = (SessionManager)this.Session["SessionManager"];
                this.idPersona = this.session.Parametros["idPersona"] != null ?
                    int.Parse(this.session.Parametros["idPersona"].ToString()) : 0;
                if (this.idPersona == 0)
                {
                    this.baseEntity = new Linq.Data.Entity.Persona();
                    this.tipoAccion = 1;
                }
                else
                {
                    this.baseEntity = dcGlobal.GetTable<Linq.Data.Entity.Persona>().First(c => c.id == this.idPersona);
                    this.tipoAccion = 2;
                }

                if (!this.IsPostBack)
                {
                    if (this.session.Parametros["baseEntity"] == null)
                    {
                        this.session.Parametros.Add("baseEntity", this.baseEntity);
                    }
                    List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().ToList();
                    CatSexo catTemp = new CatSexo();
                    catTemp.id = -1;
                    catTemp.strValor = "Seleccionar";
                    lista.Insert(0, catTemp);
                    this.ddlSexo.DataTextField = "strValor";
                    this.ddlSexo.DataValueField = "id";
                    this.ddlSexo.DataSource = lista;
                    this.ddlSexo.DataBind();

                    this.ddlSexo.SelectedIndexChanged += new EventHandler(ddlSexo_SelectedIndexChanged);
                    this.ddlSexo.AutoPostBack = true;
                    if (this.idPersona == 0)
                    {
                        this.lblAccion.Text = "Agregar";
                    }
                    else
                    {
                        this.lblAccion.Text = "Editar";
                        this.txtNombre.Text = this.baseEntity.strNombre;
                        this.txtAPaterno.Text = this.baseEntity.strAPaterno;
                        this.txtAMaterno.Text = this.baseEntity.strAMaterno;
                        this.txtClaveUnica.Text = this.baseEntity.strClaveUnica;
                        this.txtCURP.Text = this.baseEntity.strCurp;
                        this.setItem(ref this.ddlSexo, baseEntity.CatSexo.strValor);
                    }                
                }

            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un problema al cargar la página");
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtClaveUnica.Text.Trim().Equals("") && this.txtNombre.Text.Trim().Equals("") && this.txtAPaterno.Text.Trim().Equals("") && this.txtAMaterno.Text.Trim().Equals("") &&
                this.txtCURP.Text.Trim().Equals("") && int.Parse(this.ddlSexo.Text).Equals(-1))
                {
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                }
                else
                {
                    btnAceptar.ValidationGroup = "gvSave";
                    Page.Validate("gvSave");
                }

                if (!Page.IsValid)
                {
                    return;
                }
                DataContext dcGuardar = new DcGeneralDataContext();
                UTTT.Ejemplo.Linq.Data.Entity.Persona persona = new Linq.Data.Entity.Persona();
                if (this.idPersona == 0)
                {
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.strCurp = this.txtCURP.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);

                    String mensaje = String.Empty;
                    int pos = 0;
                    string correct = "";
                    //validacion de datos correctos desde codigo
                    if(!this.validacion(persona, ref mensaje, ref pos, ref correct))
                    {
                        if (pos == 0)
                        {
                            this.lblMensaje.Text = mensaje;
                            this.lblMensaje.Visible = true;
                            return;
                        }
                        else
                        {
                            switch (pos)
                            {
                                case 1:
                                    persona.strNombre = correct;
                                    break;
                                case 2:
                                    persona.strAPaterno= correct;
                                    break;
                                case 3:
                                    persona.strAMaterno= correct;
                                    break;
                                default:
                                    this.lblMensaje.Text = "Revise los datos ingresados";
                                    this.lblMensaje.Visible = true;
                                    return;
                            }
                        }
                        
                    }

                    dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().InsertOnSubmit(persona);
                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se agrego correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                    
                }
                if (this.idPersona > 0)
                {
                    persona = dcGuardar.GetTable<UTTT.Ejemplo.Linq.Data.Entity.Persona>().First(c => c.id == idPersona);
                    persona.strClaveUnica = this.txtClaveUnica.Text.Trim();
                    persona.strNombre = this.txtNombre.Text.Trim();
                    persona.strAMaterno = this.txtAMaterno.Text.Trim();
                    persona.strAPaterno = this.txtAPaterno.Text.Trim();
                    persona.strCurp = this.txtCURP.Text.Trim();
                    persona.idCatSexo = int.Parse(this.ddlSexo.Text);

                    String mensaje = String.Empty;
                    int pos = 0;
                    string correct = "";
                    //validacion de datos correctos desde codigo
                    if (!this.validacion(persona, ref mensaje, ref pos, ref correct))
                    {
                        if (pos == 0)
                        {
                            this.lblMensaje.Text = mensaje;
                            this.lblMensaje.Visible = true;
                            return;
                        }
                        else
                        {
                            switch (pos)
                            {
                                case 1:
                                    persona.strNombre = correct;
                                    break;
                                case 2:
                                    persona.strAPaterno = correct;
                                    break;
                                case 3:
                                    persona.strAMaterno = correct;
                                    break;
                                default:
                                    this.lblMensaje.Text = "Revise los datos ingresados";
                                    this.lblMensaje.Visible = true;
                                    return;
                            }
                        }
                    }

                    dcGuardar.SubmitChanges();
                    this.showMessage("El registro se edito correctamente.");
                    this.Response.Redirect("~/PersonaPrincipal.aspx", false);
                }
            }
            catch (Exception _e)
            {
                this.showMessageException(_e.Message);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {              
                this.Response.Redirect("~/PersonaPrincipal.aspx", false);
            }
            catch (Exception _e)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idSexo = int.Parse(this.ddlSexo.Text);
                Expression<Func<CatSexo, bool>> predicateSexo = c => c.id == idSexo;
                predicateSexo.Compile();
                List<CatSexo> lista = dcGlobal.GetTable<CatSexo>().Where(predicateSexo).ToList();
                CatSexo catTemp = new CatSexo();
                this.ddlSexo.DataTextField = "strValor";
                this.ddlSexo.DataValueField = "id";
                this.ddlSexo.DataSource = lista;
                this.ddlSexo.DataBind();
            }
            catch (Exception)
            {
                this.showMessage("Ha ocurrido un error inesperado");
            }
        }

        #endregion

        #region Metodos

        public void setItem(ref DropDownList _control, String _value)
        {
            foreach (ListItem item in _control.Items)
            {
                if (item.Value == _value)
                {
                    item.Selected = true;
                    break;
                }
            }
            _control.Items.FindByText(_value).Selected = true;
        }

        #region validación codigo

        /// <summary>
        /// Valida datos básicos
        /// </summary>
        /// <param name="_persona"></param>
        /// <param name="_mensaje"></param>
        /// <returns></returns>

        public bool validacion(UTTT.Ejemplo.Linq.Data.Entity.Persona _persona, ref String _mensaje, ref int _pos, ref String _correct)
        {
            _pos = 0;
            _correct = "";

            if(_persona.idCatSexo == -1)
            {
                _mensaje = "Seleccione Masculino o Femenino";
                return false;
            }

            int i = 0;
            //Verifica si un texto es un número
            if(int.TryParse(_persona.strClaveUnica, out i) == false)
            {
                _mensaje = "La clave unica no es un número";
                return false;
            }

            ///validamos un numero
            ///string, saber que es un numero
            ///99 y 1000
            if(int.Parse(_persona.strClaveUnica) < 100 || int.Parse(_persona.strClaveUnica) > 999)
            {
                _mensaje = "La clave unica esta fuera de rango";
                return false;
            }

            if (_persona.strNombre.Equals(String.Empty))
            {
                _mensaje = "El nombre esta vacio";
                return false;
            }

            if(_persona.strNombre.Length > 50)
            {
                _persona.strNombre = Regex.Replace(_persona.strNombre, @"\s{2,}", " ");
                if (_persona.strNombre.Length > 50)
                {
                    _mensaje = "Los caracteres permitidos para nombre rebasan lo permitido (50 caracteres)";
                    return false;
                }
            }

            if (!Regex.IsMatch(_persona.strNombre, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙüïÏÜ ]+$"))
            {
                _mensaje = "Los caracteres insertados para 'Nombre' no son permitidos";
                return false;
            }

            if(_persona.strNombre.Length < 3)
            {
                _mensaje = "El nombre debe tener 3 o más caracteres";
                return false;
            }

            if(Regex.IsMatch(_persona.strNombre, @"\s{2,}"))
            {
                _pos = 1;
                _correct = Regex.Replace(_persona.strNombre, @"\s{2,}", " ");
                return false;
            }

            if(Regex.IsMatch(_persona.strNombre, @"(.)\1{2,}"))
            {
                _mensaje = "El nombre tiene caracteres repetidos que no son correctos";
                return false;
            }

            if (_persona.strAPaterno.Equals(String.Empty))
            {
                _mensaje = "El apellido paterno esta vacio";
                return false;
            }

            if (_persona.strAPaterno.Length > 50)
            {
                _persona.strAPaterno = Regex.Replace(_persona.strAPaterno, @"\s{2,}", " ");
                if (_persona.strAPaterno.Length > 50)
                {
                    _mensaje = "Los caracteres permitidos para apellido paterno rebasan lo permitido (50 caracteres)";
                    return false;
                }
            }

            if (!Regex.IsMatch(_persona.strAPaterno, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙüïÏÜ ]+$"))
            {
                _mensaje = "Los caracteres insertados para 'Apellido Paterno' no son permitidos";
                return false;
            }

            if (_persona.strAPaterno.Length < 3)
            {
                _mensaje = "El Apellido Paterno debe tener 3 o más caracteres";
                return false;
            }

            if (Regex.IsMatch(_persona.strAPaterno, @"\s{2,}"))
            {
                _pos = 2;
                _correct = Regex.Replace(_persona.strAPaterno, @"\s{2,}", " ");
                return false;
            }

            if (_persona.strAMaterno.Equals(String.Empty))
            {
                _mensaje = "El apellido materno esta vacio";
                return false;
            }

            if (_persona.strAMaterno.Length > 50)
            {
                _persona.strAMaterno = Regex.Replace(_persona.strAMaterno, @"\s{2,}", " ");
                if (_persona.strAMaterno.Length > 50)
                {
                    _mensaje = "Los caracteres permitidos para apellido materno rebasan lo permitido (50 caracteres)";
                    return false;
                }
            }

            if (Regex.IsMatch(_persona.strAPaterno, @"(.)\1{2,}"))
            {
                _mensaje = "El apellido paterno tiene caracteres repetidos que no son correctos";
                return false;
            }

            if (!Regex.IsMatch(_persona.strAMaterno, @"^[a-zA-ZñÑáéíóúÁÉÍÓÚàèìòùÀÈÌÒÙüïÏÜ ]+$"))
            {
                _mensaje = "Los caracteres insertados para 'Apellido Materno' no son permitidos";
                return false;
            }

            if (_persona.strAMaterno.Length < 3)
            {
                _mensaje = "El Apellido Materno debe tener 3 o más caracteres";
                return false;
            }

            if (Regex.IsMatch(_persona.strAMaterno, @"\s{2,}"))
            {
                _pos = 3;
                _correct = Regex.Replace(_persona.strAMaterno, @"\s{2,}", " ");
                return false;
            }

            if (Regex.IsMatch(_persona.strAMaterno, @"(.)\1{2,}"))
            {
                _mensaje = "El apellido materno tiene caracteres repetidos que no son correctos";
                return false;
            }

            if (_persona.strCurp.Equals(String.Empty))
            {
                _mensaje = "La CURP no puede estar vacia";
                return false;
            }

            if(_persona.strCurp.Length > 18 || _persona.strCurp.Length<18)
            {
                _mensaje = "La CURP no cumple con los requisitos solicitados";
                return false;
            }

            return true;

        }

        #endregion

        #endregion
    }
}