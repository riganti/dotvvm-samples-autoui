using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupManager.Core.Model
{
    public class SignInModel
    {

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; } = "";

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Display(Name = "Remember sign in")]
        public bool RememberMe { get; set; }

    }
}
