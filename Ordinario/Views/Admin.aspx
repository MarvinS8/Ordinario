<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Ordinario.Views.Pagina" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Gestión de Pasteles</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f4f4f9;
            box-sizing: border-box;
        }

        .container {
            width: 100%;
            max-width: 900px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            box-sizing: border-box;
        }

        h1, h2 {
            text-align: center;
            color: #333;
        }

        .btn {
            padding: 10px 20px;
            margin: 5px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 14px;
            color: white;
        }

        .btn-agregar {
            background-color: #28a745;
        }

        .btn-editar {
            background-color: #007bff;
        }

        .btn-eliminar {
            background-color: #dc3545;
        }

        .grid-view {
            margin-top: 20px;
            overflow-x: auto;
        }

            .grid-view table {
                width: 100%;
                border-collapse: collapse;
            }

            .grid-view th, .grid-view td {
                padding: 10px;
                text-align: left;
                border: 1px solid #ddd;
            }

            .grid-view th {
                background-color: #007bff;
                color: white;
            }
    </style>
</head>
<body>
    <form runat="server">
        <div class="container">
            <h1>Gestión de Pasteles</h1>
            <p>Hola,<asp:Label ID="lblUsername" runat="server" Text=""></asp:Label></p>
            <asp:Button ID="btnMostrar" runat="server" CssClass="btn btn-agregar" Text="Mostrar Pasteles" OnClick="btnMostrar_Click" />

            <asp:GridView ID="gvPasteles" runat="server" CssClass="grid-view" AutoGenerateColumns="False" DataKeyNames="Id_Pastel"
                OnRowEditing="gvPasteles_RowEditing"
                OnRowUpdating="gvPasteles_RowUpdating"
                OnRowCancelingEdit="gvPasteles_RowCancelingEdit"
                OnRowDeleting="gvPasteles_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Sabor" HeaderText="Sabor" />
                    <asp:BoundField DataField="Tamaño" HeaderText="Tamaño" />
                    <asp:BoundField DataField="Ingredientes" HeaderText="Ingredientes" />
                    <asp:BoundField DataField="Cantidad_Disponible" HeaderText="Cantidad Disponible" />
                    <asp:TemplateField HeaderText="Precio">
                        <ItemTemplate>
                            <%# Eval("Precio", "{0:C}") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Bind("Precio") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha de Creación">
                        <ItemTemplate>
                            <%# Eval("Fecha_Elaboración", "{0:dd/MM/yyyy}") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFechaCreacion" runat="server" Text='<%# Bind("Fecha_Elaboración", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" ButtonType="Button" EditText="Editar" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Eliminar" />
                </Columns>
            </asp:GridView>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>

        <div class="container">
            <h2>Agregar Nuevo Pastel</h2>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtSabor">Sabor:</label>
                <asp:TextBox ID="txtSabor" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtTamaño">Tamaño:</label>
                <asp:TextBox ID="txtTamaño" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtIngredientes">Ingredientes:</label>
                <asp:TextBox ID="txtIngredientes" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCantidad">Cantidad Disponible:</label>
                <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtPrecio">Precio:</label>
                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFechaCreacion">Fecha de Creación:</label>
                <asp:TextBox ID="txtFechaCreacion" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-agregar" Text="Agregar Pastel" OnClick="btnAgregar_Click" />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>