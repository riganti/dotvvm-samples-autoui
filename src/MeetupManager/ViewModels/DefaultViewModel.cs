using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using MeetupManager.Core.Model;
using MeetupManager.Core.Services;

namespace MeetupManager.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly MeetupsService meetupsService;

        public GridViewDataSet<MeetupModel> Meetups { get; set; } = new()
        {
            PagingOptions =
            {
                PageSize = 12
            },
            SortingOptions =
            {
                SortExpression = nameof(MeetupModel.BeginDate),
                SortDescending = true
            }
        };

        public DefaultViewModel(MeetupsService meetupsService)
        {
            this.meetupsService = meetupsService;
        }

        public override async Task PreRender()
        {
            if (Meetups.IsRefreshRequired)
            {
                await meetupsService.LoadMeetups(Meetups);
            }

            await base.PreRender();
        }
    }
}
