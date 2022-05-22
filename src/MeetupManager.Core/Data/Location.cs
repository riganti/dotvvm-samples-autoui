using System.ComponentModel.DataAnnotations;

namespace MeetupManager.Core.Data;

public class Location
{

    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    public string? Zip { get; set; }

    public int CountryId { get; set; }

    public Country? Country { get; set; }

    public ICollection<Meetup> Meetups { get; set; } = new List<Meetup>();

    public ICollection<AppUserLocationPreference> AppUserLocationPreferences { get; set; } = new List<AppUserLocationPreference>();

}