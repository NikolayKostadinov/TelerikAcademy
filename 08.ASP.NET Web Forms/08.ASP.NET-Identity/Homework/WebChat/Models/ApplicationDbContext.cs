using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebChat.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            SetUpApplicationUsersEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SetUpApplicationUsersEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>()
                .ToTable("ChatMessages")
                .HasKey(x => x.MessageId);
        }
    }
}