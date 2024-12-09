<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Ordinario.Views.Carrito" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Carrito - Tienda de Pasteles</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .product-card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s ease-in-out;
        }

            .product-card:hover {
                transform: scale(1.05);
            }

            .product-card .card-body {
                text-align: center;
            }

        .badge-custom {
            background-color: #ff6f61;
        }

        .total-section {
            font-weight: bold;
            font-size: 1.2rem;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .btn-custom {
            background-color: #28a745;
            color: white;
            width: 100%;
        }

            .btn-custom:hover {
                background-color: #218838;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <h1 class="text-center mb-4">Carrito de Compras</h1>

            <!-- Carrito -->
            <div class="row">
                <asp:Repeater ID="rptCarrito" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card product-card">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                    <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                                    <p class="card-text">Cantidad: <%# Eval("Cantidad_Disponible") %></p>
                                    <!-- Mostrar cantidad real -->
                                    <p class="card-text">Total: $<%# Convert.ToDecimal(Eval("Precio")) * Convert.ToInt32(Eval("Cantidad_Disponible")) %></p>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- Formulario para datos del usuario -->
            <div class="mt-4">
                <h3>Datos del Usuario</h3>
                <div class="form-group">
                    <label for="txtNombre">Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingresa tu nombre"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label for="txtCorreo">Correo:</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Ingresa tu correo"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="form-group mt-2">
                    <label for="txtTelefono">Teléfono:</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Ingresa tu teléfono"></asp:TextBox>
                </div>
            </div>
            <!-- Total y botón para finalizar compra -->
            <div class="mt-4 total-section">
                <h3>Total:
                    <asp:Label ID="totalCarritoLabel" runat="server" Text="0"></asp:Label></h3>
                <asp:Button ID="btnFinalizar" runat="server" CssClass="btn btn-custom" Text="Finalizar Compra" OnClick="btnFinalizar_Click" />
            </div>

        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

