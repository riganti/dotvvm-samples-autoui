using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using MeetupManager.Core.Model;
using MeetupManager.Core.Selection;
using MeetupManager.Core.Services;

namespace MeetupManager.ViewModels
{
    public class LocationDetailViewModel : MasterPageViewModel
    {
        private readonly LocationsService locationsService;

        [FromRoute("Id")]
        public int Id { get; set; }

        public LocationDetailModel Location { get; set; }

        public SelectionViewModel<CountrySelection> Countries { get; set; } = new();

        public LocationDetailViewModel(LocationsService locationsService)
        {
            this.locationsService = locationsService;
        }

        public override async Task Init()
        {
            await Context.Authorize(roles: new[] { "administrators" });
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                if (Id == default)
                {
                    Location = new LocationDetailModel();
                }
                else
                {
                    Location = await locationsService.GetLocationDetail(Id);
                }
            }

            await base.PreRender();
        }

        public async Task Save()
        {
            await locationsService.SaveLocation(Location);
            Context.RedirectToRoute("LocationList");
        }
    }
}

