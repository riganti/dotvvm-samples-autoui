using System.ComponentModel.DataAnnotations;

namespace MeetupManager.Core.Model;

public class LocationListModel
{
    [Display(AutoGenerateField = false)]
    public int Id { get; set; }

    [Display(Name = "Location name")]
    public string Name { get; set; } = null!;

    [Display(Name = "Street address")]
    public string? Address { get; set; }

    [Display(Name = "City")]
    public string City { get; set; } = null!;

    [Display(Name = "ZIP")]
    public string? Zip { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; } = null!;

    [Display(Name = "Number of meetups")]
    public int MeetupCount { get; set; }

}