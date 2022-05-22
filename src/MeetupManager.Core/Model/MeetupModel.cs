using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Data;
using MeetupManager.Core.Selection;

namespace MeetupManager.Core.Model
{
    public class MeetupModel : IValidatableObject
    {

        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Event name is required.")]
        public string Title { get; set; } = null!;

        [Display(Name = "Event description")]
        [Visible(ViewNames = "Edit")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Start time")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Event begin date is required.")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "End time")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Event end date is required.")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Country")]
        [Visible(ViewNames = "Edit")]
        [Selection(typeof(CountrySelection))]
        public int? CountryId { get; set; }

        [Display(Name = "Country")]
        [Visible(ViewNames = "List")]
        public string CountryName { get; set; }

        [Display(Name = "Location")]
        [Visible(ViewNames = "Edit")]
        [Selection(typeof(LocationByCountrySelection))]
        [Required(ErrorMessage = "Location must be selected.")]
        public int? LocationId { get; set; }

        [Display(Name = "Location")]
        [Visible(ViewNames = "List")]
        public string LocationName { get; set; } = null!;


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BeginDate >= EndDate)
            {
                yield return new ValidationResult("Begin date cannot be after the end date!", new[] { nameof(BeginDate) });
            }
        }
    }
}
