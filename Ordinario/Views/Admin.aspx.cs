using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ordinario.Controller;

namespace Ordinario.Views
{
    public partial class Pagina : System.Web.UI.Page
    {
        ControllerPasteles controller = new ControllerPasteles();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["NombreUsuario"] != null && Session["NombreUsuario"].ToString() == "mlagunas")
            {
                lblUsername.Text = Session["NombreUsuario"].ToString();
            }
            else
            {
                string script = "<script type='text/javascript'>alert('Inicia sesión antes, por favor.'); window.location.href='Loggin.aspx';</script>";
                Response.Write(script);
                Response.End(); // Finaliza el procesamiento de la página

            }
        }
        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            CargarPasteles();
        }

        private void CargarPasteles()
        {
            List<Pastel> pasteles = controller.ObtenerPastel();
            gvPasteles.DataSource = pasteles;
            gvPasteles.DataBind();
        }

        protected void gvPasteles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPasteles.EditIndex = e.NewEditIndex;
            CargarPasteles();
        }

        protected void gvPasteles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idPastel = Convert.ToInt32(gvPasteles.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvPasteles.Rows[e.RowIndex];
            string nombre = (row.Cells[0].Controls[0] as TextBox).Text;
            string sabor = (row.Cells[1].Controls[0] as TextBox).Text;
            string tamaño = (row.Cells[2].Controls[0] as TextBox).Text;
            string ingredientes = (row.Cells[3].Controls[0] as TextBox).Text;

            decimal precio = decimal.Parse((row.FindControl("txtPrecio") as TextBox).Text);
            int cantidad = int.Parse((row.Cells[4].Controls[0] as TextBox).Text);
            DateTime fechaElaboracion = DateTime.Parse((row.FindControl("txtFechaCreacion") as TextBox).Text);

            controller.ActualizarPasteles(idPastel, nombre, sabor, tamaño, precio, ingredientes, fechaElaboracion, cantidad);

            gvPasteles.EditIndex = -1;
            CargarPasteles();
        }

        protected void gvPasteles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idPastel = Convert.ToInt32(gvPasteles.DataKeys[e.RowIndex].Value.ToString());
            controller.EliminarPasteles(idPastel);
            CargarPasteles();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validación de campos obligatorios
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                    throw new Exception("El nombre es obligatorio.");
                if (string.IsNullOrWhiteSpace(txtSabor.Text))
                    throw new Exception("El sabor es obligatorio.");
                if (string.IsNullOrWhiteSpace(txtTamaño.Text))
                    throw new Exception("El tamaño es obligatorio.");
                if (string.IsNullOrWhiteSpace(txtIngredientes.Text))
                    throw new Exception("Los ingredientes son obligatorios.");
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                    throw new Exception("El precio es obligatorio.");
                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                    throw new Exception("La cantidad es obligatoria.");
                if (string.IsNullOrWhiteSpace(txtFechaCreacion.Text))
                    throw new Exception("La fecha de elaboración es obligatoria.");

                // Validación de formato de datos
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                    throw new Exception("El precio debe ser un valor numérico mayor a 0.");
                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                    throw new Exception("La cantidad debe ser un valor numérico mayor a 0.");
                if (!DateTime.TryParse(txtFechaCreacion.Text, out DateTime fechaElaboracion))
                    throw new Exception("La fecha de elaboración no tiene un formato válido.");

                // Insertar datos si todas las validaciones son correctas
                string nombre = txtNombre.Text.Trim();
                string sabor = txtSabor.Text.Trim();
                string tamaño = txtTamaño.Text.Trim();
                string ingredientes = txtIngredientes.Text.Trim();

                controller.InsertarPasteles(0, nombre, sabor, tamaño, precio, ingredientes, fechaElaboracion, cantidad);

                // Recargar la lista de pasteles
                CargarPasteles();

                // Mensaje de éxito
                lblMensaje.Text = "El pastel se ha agregado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvPasteles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPasteles.EditIndex = -1;
            CargarPasteles();
        }
    }
}