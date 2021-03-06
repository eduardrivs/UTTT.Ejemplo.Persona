<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaPrincipal.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaPrincipal" Debug="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ejercicio Bootstrap</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Awesome -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" rel="stylesheet" />
    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" rel="stylesheet" />

</head>
<body style="text-size-adjust:200%;">
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <!--Navbar-->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark p-3 fixed-top" style="position:sticky;">
            <div class="container-fluid">
                <a class="navbar-brand" href="PersonaPrincipal.aspx">Proyecto Persona</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <%--<a class="nav-link active" aria-current="page" href="#">Agregar nueva persona</a>--%>
                            <asp:Button ID="btnAgregar" class="btn btn-link nav-link active mt-2 mt-lg-0" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ViewStateMode="Disabled" />
                        </li>
                    </ul>
                    <div class="d-flex">
                        <div class="nav-item dropdown">
                            <div class="me-3">
                                <asp:DropDownList ID="ddlSexo" class="btn btn-secondary dropdown-toggle" runat="server" />
                            </div>
                        </div>
                        <%--<input class="form-control me-2" type="search" placeholder="Nombre de persona" aria-label="Search" />--%>
                        <asp:TextBox ID="txtNombre" class="form-control me-3" runat="server" Width="50%" OnTextChanged="buscarTextBox" AutoPostBack="true"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" EnableCaching="false" MinimumPrefixLength="2" ServiceMethod="onTxtNombreTextChange" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
                        <%--<button class="btn btn-outline-success" type="submit">Buscar</button>--%>
                        <asp:Button ID="btnBuscar" class="btn btn-outline-success" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ViewStateMode="Disabled" />
                    </div>
                </div>
            </div>
        </nav>
        <!-- Pagina web -->
        <div class="m-5"">

            <div class="text-center">
                <h1 class="mx-auto">Persona Detalle</h1>
            </div>
            <!-- Barra de busqueda -->
            <%--<div class="row mt-3">
                <div class="mt-3 col-md-8">
                    <div class="row">
                        <div>Busqueda de usuarios por nombre o sexo</div>
                        <div class="row col-md-5 mt-2">
                            <div class="col-5">
                                <label for="txtNombre" class="col-form-label">Nombre:</label>
                            </div>
                            <div class="col-7">
                                <asp:TextBox ID="txtNombre" class="form-control" runat="server" Width="100%" OnTextChanged="buscarTextBox" AutoPostBack="true"></asp:TextBox>
                                <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" EnableCaching="false" MinimumPrefixLength="2" ServiceMethod="onTxtNombreTextChange" TargetControlID="txtNombre"></ajaxToolkit:AutoCompleteExtender>
                            </div>
                        </div>
                        <div class="row col-md-7 mt-2">
                            <div class="col-2 col-md-2">
                                <label for="ddlSexo" class="col-form-label">Sexo:</label>
                            </div>
                            <div class="col-6 col-md-4">
                                <asp:DropDownList ID="ddlSexo" class="btn btn-secondary dropdown-toggle" runat="server" />
                            </div>
                            <div class="col-4 col-md-6">
                                <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ViewStateMode="Disabled" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mt-3 col-md-4">
                    <div>Agregar un usuario nuevo</div>
                    <asp:Button ID="btnAgregar" class="mt-2 btn btn-secondary" runat="server" Text="Agregar" OnClick="btnAgregar_Click" ViewStateMode="Disabled" />
                </div>
            </div>--%>
            <!-- Tabla -->
            <div class="row mt-5">
                <!--Tabla para dispositivos grandes-->
                <asp:GridView ID="dgvPersonas" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersona"
                    Width="100%" CellPadding="3" GridLines="Horizontal"
                    OnRowCommand="dgvPersonas_RowCommand" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    ViewStateMode="Disabled" class="table table-sm mt-2 d-none d-lg-table">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="strClaveUnica" HeaderText="Clave Unica"
                            ReadOnly="True" SortExpression="strClaveUnica" />
                        <asp:BoundField DataField="strNombre" HeaderText="Nombre" ReadOnly="True"
                            SortExpression="strNombre" />
                        <asp:BoundField DataField="strAPaterno" HeaderText="APaterno" ReadOnly="True"
                            SortExpression="strAPaterno" />
                        <asp:BoundField DataField="strAMaterno" HeaderText="AMaterno" ReadOnly="True"
                            SortExpression="strAMaterno" />
                        <asp:BoundField DataField="CatSexo" HeaderText="Sexo"
                            SortExpression="CatSexo" />
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png"/>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar" Visible="True">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/delrecord_16x16.png" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Direccion">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDireccion" CommandName="Direccion" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px"/>

                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <!--Tabla para dispositivos pequeños-->
                <asp:GridView ID="GridView1" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersona"
                    Width="100%" CellPadding="3" GridLines="Horizontal"
                    OnRowCommand="dgvPersonas_RowCommand" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    ViewStateMode="Disabled" class="table table-sm mt-2 d-table d-lg-none">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="strClaveUnica" HeaderText="Clave Unica"
                            ReadOnly="True" SortExpression="strClaveUnica" />
                        <asp:BoundField DataField="strNombre" HeaderText="Nombre" ReadOnly="True"
                            SortExpression="strNombre" />
                        <asp:TemplateField HeaderText="Editar">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEditar" CommandName="Editar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />

                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Eliminar" Visible="True">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgEliminar" CommandName="Eliminar" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/delrecord_16x16.png" OnClientClick="javascript:return confirm('¿Está seguro de querer eliminar el registro seleccionado?', 'Mensaje de sistema')" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Direccion">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="imgDireccion" CommandName="Direccion" CommandArgument='<%#Bind("id") %>' ImageUrl="~/Images/editrecord_16x16.png" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="50px" />

                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
        </div>
    </form>

    <!-- Footer -->
    <footer class="bg-dark text-center text-white text-lg-start fixed-bottom" style="position:sticky">
        <!-- Section: Social media -->
        <section
            class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom">
            <!-- Left -->
            <div class="me-5 d-none d-lg-block">
                <span>19300671 · Jose Eduardo Rivas Cuevas · 8IDGS</span>
            </div>
            <!-- Left -->

            <!-- Right -->
            <div class="row">
                <div class="col-auto me-4">
                    <a href="https://www.facebook.com/ed.rivas17/" class="text-reset"><i class="fab fa-facebook-f"></i></a>
                </div>
                <div href="" class="col-auto me-4">
                    <a href="https://twitter.com/EduardoRvas" class="text-reset"><i class="fab fa-twitter"></i></a>
                </div>
                <div href="" class="col-auto me-4">
                    <a href="https://www.instagram.com/eduardrivs/" class="text-reset"><i class="fab fa-instagram"></i></a>
                </div>
                <div href="" class="col-auto me-4">
                    <a href="https://www.linkedin.com/in/eduardorivascuevas/" class="text-reset"><i class="fab fa-linkedin"></i></a>
                </div>
                <div href="" class="col-auto me-4 text-reset">
                    <a href="https://github.com/eduardrivs" class="text-reset"><i class="fab fa-github"></i></a>
                </div>
            </div>
            <!-- Right -->
        </section>
        <!-- Section: Social media -->

        <!-- Copyright -->
        <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
            Universidad Tecnologica de Tula Tepeji - Desarrollo Web Profesional
        </div>
        <!-- Copyright -->
    </footer>
    <!-- Footer -->

    <asp:LinqDataSource ID="DataSourcePersona" runat="server"
        ContextTypeName="UTTT.Ejemplo.Linq.Data.Entity.DcGeneralDataContext"
        OnSelecting="DataSourcePersona_Selecting"
        Select="new (strNombre, strAPaterno, strAMaterno, CatSexo, strClaveUnica,id)"
        TableName="Persona" EntityTypeName="">
    </asp:LinqDataSource>

    <!-- SCRIPTS -->
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
