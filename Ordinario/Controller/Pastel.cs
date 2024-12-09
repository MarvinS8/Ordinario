using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ordinario.Controller
{
    public class Pastel
    {
        public Pastel() { }
        public Pastel(int iD_Pastel, string nombre, string sabor, string tamaño, decimal precio, string ingredientes, DateTime fecha_Elaboración, int cantidad_Disponible)
        {
            ID_Pastel = iD_Pastel;
            Nombre = nombre;
            Sabor = sabor;
            Tamaño = tamaño;
            Precio = precio;
            Ingredientes = ingredientes;
            Fecha_Elaboración = fecha_Elaboración;
            Cantidad_Disponible = cantidad_Disponible;
        }

        public int ID_Pastel { get; set; }
        public string Nombre { get; set; }
        public string Sabor { get; set; }
        public string Tamaño { get; set; }
        public decimal Precio { get; set; }
        public string Ingredientes { get; set; }
        public DateTime Fecha_Elaboración { get; set; }
        public int Cantidad_Disponible { get; set; }
    }
}