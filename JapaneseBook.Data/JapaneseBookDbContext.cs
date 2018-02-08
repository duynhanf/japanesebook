using JapaneseBook.Model.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JapaneseBook.Data
{
    public class JapaneseBookDbContext : DbContext
    {
        public JapaneseBookDbContext() : base("JapaneseBookConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ApplicationGroup> ApplicationGroups { set; get; }

        public DbSet<ApplicationRole> ApplicationRoles { set; get; }

        public DbSet<ApplicationRoleGroup> ApplicationRoleGroups { set; get; }

        public DbSet<ApplicationUser> ApplicationUsers { set; get; }

        public DbSet<ApplicationUserGroup> ApplicationUserGroups { set; get; }

        public DbSet<Book> Books { set; get; }

        public DbSet<BookCategory> BookCategorys { set; get; }

        public DbSet<BookTag> BookTags { set; get; }

        public DbSet<ContactDetail> ContactDetails { set; get; }

        public DbSet<Error> Errors { set; get; }

        public DbSet<Feedback> Feedbacks { set; get; }

        public DbSet<Footer> Footers { set; get; }

        public DbSet<Menu> Menus { set; get; }

        public DbSet<MenuGroup> MenuGroups { set; get; }

        public DbSet<Order> Orders { set; get; }

        public DbSet<OrderDetail> OrderDetails { set; get; }

        public DbSet<Page> Pages { set; get; }

        public DbSet<Post> Posts { set; get; }

        public DbSet<PostCategory> PostCategorys { set; get; }

        public DbSet<PostTag> PostTags { set; get; }

        public DbSet<Slide> Slides { set; get; }

        public DbSet<SupportOnline> SupportOnlines { set; get; }

        public DbSet<SystemConfig> SystemConfigs { set; get; }

        public DbSet<Tag> Tags { set; get; }

        public DbSet<VisitorStatistic> VisitorStatistics { set; get; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().HasKey(i => i.UserId).ToTable("ApplicationUserClaims");

        }
    }
}