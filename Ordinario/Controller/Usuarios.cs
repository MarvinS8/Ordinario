using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Ordinario.Controller
{
    public class Usuarios
    {
        // Método para obtener un usuario por nombre de usuario
        public DataTable ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            // Obtenemos la cadena de conexión del archivo Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["carrito_pastelesConnectionString"].ConnectionString;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand("SELECT id_usuario, nombre_usuario, correo_electronico, contrasena, fecha_creacion FROM usuarios WHERE nombre_usuario = @usuario", connection);
                command.Parameters.AddWithValue("@usuario", nombreUsuario);

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;  // Devolvemos la tabla con los datos del usuario
            }
        }
    }
}