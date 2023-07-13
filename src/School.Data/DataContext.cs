using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System.Reflection;

namespace School.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) 
        : base(options) { }

    public DbSet<KnowledgeArea> KnowledgeAreas { get; set; } = default!;
    public DbSet<Person> People { get; set; } = default!;
    public DbSet<SchoolClass> SchoolClasses { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Subject> Subjects { get; set; } = default!;
    public DbSet<Teacher> Teachers { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
