using Microsoft.EntityFrameworkCore;
using ZPEATM.Models;

namespace ZPEATM.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Career> Careers { get; set; }
    }
}
