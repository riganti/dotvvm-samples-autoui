namespace MeetupManager.Core.Data;

public class AppUserLocationPreference
{

    public int Id { get; set; }

    public string AppUserId { get; set; } = null!;

    public AppUser? AppUser { get; set; }

    public int LocationId { get; set; }

    public Location? Location { get; set; }

}