<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaManager.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaManager" Debug="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Ejercicio Bootstrap</title>
    <script type="text/javascript">
        function validaNumeros(evt) {
            //valida que solo se ingresan números en la caja de texto
            var code = (evt.which) ? evt.which : evt.keyCode;
            if (code == 8) {
                return true;
            } else if (code >= 48 && code <= 57) {
                return true;
            } else {
                return false;
            }
        }

        function validaLetras(e) {
            //valida quer solo ingreses letras y algunos caracteres especiales
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "áéíóúàèìòùüïabcdefghijklmnñopqrstuvwxyz ";
            especiales = "8-37-39-46";
            tecla_especial = false;
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }
            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }

        function validaAlfanumericos(e) {
            var regex = new RegExp("^[a-zA-Z0-9]+$");
            var key = String.fromCharCode(!e.charCode ? e.which : e.charCode);
            if (!regex.test(key)) {
                e.preventDefault();
                return false;
            }
        }
    </script>
</head>
<body>
    <!-- Pagina web -->
    <div class="m-5">
        <form runat="server">
            <asp:ScriptManager ID="ScriptManager2" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div class="text-center">
                <h1 class="mx-auto">Persona</h1>
            </div>
            <!-- Tabla -->
            <div class="row mt-5">
                <div class="text-center">
                    <asp:Label ID="lblAccion" runat="server" Text="Accion" Font-Bold="True" class="mx-a"></asp:Label>
                </div>
                <!--Campos-->
                <div class="mt-2 row justify-content-center">
                    <div class="col-md-5 text-end row">
                        <div class="col-md-8 text-end">
                            <asp:RangeValidator ID="rvClaveUnica" runat="server" class="text-danger" ControlToValidate="txtClaveUnica" ErrorMessage="&quot;La clave unica debe estar entre 100 y 999&quot;" MaximumValue="999" MinimumValue="100" Type="Integer" ValidationGroup="gvSave"></asp:RangeValidator>
                        </div>
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">Clave unica:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtClaveUnica" runat="server" Width="100%" ViewStateMode="Disabled" onkeypress="return validaNumeros(event);" pattern=".{1,3}" title="1 a 3 es la longitud que se permite ingresar"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvClaveUnica" runat="server" class="text-danger" ErrorMessage="&quot;La clave unica es obligatoria&quot;" ControlToValidate="txtClaveUnica" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 row justify-content-end">
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">Sexo:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div>
                                        <asp:DropDownList ID="ddlSexo" runat="server" Width="100%"></asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlSexo" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvSexo" runat="server" class="text-danger" ErrorMessage="&quot;El sexo es obligatorio&quot;" ControlToValidate="ddlSexo" InitialValue="-1" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 text-end row justify-content-end">
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">Nombre:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4 justify-content-end">
                            <asp:TextBox ID="txtNombre" runat="server" Width="100%" ViewStateMode="Disabled" onkeypress="return validaLetras(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" class="text-danger" ControlToValidate="txtNombre" ErrorMessage="&quot;El nombre es obligatorio&quot;" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 text-end row justify-content-end">
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">A Paterno:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAPaterno" runat="server" Width="100%" ViewStateMode="Disabled" onkeypress="return validaLetras(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvAPaterno" runat="server" class="text-danger" ControlToValidate="txtAPaterno" ErrorMessage="&quot;El Apellido Paterno es obligatorio&quot;" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 text-end row justify-content-end">
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">A Materno:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtAMaterno" runat="server" Width="100%" ViewStateMode="Disabled" onkeypress="return validaLetras(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvAMaterno" runat="server" class="text-danger" ControlToValidate="txtAMaterno" ErrorMessage="&quot;El Apellido Materno es obligatorio&quot;" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 text-end row justify-content-end">
                        <div class="col-md-8 text-end">
                            <asp:RegularExpressionValidator ID="revCURP" runat="server" class="text-danger" ErrorMessage="&quot;La CURP es incorrecta&quot;" ValidationExpression="^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{2}(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1])[HM]{1}(AS|BC|BS|CC|CS|CH|CL|CM|DF|DG|GT|GR|HG|JC|MC|MN|MS|NT|NL|OC|PL|QT|QR|SP|SL|SR|TC|TS|TL|VZ|YN|ZS|NE)[B-DF-HJ-NP-TV-Z]{3}[0-9A-Z]{1}[0-9]{1}$" ControlToValidate="txtCURP" ValidationGroup="gvSave"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-4 text-start">
                            <label for="txtClaveUnica">CURP:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtCURP" runat="server" MaxLength="18" Width="100%" onkeypress="return validaAlfanumericos(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvCURP" runat="server" class="text-danger" ControlToValidate="txtCURP" ErrorMessage="&quot;La CURP es obligatoria&quot;" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="mt-1 row justify-content-center">
                    <div class="col-md-5 text-end row justify-content-end">
                        <div class="col-md-4 text-start">
                            <label for="txtFechaNacimiento">Fecha Nacimiento:</label>
                        </div>
                    </div>
                    <div class="col-md-7 row">
                        <div class="col-md-4">
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="85%"></asp:TextBox>
                            <asp:ImageButton ID="imgPopup" ImageUrl="Images/calendar.png" ImageAlign="Bottom" class="col-1" runat="server" CausesValidation="false" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaNacimiento" Format="dd/MM/yyyy" />
                        </div>
                        <div class="col-md-8">
                            <asp:RequiredFieldValidator ID="rfvFechaNacimiento" runat="server" class="text-danger" ControlToValidate="txtFechaNacimiento" ErrorMessage="&quot;La Fecha de Nacimiento es obligatoria&quot;" ValidationGroup="gvSave"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="mt-3 text-danger justify-content-center text-center">
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label>
                </div>
                <div class="mt-2 row justify-content-center">
                    <div class="col-6 text-end">
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" onclick="btnAceptar_Click" ViewStateMode="Disabled" />
                    </div>
                    <div class="col-6">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" ViewStateMode="Disabled" />
                    </div>
                </div>
            </div>
        </form>
    </div>

    <!-- SCRIPTS -->
    <script src="Scripts/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
