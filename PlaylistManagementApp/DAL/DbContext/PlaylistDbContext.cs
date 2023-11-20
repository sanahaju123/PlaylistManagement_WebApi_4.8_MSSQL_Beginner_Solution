
using PlaylistManagementApp.Models;
using System.Data.Entity;


namespace PlaylistManagementApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Song> Songs { get; set; }
    }
}