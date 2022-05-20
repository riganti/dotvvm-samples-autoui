using System.ComponentModel.DataAnnotations;

namespace MeetupManager.Core.Data;

public class Meetup
{

    public int Id { get; set; }

    [StringLength(100)]
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public int LocationId { get; set; }

    public Location? Location { get; set; }
}