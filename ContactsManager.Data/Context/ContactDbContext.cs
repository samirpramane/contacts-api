using ContactsManager.Core;
using System.Data.Entity;

namespace ContactsManager.Data
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base("Contacts")
        {
            Database.SetInitializer<ContactDbContext>(new CreateDatabaseIfNotExists<ContactDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContactTypeConfiguration());
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
