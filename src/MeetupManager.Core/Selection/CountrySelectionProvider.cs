using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.Annotations;
using MeetupManager.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Selection
{

    public record CountrySelection : Selection<int>;


    public class CountrySelectionProvider : ISelectionProvider<CountrySelection>
    {
        private readonly AppDbContext dbContext;

        public CountrySelectionProvider(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<List<CountrySelection>> GetSelectorItems()
        {
            return dbContext.Countries
                .OrderBy(c => c.Name)
                .Select(c => new CountrySelection()
                {
                    Value = c.Id,
                    DisplayName = c.Name
                })
                .ToListAsync();
        }
    }
}
