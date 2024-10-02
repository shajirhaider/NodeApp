using EFCoreAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EmailTemplate> EmailTemplates { get; set; }
        public DbSet<Monitoring> Monitorings { get; set; }
        public DbSet<Sla> Slas { get; set; }
        public DbSet<Node> Nodes { get; set; }
    }
}
