using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordinario.Controller
{
    interface IPasteles
    {
        List<Pastel> ObtenerPastel();
        bool InsertarPasteles(int iD_Pastel, string nombre, string sabor, string tamaño, decimal precio, string ingredientes, DateTime fecha_Elaboración, int cantidad_Disponible);
        bool EliminarPasteles(int iD_Pastel);
        bool ActualizarPasteles(int iD_Pastel, string nombre, string sabor, string tamaño, decimal precio, string ingredientes, DateTime fecha_Elaboración, int cantidad_Disponible);
    }
}
