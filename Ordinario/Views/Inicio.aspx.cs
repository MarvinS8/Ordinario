using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ordinario.Controller; // Asegúrate de importar el espacio de nombres del controlador

namespace Ordinario.Views
{
    public partial class Inicio : System.Web.UI.Page
    {
        private static List<Pastel> productos = new List<Pastel>();
        public static int carritoCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ControllerPasteles controller = new ControllerPasteles();
            productos = controller.ObtenerPastel();  // Obtén los productos actualizados desde la base de datos

            rptProductos.DataSource = productos;
            rptProductos.DataBind();  // Vincula los productos con el Repeater
        }

        protected void btnAgregarCarrito_Command(object sender, CommandEventArgs e)
        {
            int idProducto = int.Parse(e.CommandArgument.ToString());
            var producto = productos.Find(p => p.ID_Pastel == idProducto);

            if (producto != null && producto.Cantidad_Disponible > 0)
            {
                // Reducir la cantidad local
                producto.Cantidad_Disponible--;

                // Actualizar la cantidad en la base de datos
                ControllerPasteles controller = new ControllerPasteles();
                controller.ActualizarCantidadDisponible(producto.ID_Pastel, producto.Cantidad_Disponible);

                // Agregar el producto al carrito en la sesión
                List<Pastel> carrito = Session["Carrito"] as List<Pastel>;
                if (carrito == null)
                {
                    carrito = new List<Pastel>();
                }
                carrito.Add(producto);
                Session["Carrito"] = carrito;

                // Incrementar el contador del carrito
                carritoCount++;
                cartCount.InnerText = carritoCount.ToString();

                // Recargar los productos para mostrar los cambios
                CargarProductos();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loggin.aspx");
        }
        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            // Redirige a la página Carrito.aspx
            Response.Redirect("Carrito.aspx");
        }


    }
}
