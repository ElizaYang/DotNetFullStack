using FriendsApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FriendsApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Value> Values { get; set; } // "Values" is the table name, value is the each object name
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}