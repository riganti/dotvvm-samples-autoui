using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using MeetupManager.Core.Model;
using MeetupManager.Core.Services;

namespace MeetupManager.ViewModels
{
    public class LocationListViewModel : MasterPageViewModel
    {
        private readonly LocationsService locationsService;

        public GridViewDataSet<LocationListModel> Locations { get; set; } = new()
        {
            PagingOptions =
            {
                PageSize = 20
            },
            SortingOptions =
            {
                SortExpression = nameof(LocationListModel.Name)
            }
        };

        public LocationListViewModel(LocationsService locationsService)
        {
            this.locationsService = locationsService;
        }

        public override async Task Init()
        {
            await Context.Authorize(roles: new [] { "administrators" });
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (Locations.IsRefreshRequired)
            {
                await locationsService.LoadLocations(Locations);
            }

            await base.PreRender();
        }

        public async Task Delete(int id)
        {
            await locationsService.DeleteLocation(id);
            Locations.RequestRefresh();
        }
    }
}

