<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonaPrincipal.aspx.cs" Inherits="UTTT.Ejemplo.Persona.PersonaPrincipal" debug="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Ejercicio Bootstrap</title>
</head>
<body>
    <!-- Pagina web -->
    <div class="m-5">
        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
            <div class="text-center">
                <h1 class="mx-auto">Persona</h1>
            </div>
            <!-- Barra de busqueda -->
            <div class="row mt-3">
                <div class="mt-3 col-md-8 row">
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
            </div>
            <!-- Tabla -->
            <div class="row mt-5">
                <div class="text-center">
                    <h3 class="mx-auto">Detalle</h3>
                </div>
                <!--Tabla para dispositivos grandes-->
                <asp:GridView ID="dgvPersonas" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersona"
                    Width="100%" CellPadding="3" GridLines="Horizontal"
                    OnRowCommand="dgvPersonas_RowCommand" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    ViewStateMode="Disabled" class="table table-sm mt-2 d-none d-md-table">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="strClaveUnica" HeaderText="Clave Unica"
                            ReadOnly="True" SortExpression="strClaveUnica" />
                        <asp:BoundField DataField="strNombre" HeaderText="Nombre" ReadOnly="True"
                            SortExpression="strNombre" />
                        <asp:BoundField DataField="strAPaterno" HeaderText="APaterno" ReadOnly="True"
                            SortExpression="strAPaterno"/>
                        <asp:BoundField DataField="strAMaterno" HeaderText="AMaterno" ReadOnly="True"
                            SortExpression="strAMaterno" />
                        <asp:BoundField DataField="CatSexo" HeaderText="Sexo"
                            SortExpression="CatSexo" />
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
                <!--Tabla para dispositivos pequeños-->
                <asp:GridView ID="GridView1" runat="server"
                    AllowPaging="True" AutoGenerateColumns="False" DataSourceID="DataSourcePersona"
                    Width="100%" CellPadding="3" GridLines="Horizontal"
                    OnRowCommand="dgvPersonas_RowCommand" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                    ViewStateMode="Disabled" class="table table-sm mt-2 d-table d-md-none">
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
        </form>
    </div>

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
