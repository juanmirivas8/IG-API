using IGAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IGAPI;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) { }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<AreaEntity> Areas { get; set; }
}