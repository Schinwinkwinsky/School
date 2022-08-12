using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }

        public DbSet<KnowledgeArea> KnowledgeAreas { get; set; } = null!;
        public DbSet<Subject> Subjects { get; set; } = null!;
    }
}
