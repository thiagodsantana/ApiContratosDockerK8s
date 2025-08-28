using Microsoft.EntityFrameworkCore;
using ApiContratosDockerK8s.Data;
using ApiContratosDockerK8s.Models;

var builder = WebApplication.CreateBuilder(args);

// String de conexão dinâmica via env vars
var connectionString = builder.Configuration.GetConnectionString("MySql") ??
                       $"server={Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost"};" +
                       $"database={Environment.GetEnvironmentVariable("DB_NAME") ?? "contratosdb"};" +
                       $"user={Environment.GetEnvironmentVariable("DB_USER") ?? "root"};" +
                       $"password={Environment.GetEnvironmentVariable("DB_PASS") ?? "root"};";

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Criar banco automaticamente se não existir
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Contratos.Any())
    {
        db.Contratos.AddRange(
            new Contrato { Numero = "C-2025-001", Cliente = "Antonio João", Valor = 15000.00m, DataAssinatura = DateTime.Now },
            new Contrato { Numero = "C-2025-002", Cliente = "José da Silva", Valor = 8000.00m, DataAssinatura = DateTime.Now },
            new Contrato { Numero = "C-2025-003", Cliente = "Thiago Darlei", Valor = 5000.00m, DataAssinatura = DateTime.Now }
        );
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints Contratos
app.MapGet("/contratos", async (AppDbContext db) => await db.Contratos.ToListAsync());

app.MapPost("/contratos", async (AppDbContext db, Contrato contrato) =>
{
    contrato.DataAssinatura = contrato.DataAssinatura == default ? DateTime.UtcNow : contrato.DataAssinatura;
    db.Contratos.Add(contrato);
    await db.SaveChangesAsync();
    return Results.Created($"/contratos/{contrato.Id}", contrato);
});

app.Run();
