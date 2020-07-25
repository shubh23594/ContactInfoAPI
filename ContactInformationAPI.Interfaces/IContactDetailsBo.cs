using ContactInformationAPI.Common.DTO;
using ContactInformationAPI.Common.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactInformationAPI.Interfaces
{
    public interface IContactDetailsBo
    {

        Task<Contact> GetDetailsById(ContactAppContext _context, int id);

        void AddDetails(ContactAppContext _context, Contact item);

        void UpdateDetails(ContactAppContext _context, int id, Contact item);

        void DeleteDetails(int id, ContactAppContext _context);
    }
}
