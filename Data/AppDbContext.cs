using Microsoft.EntityFrameworkCore;
using ApiContratosDockerK8s.Models;

namespace ApiContratosDockerK8s.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Contrato> Contratos => Set<Contrato>();
}
