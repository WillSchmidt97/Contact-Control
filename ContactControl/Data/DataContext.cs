using ContactControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<ContactsModel> Contacts { get; set; }
    }
}
