using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Selection;

namespace MeetupManager.Core.Model
{
    public class MyProfileModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required!")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required!")]
        public string? LastName { get; set; }

        [Display(Name = "Preferred locations")]
        [Selection(typeof(LocationSelection))]
        public List<int> LocationPreferences { get; set; } = new();

    }
}
