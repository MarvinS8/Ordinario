<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loggin.aspx.cs" Inherits="Ordinario.Views.Loggin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de Sesión</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            background-image: url('../images/pasteles.jpg'); /* Cambia esta URL por la imagen deseada */
            background-size: cover;
            background-position: center;
        }
        .login-container {
            background-color: rgba(255, 255, 255, 0.9);
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            width: 300px;
            text-align: center;
        }
        .login-container h2 {
            margin-bottom: 20px;
            color: #333;
        }
        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 10px;
            margin: 10px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }
        .login-container input[type="submit"]:hover {
            background-color: #0056b3;
        }
        .login-container .forgot-password {
            display: block;
            margin-top: 10px;
            color: #007bff;
            text-decoration: none;
        }
        .login-container .forgot-password:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Inicio de Sesión</h2>
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Nombre de usuario" CssClass="form-control" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="form-control" />
            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="form-control" OnClick="btnLogin_Click" />
            <a href="#" class="forgot-password">¿Olvidaste tu contraseña?</a>
        </div>
    </form>
</body>
</html>



