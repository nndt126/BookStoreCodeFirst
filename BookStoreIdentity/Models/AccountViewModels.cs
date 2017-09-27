using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreIdentity.Models
{

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username don't exist")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password don't exist")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
       
    }

    
}
