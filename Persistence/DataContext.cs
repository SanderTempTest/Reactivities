using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{

    public DataContext(DbContextOptions options) : base(options)
    {
    }


    //Activities = name of DataBase table
    //Activity = property type of DbSet - from Domain
    public DbSet<Activity> Activities { get; set; } = null!;
}