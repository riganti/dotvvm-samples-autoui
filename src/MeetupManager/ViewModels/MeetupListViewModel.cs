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
    public class MeetupListViewModel : MasterPageViewModel
    {
        private readonly MeetupsService meetupsService;

        public GridViewDataSet<MeetupModel> Meetups { get; set; } = new()
        {
            PagingOptions =
            {
                PageSize = 20
            },
            SortingOptions =
            {
                SortExpression = nameof(MeetupModel.BeginDate),
                SortDescending = true
            }
        };

        public MeetupListViewModel(MeetupsService meetupsService)
        {
            this.meetupsService = meetupsService;
        }

        public override async Task Init()
        {
            await Context.Authorize(roles: new[] { "administrators" });
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (Meetups.IsRefreshRequired)
            {
                await meetupsService.LoadMeetups(Meetups);
            }

            await base.PreRender();
        }

        public async Task Delete(int id)
        {
            await meetupsService.DeleteMeetup(id);
            Meetups.RequestRefresh();
        }
    }
}

