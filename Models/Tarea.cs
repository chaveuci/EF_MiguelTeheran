using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Proyecto.Models
{
    public class Tarea
    {
        public Guid TareaId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Titulo { get; set; }=string.Empty;
        public string Descripcion { get; set; }=string.Empty;
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }
        public string Resumen { get; set; }=string.Empty;
    }
    public enum Prioridad
    {
        Baja,
        Media,
        Alta
    }
}