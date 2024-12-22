using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;
using Libreria_MVC_WbyO.Models;

namespace Libreria_MVC_WbyO.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ILibroService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ILibroService
    {
        [OperationContract]
        string Create_Libro(string Nombre, 
                            double Costo_total, 
                            double Costo_Renta, 
                            int Categoria_Id, 
                            int Autor_Id, 
                            int Editorial_Id, 
                            string Disponible);

        [OperationContract]
        List<Libro_DTO> List_Libros(int id);


        [OperationContract]
        string Update_Libro(int Id_Libro,
                            string Nombre,
                            double Costo_total,
                            double Costo_Renta,
                            int Categoria_Id,
                            int Autor_Id,
                            int Editorial_Id,
                            string Disponible);


        [OperationContract]
        string Delete_Libro(int Id_Libro);
    }
}
