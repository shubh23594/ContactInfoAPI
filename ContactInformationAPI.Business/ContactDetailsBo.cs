using ContactInformationAPI.Common.DTO;
using ContactInformationAPI.Common.Model;
using ContactInformationAPI.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInformationAPI.Business
{
    public class ContactDetailsBo : IContactDetailsBo
    {
        public void AddDetails(ContactAppContext _context, Contact item)
        {
            _context.Contact.Add(new Contact
            {
                Email = item.Email,
                FirstName = item.FirstName,
                LastName = item.LastName,
                PhoneNumber = item.PhoneNumber,
                StatusDetails = item.StatusDetails
            });
            _context.SaveChanges();
        }

        public void DeleteDetails(int id, ContactAppContext _context)
        {
            var contact = _context.Contact.FirstOrDefault(t => t.ContactId == id);
            if (contact != null)
            {
                _context.Contact.Remove(contact);
                _context.SaveChanges();
            }
        }


        public async Task<Contact> GetDetailsById(ContactAppContext _context, int id)
        {
            return  _context.Contact.FirstOrDefault(t => t.ContactId == id);
        }

        public void UpdateDetails(ContactAppContext _context, int id, Contact item)
        {
            var contact = _context.Contact.FirstOrDefault(t => t.ContactId == id);
            if (contact != null)
            {
                contact.Email = item.Email;
                contact.FirstName = item.FirstName;
                contact.LastName = item.LastName;
                contact.PhoneNumber = item.PhoneNumber;
                contact.StatusDetails = item.StatusDetails;
                _context.Contact.Update(contact);
                _context.SaveChanges();
            }            
        }
    }
}
