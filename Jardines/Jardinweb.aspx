<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jardinweb.aspx.cs" Inherits="Jardines.Jardinweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel ID="PanelRegistro" runat="server" Visible="False">
                    
            <h1> Registrar Jardin</h1>
            <div class="row">
                <asp:TextBox ID="TextIdJardin" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="TextNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="Label3" runat="server" Text="Direccion"></asp:Label>
                <asp:TextBox ID="TextDireccion" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
                <asp:DropDownList ID="ddlestado" runat="server">
                    <asp:ListItem>Aprobado</asp:ListItem>
                    <asp:ListItem>En tramite</asp:ListItem>
                    <asp:ListItem>Negado</asp:ListItem>
                </asp:DropDownList>
                
            </div>
                <asp:Label ID="lblMensaje" runat="server" Text="" Font-Size="Medium"></asp:Label>

             <div class="row">
                 <asp:Button ID="btnRegistrar" runat="server" Text="Registrar"  CssClass="btn btn-success" OnClick="btnRegistrar_Click"/>
                 <asp:Button ID="btnEditar" runat="server" Text="Editar"  CssClass="btn btn-success" OnClick="btnEditarClick" Visible="False"/>
                 
            </div>
              </asp:Panel>
                <asp:Panel ID="PanelConsulta" runat="server">
                    <h1> Lista de Jardines</h1>
                    
                    <asp:Button ID="BtnNuevo" runat="server" Text="Nuevo" OnClick="BtnNuevo_Click" />
                             <asp:GridView ID="gdvjardines" runat="server" CssClass="table table-dark" AutoGenerateColumns="False" OnRowCommand="gdvjardines_RowCommand">

                                 <Columns>
                                     <asp:BoundField DataField="Identificador" HeaderText="Identificador" />
                                     <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                     <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                     <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                     <asp:TemplateField HeaderText="Acciones">
                                         <ItemTemplate> 

                                             <asp:ImageButton ID="imgBtnEditar" runat="server" ImageUrl="/img/Editar.png" Width="25px" CommandName="Editar" ></asp:ImageButton>
                                             <asp:ImageButton ID="imgBtnEliminar" runat="server" ImageUrl="/img/Eliminar.png" Width="25px" CommandName="Eliminar"></asp:ImageButton>
                                       

                                         </ItemTemplate>
                                     </asp:TemplateField>
                                 </Columns>

</asp:GridView>
               
                    </asp:Panel>
           
        </div>
    </form>
</body>
</html>
