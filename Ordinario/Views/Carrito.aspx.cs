using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ordinario.Controller; // Asegúrate de importar el espacio de nombres del controlador
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Ordinario.Views
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected List<Pastel> carritoProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                // Obtiene los productos específicos del carrito
                List<Pastel> carrito = (List<Pastel>)Session["Carrito"];

                // Agrupa por ID y calcula la cantidad real en el carrito
                var productosAgrupados = carrito
                    .GroupBy(p => p.ID_Pastel)
                    .Select(g => new Pastel
                    {
                        ID_Pastel = g.Key,
                        Nombre = g.First().Nombre,
                        Precio = g.First().Precio,
                        Cantidad_Disponible = g.Count() // Cantidad en el carrito
            }).ToList();

                // Asignar los productos agrupados al Repeater
                rptCarrito.DataSource = productosAgrupados;
                rptCarrito.DataBind();

                // Calcula el total del carrito
                decimal totalCarrito = productosAgrupados.Sum(p => p.Precio * p.Cantidad_Disponible);
                totalCarritoLabel.Text = totalCarrito.ToString("C2");
            }
        }
        protected decimal GetTotalCarrito()
        {
            if (Session["Carrito"] != null)
            {
                List<Pastel> carrito = (List<Pastel>)Session["Carrito"];
                return carrito.Sum(p => p.Precio);  // Calcula el total del carrito
            }
            return 0;
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos del usuario
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                DateTime fechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                string telefono = txtTelefono.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) ||
                    string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) || string.IsNullOrWhiteSpace(telefono))
                {
                    Response.Write("<script>alert('Por favor completa todos los campos.');</script>");
                    return;
                }

                // Generar PDF del carrito
                string pdfPath = Server.MapPath("~/Archivos/Carrito.pdf");
                using (FileStream fs = new FileStream(pdfPath, FileMode.Create))
                {
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();
                    doc.Add(new Paragraph("Resumen de la Compra"));
                    doc.Add(new Paragraph($"Nombre: {nombre}"));
                    doc.Add(new Paragraph($"Correo: {correo}"));
                    doc.Add(new Paragraph($"Fecha de Nacimiento: {fechaNacimiento.ToShortDateString()}"));
                    doc.Add(new Paragraph($"Teléfono: {telefono}"));
                    doc.Add(new Paragraph("\nProductos:\n"));

                    if (Session["Carrito"] != null)
                    {
                        // Obtener el carrito agrupado
                        List<Pastel> carrito = (List<Pastel>)Session["Carrito"];
                        var productosAgrupados = carrito
                            .GroupBy(p => p.ID_Pastel)
                            .Select(g => new
                            {
                                Nombre = g.First().Nombre,
                                Precio = g.First().Precio,
                                Cantidad = g.Count()
                            });

                        foreach (var producto in productosAgrupados)
                        {
                            doc.Add(new Paragraph($"- {producto.Nombre} x {producto.Cantidad} - {producto.Precio * producto.Cantidad:C2}"));
                        }
                    }

                    doc.Close();
                }

                // Enviar correo con PDF adjunto
                Correo correoSender = new Correo();
                correoSender.EnviarCorreoConPDF(correo, nombre, fechaNacimiento, telefono, pdfPath);

                Response.Write("<script>alert('Correo enviado exitosamente.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
