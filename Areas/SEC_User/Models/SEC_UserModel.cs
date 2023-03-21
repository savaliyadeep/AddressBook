using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int UserID { get; set; }

        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string? EmailID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
