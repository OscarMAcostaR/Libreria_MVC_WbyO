using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Libro_DTO
    {
        public int Id_Libro { get; set; }
        public string Nombre { get; set; }
        public double Costo_total { get; set; }
        public double Costo_Renta { get; set; }
        public int Categoria_Id { get; set; }
        public int Autor_Id { get; set; }
        public int Editorial_Id { get; set; }
        public string Disponible { get; set; }

     
    }
}
