using System.ComponentModel.DataAnnotations;

namespace MeetupManager.Core.Data;

public class Country
{

    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public ICollection<Location> Locations { get; set; } = new List<Location>();

}