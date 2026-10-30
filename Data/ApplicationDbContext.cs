using HelpDeskSystem.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        //Entities
        public DbSet<Ticket> Ticket => Set<Ticket>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ticket>()
                .HasOne(x => x.CreatedBy)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.CreatedById);
            
            builder.Entity<Ticket>().Property(x => x.Description).HasMaxLength(900);
        }
    }
}
