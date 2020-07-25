using System.ComponentModel.DataAnnotations;

namespace ContactInformationAPI.Common.DTO
{
    public class Contact
    {
        [Key]
        public int? ContactId
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string StatusDetails
        {
            get;
            set;
        }       
    }
}
