<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Ordinario.Views.Inicio" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Inicio - Tienda de Pasteles</title>
    <style>
         body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-image: url('../images/pasteles.jpg');
            background-size: cover;
            background-position: center;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <!-- Header -->
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Tienda de Pasteles</a>
                    <div class="d-flex">
                        <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" CssClass="btn btn-outline-primary me-3">Iniciar Sesión</asp:LinkButton>
                        <div>
                            <asp:LinkButton ID="btnCarrito" runat="server" OnClick="btnCarrito_Click" CssClass="btn btn-outline-secondary position-relative">
    🛒 Carrito
    <span id="cartCount" runat="server" class="position-absolute top-0 start-100 translate-middle badge rounded-pill bg-danger">
        <%#carritoCount %>
    </span>
</asp:LinkButton>

                        </div>
                    </div>
                </div>
            </nav>

            <!-- Productos -->
            <div class="row mt-4">
                <asp:Repeater ID="rptProductos" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3 mb-4">
                            <div class="card">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                    <p class="card-text">Disponibles: <%# Eval("Cantidad_Disponible") %></p>
                                    <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-primary w-100" CommandArgument='<%# Eval("Id_Pastel") %>' OnCommand="btnAgregarCarrito_Command" />
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
