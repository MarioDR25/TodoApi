using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoApi.Data;
using TodoApi.Endpoints;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<AppDbContext>(o =>
            o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


        builder.Services.AddOpenApi(o =>
        {
            o.AddDocumentTransformer((doc, _, _) =>
            {
                doc.Info = new() { Title = "Todo API", Version = "v1" };
                return Task.CompletedTask;
            });
        });


        var app = builder.Build();
        app.MapOpenApi();
        app.MapScalarApiReference(o =>
        {
            o.Title = "Todo API";
            o.Theme = ScalarTheme.Moon;
        });

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) { }

        app.UseHttpsRedirection();
        app.MapTodoEndpoints();

        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
        }

        app.Run();
    }
}