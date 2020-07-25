using ContactInformationAPI.Common.DTO;
using ContactInformationAPI.Common.Model;
using ContactInformationAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInformationAPI.Controllers
{
    /// <summary>
    /// Contact Details Controller Class
    /// Methods/Operations :-
    /// GetAllContact,
    /// GetContactById
    /// AddContact
    /// UpdateContact
    /// DeleteContact
    /// All the CRUD operation are handling through Azure SQL Database 
    /// which I have created in Free Account
    /// </summary>
    [Route("[controller]")]
    public class ContactDetails : ControllerBase
    {
        private readonly ContactAppContext _context;
        private readonly IContactDetailsBo contactDetailsBo;

        public ContactDetails(ContactAppContext contactAppContext, IConfiguration configuration, IContactDetailsBo contactDetailsBo)
        {
            _context = contactAppContext;
            this.contactDetailsBo = contactDetailsBo;
        }

        /// <summary>
        /// Getting all Contact Details from Azure SQL Database
        /// <para name= ""> </para>
        /// </summary>
        /// <returns>IEnumerable<Contact></returns>
        [HttpPost]
        [Route("getAllContact")]
        public  IEnumerable<Contact> GetAll()
        {
            return _context.Contact.ToList();
        }

        /// <summary>
        /// Getting all Contact Details from Azure SQL Database by passing ID
        /// <para name= "int ID"> </para>
        /// </summary>
        /// <returns>Task<IActionResult></returns>
        [HttpGet("{id}")]
        [Route("getContact")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Contact contact = await contactDetailsBo.GetDetailsById(_context, id);
                if (contact == null)
                {
                    return NotFound("No Data Found");
                }
                return new OkObjectResult(contact);
            }
            catch(Exception ex)
            {
                return NotFound("Exception Occured: "+ ex.InnerException);
            }
        }


        /// <summary>
        /// Add Contact Details to Azure SQL Database 
        /// by passing passing Contact Details to be updated
        /// <para name= "Contact"> </para>
        /// </summary>
        /// <returns><IActionResult></returns>
        [HttpPost]
        [Route("addContact")]
        public IActionResult Create([FromBody] Contact item)
        {
            // set bad request if contact data is not provided in body  
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }

                contactDetailsBo.AddDetails(_context, item);
                return Ok(new
                {
                    message = "Contact is added successfully."
                });
            }
            catch (Exception ex)
            {
                return NotFound("Exception Occured: " + ex.InnerException);
            }
            
        }

        /// <summary>
        /// Update Contact Details to Azure SQL Database 
        /// by passing passing ID to be updated along with Contact Details information
        /// <para name= "int id, Contact"> </para>
        /// </summary>
        /// <returns><IActionResult></returns>
        [HttpPut("{id}")]
        [Route("updateContact")]
        public IActionResult Update(int id, [FromBody] Contact item)
        {
            try
            {
                // set bad request if contact data is not provided in body  
                if (item == null || id == 0)
                {
                    return BadRequest();
                }
                var contact = _context.Contact.FirstOrDefault(t => t.ContactId == id);
                if (contact == null)
                {
                    return NotFound();
                }
                contactDetailsBo.UpdateDetails(_context, id, item);
                return Ok(new
                {
                    message = "Contact is updated successfully."
                });
            }
            catch (Exception ex)
            {
                return NotFound("Exception Occured: " + ex.InnerException);
            }


        }

        /// <summary>
        /// Delete Contact Details to Azure SQL Database 
        /// by passing passing ID
        /// <para name= "int id"> </para>
        /// </summary>
        /// <returns><IActionResult></returns>
        [HttpDelete("{id}")]
        [Route("deleteContact")]
        public IActionResult Delete(int id)
        {
            try
            {
                var contact = _context.Contact.FirstOrDefault(t => t.ContactId == id);
                if (contact == null)
                {
                    return NotFound();
                }

                contactDetailsBo.DeleteDetails(id, _context);
                return Ok(new
                {
                    message = "Contact is deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return NotFound("Exception Occured: " + ex.InnerException);
            }  
        }
    }
}
