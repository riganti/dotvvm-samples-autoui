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

namespace MeetupManager.ViewModels.Account
{
    public class MyProfileViewModel : MeetupManager.ViewModels.MasterPageViewModel
    {
        private readonly AccountService accountService;

        public string StatusMessage { get; set; }

        public MyProfileModel Model { get; set; }

        public SelectionViewModel<LocationSelection> Locations { get; set; } = new();


        public MyProfileViewModel(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public override async Task Init()
        {
            await Context.Authorize();
            await base.Init();
        }

        public override async Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                Model = await accountService.GetMyProfile();
            }
            await base.PreRender();
        }

        public async Task Save()
        {
            await accountService.SaveProfile(Model);
            StatusMessage = "The changes were saved successfully.";
        }
    }
}

