using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Proyecto.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }
        public string Nombre { get; set; }= string.Empty;
        public string Descripcion { get; set; }= string.Empty;
        
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas{ get; set; }
        public int Peso { get; set; }
    }
}