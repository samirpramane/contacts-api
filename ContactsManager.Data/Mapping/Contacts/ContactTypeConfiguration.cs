using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using ContactsManager.Core;

namespace ContactsManager.Data
{
    internal class ContactTypeConfiguration : EntityTypeConfiguration<Contact>
    {
        internal ContactTypeConfiguration()
        {
            Property(s => s.FirstName).HasMaxLength(20);
            Property(s => s.LastName).HasMaxLength(20);
            Property(s => s.Email).HasMaxLength(320);
            Property(s => s.PhoneNumber).HasMaxLength(15);

            Map(s =>
            {
                s.MapInheritedProperties();
                s.ToTable("Contacts");
            });

            HasKey(s => s.ContactId).Property(s => s.ContactId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
