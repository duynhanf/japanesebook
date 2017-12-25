using JapaneseBook.Model;
using System.Data.Entity;

namespace JapaneseBook.Data
{
    public class JapaneseBookDbContext : DbContext
    {
        public JapaneseBookDbContext() : base("JapaneseBookConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { set; get; }
        public DbSet<Menu> Menus { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
        }
    }
}