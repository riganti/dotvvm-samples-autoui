using Microsoft.AspNetCore.Identity;

namespace MeetupManager.Core.Data;

public class AppUser : IdentityUser
{

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool SubscribeToNewsletters { get; set; }

    public ICollection<AppUserLocationPreference> AppUserLocationPreferences { get; set; } = new List<AppUserLocationPreference>();

}