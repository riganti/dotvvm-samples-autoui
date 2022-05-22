using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace MeetupManager.ViewModels
{
    public class MasterPageViewModel : DotvvmViewModelBase
    {
        public async Task SignOut()
        {
            await Context.GetAuthentication().SignOutAsync(IdentityConstants.ApplicationScheme);
            Context.RedirectToRoute("Default");
        }
    }
}
