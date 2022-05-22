using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Selection;

public record LocationByCountrySelection : Selection<int>;

public class LocationByCountrySelectionProvider : ISelectionProvider<LocationByCountrySelection, int?>
{
    private readonly AppDbContext dbContext;

    public LocationByCountrySelectionProvider(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public Task<List<LocationByCountrySelection>> GetSelectorItems(int? countryId)
    {
        if (countryId == null)
        {
            return Task.FromResult(new List<LocationByCountrySelection>());
        }

        return dbContext.Locations
            .Where(l => l.CountryId == countryId)
            .OrderBy(c => c.Name)
            .Select(l => new LocationByCountrySelection()
            {
                Value = l.Id,
                DisplayName = l.Name
            })
            .ToListAsync();
    }
}