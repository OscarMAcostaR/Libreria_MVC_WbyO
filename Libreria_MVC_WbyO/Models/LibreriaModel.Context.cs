﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libreria_MVC_WbyO.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibreriaEntities : DbContext
    {
        public LibreriaEntities()
            : base("name=LibreriaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Detalle_Venta> Detalle_Venta { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<EstadoFisico> EstadoFisico { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }
        public virtual DbSet<Renta> Renta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
