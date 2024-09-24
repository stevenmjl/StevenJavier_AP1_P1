using Microsoft.EntityFrameworkCore;
using StevenJavier_AP1_P1.Models;

namespace StevenJavier_AP1_P1.DAL;
public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Registro> Registros { get; set; }
}