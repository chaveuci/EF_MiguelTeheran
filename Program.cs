using Proyecto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;
using Microsoft.AspNetCore.Http.HttpResults;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareasContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();




app.MapGet("/", () => "Hello World!");

app.MapGet("/api/tareas",async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas
    .Include(t=>t.Categoria)
    .Where(t=>t.Prioridad== Prioridad.Media));
});

app.MapPost("/api/tareas",async ([FromServices] TareasContext dbContext,[FromBody] Tarea tareaNew)=>
{
    tareaNew.Titulo="Creada";
    tareaNew.TareaId=new Guid();
    tareaNew.FechaCreacion=DateTime.Now;
    tareaNew.Prioridad=Prioridad.Alta;

    await dbContext.AddAsync(tareaNew);
    await dbContext.SaveChangesAsync();

    return Results.Ok(tareaNew);
});
app.MapPut("/api/tareas/{id}",async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea,[FromRoute] Guid id)=>
{
    var tareaActual=dbContext.Tareas.Find(id);
    if(tareaActual !=null)
    {
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Prioridad=tarea.Prioridad;
        tareaActual.Descripcion=tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok(tareaActual);
    }
    return Results.NotFound();
    
});

app.MapDelete("/api/tareas/{id}",async ([FromServices] TareasContext dbContext,[FromRoute] Guid id)=>
{
    var tareaABorrar=dbContext.Tareas.Find(id);
    if(tareaABorrar !=null)
    {
        dbContext.Remove(tareaABorrar);
        await dbContext.SaveChangesAsync();

        return Results.Ok(tareaABorrar);
    }
    return Results.NotFound();
    
});
app.Run();
