using Microsoft.EntityFrameworkCore;
using ProjectefDM.Models;
namespace ProjectefDM;

public class TareasContext:DbContext
{//Aqui se importa la libreria using...
    //Representan las tablas de la base de datos
    public DbSet<Categoria> Categoria{get; set;}
    public DbSet<Tarea> Tareas{get; set;}

    //Crear el metodo base del constructor
    public TareasContext (DbContextOptions<TareasContext>options):base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria"); //Crear la tabla categoria
            categoria.HasKey(p => p.CategoriaId); //Crear el CategoriaId
            //Regresa al modelo de categorias y comenta la linea [key] ya no se requiere
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tarea => //crear la entidad tarea
        {
            tarea.ToTable("Tarea"); //Crear la tabla Tarea
            tarea.HasKey(p => p.TareaId); //Crear la PK de la Tabla
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId); //Clave foranea
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
        });
    }
}