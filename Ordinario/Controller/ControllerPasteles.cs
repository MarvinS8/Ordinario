using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Ordinario.Models.DSPasteleriaTableAdapters;

namespace Ordinario.Controller
{
    public class ControllerPasteles : IPasteles
    {
        Pastel a = new Pastel();
        List<Pastel> listaProducto = new List<Pastel>();
        public bool ActualizarCantidadDisponible(int idPastel, int cantidad)
        {
            try
            {
                using (pastelesTableAdapter al = new pastelesTableAdapter())
                {
                    // Actualizar el stock del pastel en la base de datos
                    al.ActualizarCantidadDisponible(cantidad, idPastel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar cantidad disponible: " + ex.Message);
                return false;
            }
        }

        public bool ActualizarPasteles(int iD_Pastel, string nombre, string sabor, string tamaño, decimal precio, string ingredientes, DateTime fecha_Elaboración, int cantidad_Disponible)
        {
            try
            {
                using (pastelesTableAdapter al = new pastelesTableAdapter())
                {
                    al.Update(nombre, sabor, tamaño, precio, ingredientes, fecha_Elaboración, cantidad_Disponible, iD_Pastel);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool EliminarPasteles(int iD_Pastel)
        {
            try
            {
                using (pastelesTableAdapter al = new pastelesTableAdapter())
                {
                    al.Delete(iD_Pastel);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertarPasteles(int iD_Pastel, string nombre, string sabor, string tamaño, decimal precio, string ingredientes, DateTime fecha_Elaboración, int cantidad_Disponible)
        {
            try
            {
                using (pastelesTableAdapter al = new pastelesTableAdapter())
                {
                    al.Insert(nombre, sabor, tamaño, precio, ingredientes, fecha_Elaboración, cantidad_Disponible);
                    return true;
                }
            }
            catch (Exception ex )
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public List<Pastel> ObtenerPastel()
        {
            try
            {
                using (pastelesTableAdapter al = new pastelesTableAdapter())
                {
                    var datos = al.GetData();
                    foreach (DataRow row in datos)
                    {
                        Pastel pastel = new Pastel(
                            Convert.ToInt32(row["Id_Pastel"]),
                            row["Nombre"].ToString(),
                            row["Sabor"].ToString(),
                            row["Tamaño"].ToString(),
                            Convert.ToDecimal(row["Precio"]),
                            row["Ingredientes"].ToString(),
                            Convert.ToDateTime(row["Fecha_Elaboración"]),
                            Convert.ToInt32(row["Cantidad_Disponible"])
                        );
                        listaProducto.Add(pastel);
                    }
                }
                return listaProducto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}