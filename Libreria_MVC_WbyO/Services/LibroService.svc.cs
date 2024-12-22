using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;

namespace Libreria_MVC_WbyO.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LibroService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione LibroService.svc o LibroService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class LibroService : ILibroService
    {
        public string Create_Libro(string Nombre, double Costo_total, double Costo_Renta, int Categoria_Id, int Autor_Id, int Editorial_Id,string Disponible)
        {
            throw new NotImplementedException();
        }


        public string Delete_Libro(int Id_Libro)
        {
            throw new NotImplementedException();
        }

        public List<Libro_DTO> List_Libros(int id)
        {
            throw new NotImplementedException();
        }

        public string Update_Libro(int Id_Libro, string Nombre, double Costo_total, double Costo_Renta, int Categoria_Id, int Autor_Id, int Editorial_Id, string Disponible)
        {
            throw new NotImplementedException();
        }
    }
}
