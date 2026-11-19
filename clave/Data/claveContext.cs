using Microsoft.EntityFrameworkCore;

public class claveContext(DbContextOptions<claveContext> options) : DbContext(options)
{
    public DbSet<clave.Models.User> User { get; set; } = default!;
}
