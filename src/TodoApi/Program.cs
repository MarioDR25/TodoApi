using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TodoApi.Data;
using TodoApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// 1. Configuración de OpenAPI (Solo una vez y con el título)
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((doc, _, _) =>
    {
        doc.Info = new() { Title = "Todo API", Version = "v1" };
        return Task.CompletedTask;
    });
});

// 2. Configuración de Base de Datos
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Configuración de CORS (Fundamental para Scalar)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// --- ORDEN DEL PIPELINE (IMPORTANTE) ---

// 4. Activar CORS ANTES que cualquier otra cosa
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTitle("Todo API")
               .WithTheme(ScalarTheme.Mars) // Un tema diferente para asegurar que refresque
               .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        
        // Esto es lo que me "quedó grande": Scalar necesita saber que NO está en localhost
        // Al no definir un servidor fijo, Scalar usará la URL actual del navegador.
    });
}

// 5. Endpoints y Redirección
app.MapTodoEndpoints();
app.MapGet("/", () => Results.Redirect("/scalar/v1"));

// 6. Migraciones Automáticas
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

// 7. Forzar el puerto desde el código para que no haya pérdida
app.Run("http://0.0.0.0:5242");