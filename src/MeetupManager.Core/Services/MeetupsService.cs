using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using MeetupManager.Core.Data;
using MeetupManager.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Services
{
    public class MeetupsService
    {
        private readonly AppDbContext dbContext;

        public MeetupsService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task LoadMeetups(GridViewDataSet<MeetupModel> dataSet)
        {
            var query = dbContext.Meetups
                .Select(m => new MeetupModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    BeginDate = m.BeginDate,
                    EndDate = m.EndDate,
                    CountryId = m.Location!.CountryId,
                    CountryName = m.Location!.Country!.Name,
                    LocationId = m.LocationId,
                    LocationName = m.Location!.Name,
                    ImageUrl = m.ImageUrl
                });

            await dataSet.LoadFromQueryableAsync(query);
        }

        public async Task<MeetupModel> GetMeetupDetail(int id)
        {
            var m = await dbContext.Meetups
                .Include(m => m.Location)
                .SingleAsync(l => l.Id == id);

            return new MeetupModel()
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                BeginDate = m.BeginDate,
                EndDate = m.EndDate,
                CountryId = m.Location!.CountryId,
                LocationId = m.LocationId,
                ImageUrl = m.ImageUrl
            };
        }

        public async Task SaveMeetup(MeetupModel model)
        {
            Meetup meetup;
            if (model.Id == default)
            {
                meetup = new Meetup();
                dbContext.Meetups.Add(meetup);
            }
            else
            {
                meetup = (await dbContext.Meetups.FindAsync(model.Id))!;
            }

            meetup.Title = model.Title;
            meetup.Description = model.Description;
            meetup.BeginDate = model.BeginDate;
            meetup.EndDate = model.EndDate;
            meetup.LocationId = model.LocationId!.Value;
            meetup.ImageUrl = model.ImageUrl;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteMeetup(int id)
        {
            var meetup = (await dbContext.Meetups.FindAsync(id))!;
            dbContext.Meetups.Remove(meetup);
            await dbContext.SaveChangesAsync();
        }

    }
}
