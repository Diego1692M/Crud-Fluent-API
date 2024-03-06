

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectefDM.Models;

public class Tarea{
    //[Key]
    public Guid TareaId{get; set;}
    //[ForeignKey("CategoriaId")]
    public Guid CategoriaId{get; set;}
    //[Required]
    //[MaxLength(200)]
    public required string Titulo{get; set;}
    public required string Descripcion{get; set;}

    public Prioridad PrioridadTarea{get; set;}
    public DateTime FechaCreacion{get; set;}
    public virtual required Categoria Categoria {get; set;}
    //[NotMapped] //El resumen no se crea en la bd

    public required string Resumen{get; set;} //Se llena con la descripcion, pero no se almacena en la db
}

public enum Prioridad{
    Baja,
    Media,
    Alta
}