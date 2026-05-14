using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Endpoints;

public static class TodoEndpoints
{
    public static WebApplication MapTodoEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/todos")
                       .WithTags("Todos");

        group.MapGet("/", GetAll)
             .WithSummary("Get all tasks");
        
        group.MapPost("/", Create)
             .WithSummary("Create new task");

        group.MapDelete("/{id:int}", Delete)
             .WithSummary("Delete task");

        return app;
    }


    private static async Task<IResult> GetAll(AppDbContext context)
    {
        List<TodoResponseDto>? items = await context.TodoItems
                                 .AsNoTracking()
                                 .Select(t => new TodoResponseDto
                                 {
                                     Id = t.Id,
                                     Label = t.Label,
                                     IsComplete = t.IsComplete,
                                     CreatedAt = t.CreatedAt
                                 }).ToListAsync();
            return Results.Ok(items);
    }


    private static async Task<IResult> Create(CreateDto dto, AppDbContext context)
    {
        TodoItem? item = new TodoItem {Label = dto.Label.Trim()};
        context.TodoItems.Add(item);
        await context.SaveChangesAsync();

        return Results.Created(
            $"/api/todos/{item.Id}",
            new TodoResponseDto
            {
                Id = item.Id,
                Label = item.Label,
                IsComplete = item.IsComplete,
                CreatedAt = item.CreatedAt
            });
    }

    private static async Task<IResult> Delete(int id, AppDbContext context)
    {
        TodoItem? item =  await context.TodoItems.FindAsync(id);
        if (item is null)
            return Results.NotFound(new { message = $"Tarea {id} no encontrada." });

        context.TodoItems.Remove(item);
        await context.SaveChangesAsync();

        return Results.NoContent();
    }


}
