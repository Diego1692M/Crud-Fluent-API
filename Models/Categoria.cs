

using System.ComponentModel.DataAnnotations;

namespace ProjectefDM.Models;

public class Categoria{
    //Atributos denerales del modelo
    //[Key] //Define la clave primaria de la tabla
    public Guid CategoriaId{get; set;}
    //[Required]
    //[MaxLength(150)]
    public required string Nombre{get; set;}
    public required string Descripcion{get; set;}

    public virtual required ICollection<Tarea> Tareas{get; set;}
}