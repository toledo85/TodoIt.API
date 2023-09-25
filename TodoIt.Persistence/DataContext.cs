using Microsoft.EntityFrameworkCore;
using TodoIt.Domain;

namespace TodoIt.Persistence;

public class DataContext: DbContext {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Todo> Todos => Set<Todo>();
    public DbSet<User> Users => Set<User>();
}