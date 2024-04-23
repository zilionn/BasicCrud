using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Models {
    public class SingerContext : DbContext {

        public SingerContext(DbContextOptions<SingerContext> options) : base(options) { 
        
        }

        public DbSet<Singer> Singer { get; set; }
    }
}
