using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Selection;

public record LocationSelection : Selection<int>;

public class LocationSelectionProvider : ISelectionProvider<LocationSelection>
{
    private readonly AppDbContext dbContext;

    public LocationSelectionProvider(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<LocationSelection>> GetSelectorItems()
    {
        return dbContext.Locations
            .Select(l => new LocationSelection()
            {
                Value = l.Id,
                DisplayName = l.Country!.Name + " - " + l.Name
            })
            .OrderBy(c => c.DisplayName)
            .ToListAsync();
    }
}