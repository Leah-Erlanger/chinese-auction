using ApiProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TasksApi.Models;

public partial class ProjectDbContext : DbContext
{
    //public ProjectDbContext()
    //{
    //}

    public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baskets> Baskets { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Donors> Donors { get; set; }

    public virtual DbSet<Gifts> Gifts { get; set; }

    public virtual DbSet<Winners> Winners { get; set; }
}
