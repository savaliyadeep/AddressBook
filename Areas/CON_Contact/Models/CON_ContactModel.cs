using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Areas.CON_Contact.Models
{
    public class CON_ContactModel
    {
        public int? UserID { get; set; }
        public int? ContactID { get; set; }
        public IFormFile File { get; set; }
        public string PhotoPath { get; set; }
        public string ContactName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int CategoryID { get; set; }
        public string Address { get; set; }
        public int PinCode { get; set; }
        public string Mobile { get; set; }
        public string? AlternateContact { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? LinkedIn { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

    }
}
