using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Areas.MST_ContactCategory.Models
{
    public class MST_ContactCategoryModel
    {
        public int? CategoryID { get; set; }
        [Required(ErrorMessage = "Category Name Is Required.")]
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    public class MST_ContactCategoryDropDownModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
