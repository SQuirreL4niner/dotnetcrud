using System.Data.Entity;

namespace WebApplication5.Models
{
    public class ScratchContext : DbContext
    {
        public DbSet<Scratch> ScratchItems { get; set; }
    }
}