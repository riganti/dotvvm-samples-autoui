using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Selection;

public record LocationSelection : Selection<int>;


public class LocationSelectionProvider : ISelectionProvider<LocationSelection, int?>
{
    private readonly AppDbContext dbContext;

    public LocationSelectionProvider(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<LocationSelection>> GetSelectorItems(int? countryId)
    {
        if (countryId == null)
        {
            return Task.FromResult(new List<LocationSelection>());
        }

        return dbContext.Locations
            .Where(l => l.CountryId == countryId)
            .OrderBy(c => c.Name)
            .Select(l => new LocationSelection()
            {
                Value = l.Id,
                DisplayName = l.Name
            })
            .ToListAsync();
    }
}
