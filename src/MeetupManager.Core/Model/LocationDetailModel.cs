using System.ComponentModel.DataAnnotations;
using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Selection;

namespace MeetupManager.Core.Model;

public class LocationDetailModel
{
    [Display(AutoGenerateField = false)]
    public int Id { get; set; }

    [Display(Name = "Location name")]
    [Required(ErrorMessage = "Location name is required!")]
    public string Name { get; set; } = null!;

    [Display(Name = "Street address")]
    public string? Address { get; set; }

    [Display(Name = "City")]
    [Required(ErrorMessage = "City is required!")]
    public string City { get; set; } = null!;

    [Display(Name = "ZIP")]
    public string? Zip { get; set; }

    [Display(Name = "Country")]
    [Selection(typeof(CountrySelection))]
    [Required(ErrorMessage = "Country is required!")]
    public int? CountryId { get; set; }
}