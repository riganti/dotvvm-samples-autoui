using DotVVM.Framework.Controls;
using MeetupManager.Core.Data;
using MeetupManager.Core.Model;

namespace MeetupManager.Core.Services;

public class LocationsService
{
    private readonly AppDbContext dbContext;

    public LocationsService(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task LoadLocations(GridViewDataSet<LocationListModel> dataSet)
    {
        var query = dbContext.Locations
            .Select(l => new LocationListModel()
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                City = l.City,
                Zip = l.Zip,
                CountryName = l.Country!.Name,
                MeetupCount = l.Meetups.Count()
            });

        await dataSet.LoadFromQueryableAsync(query);
    }

    public async Task<LocationDetailModel> GetLocationDetail(int id)
    {
        var l = (await dbContext.Locations.FindAsync(id))!;

        return new LocationDetailModel()
        {
            Id = l.Id,
            Name = l.Name,
            Address = l.Address,
            City = l.City,
            Zip = l.Zip,
            CountryId = l.CountryId
        };
    }

    public async Task SaveLocation(LocationDetailModel model)
    {
        Location location;
        if (model.Id == default)
        {
            location = new Location();
            dbContext.Locations.Add(location);
        }
        else
        {
            location = (await dbContext.Locations.FindAsync(model.Id))!;
        }

        location.Name = model.Name;
        location.Address = model.Address;
        location.City = model.City;
        location.Zip = model.Zip;
        location.CountryId = model.CountryId!.Value;
        
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteLocation(int id)
    {
        var location = (await dbContext.Locations.FindAsync(id))!;
        dbContext.Locations.Remove(location);
        await dbContext.SaveChangesAsync();
    }

}