using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto
{
    public class TareasContext:DbContext
    {
        public DbSet<Categoria> Categorias{ get; set; }
        public DbSet<Tarea> Tareas{ get; set; }
        
        public TareasContext(DbContextOptions<TareasContext> options):base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit=new List<Categoria>();
            categoriasInit.Add(new Categoria
            {
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23114"),
                Nombre="Actividades Pendientes",                
                Peso=20
            });
              categoriasInit.Add(new Categoria
            {
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23115"),
                Nombre="Actividades Privadas",
                Peso=20
            });
              categoriasInit.Add(new Categoria
            {
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23116"),
                Nombre="Actividades Personales",
                Peso=50
            });

             List<Tarea> tareasInit=new List<Tarea>();
            tareasInit.Add(new Tarea
            {
                TareaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23119"),
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23114"),
                Titulo="Actividades Pendientes.Estudiar",
                Prioridad=Prioridad.Media,
                FechaCreacion=DateTime.Now,
            });
              tareasInit.Add(new Tarea
            {
                TareaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23118"),
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23115"),
                Titulo="Actividades Privadas.terminar Peli",
                Prioridad=Prioridad.Baja,
                FechaCreacion=DateTime.Now,
            });
              tareasInit.Add(new Tarea
            {
                TareaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23117"),
                CategoriaId=Guid.Parse("78d2005c-20d4-4ada-980c-4e990fe23116"),
                Titulo="Actividades Personales.pilates",
                Prioridad=Prioridad.Alta,
                FechaCreacion=DateTime.Now,
            });
           modelBuilder.Entity<Categoria>(categoria=>
           {
                categoria.ToTable("Categoria");
                categoria.HasKey(c=>c.CategoriaId);
                categoria.Property(c=>c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c=>c.Descripcion).IsRequired(false);
                categoria.Property(c=>c.Peso);
                categoria.HasData(categoriasInit);
           });

            modelBuilder.Entity<Tarea>(tarea=>
           {
                tarea.ToTable("Tarea");
                tarea.HasKey(t=>t.TareaId);
                tarea.HasOne(t=>t.Categoria).WithMany(t=>t.Tareas).HasForeignKey(t=>t.CategoriaId);
                tarea.Property(t=>t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t=>t.Descripcion).IsRequired(false);;
                tarea.Property(t=>t.Prioridad);
                tarea.Property(t=>t.FechaCreacion);
                tarea.Ignore(t=>t.Resumen);
                tarea.HasData(tareasInit);
           });
        }


    }
}