using ContactInformationAPI.Common.DTO;
using Microsoft.EntityFrameworkCore;

namespace ContactInformationAPI.Common.Model
{
    public class ContactAppContext : DbContext
    {
        public ContactAppContext(DbContextOptions<ContactAppContext> options) : base(options) { }
        public DbSet<Contact> Contact
        {
            get;
            set;
        }
    }
}
