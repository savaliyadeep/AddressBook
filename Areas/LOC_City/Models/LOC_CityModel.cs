using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? UserID { get; set; }
        public int? CityID { get; set; }
        [Required(ErrorMessage = "City Name Is Required.")]
        public string CityName { get; set; }
        public string? CityCode { get; set; }
        [Required(ErrorMessage = "Pleace Select State Name.")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Please Select Country Name.")]
        public int CountryID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class LOC_CityDropDownModel
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
