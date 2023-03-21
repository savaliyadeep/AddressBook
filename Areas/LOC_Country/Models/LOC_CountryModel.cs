using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? UserID { get; set; }
        public int? CountryID { get; set; }
        [Required]
        [DisplayName("Country Name Is Required.")]
        public string CountryName { get; set; }
        [Required]
        [DisplayName("Country Code Is Required.")]
        public string? CountryCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_CountryDDModel
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
    }
}
