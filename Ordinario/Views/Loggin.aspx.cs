using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ordinario.Controller;

namespace Ordinario.Views
{
    public partial class Loggin : System.Web.UI.Page
    {
        Usuarios usuariosController = new Usuarios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Response.Write("<script>alert('Por favor ingrese su usuario y contraseña.');</script>");
                return;
            }

            //Controller
            DataTable usuario = usuariosController.ObtenerUsuarioPorNombre(username);

            if (usuario != null && usuario.Rows.Count > 0)
            {
                string storedPassword = usuario.Rows[0]["contrasena"].ToString();
                AESCryptography aesCryptography = new AESCryptography();
                string decryptedPassword = aesCryptography.Decrypt(storedPassword);


                if (decryptedPassword == password)
                {
                    Session["NombreUsuario"] = usuario.Rows[0]["nombre_usuario"].ToString();
                    Response.Redirect("Admin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Contraseña incorrecta.');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Usuario no encontrado.');</script>");
            }
            Response.Redirect("Admin.aspx");
        }
    }
}