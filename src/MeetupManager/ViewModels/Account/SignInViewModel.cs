using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.ViewModel.Validation;
using MeetupManager.Core.Model;
using MeetupManager.Core.Services;

namespace MeetupManager.ViewModels.Account
{
    public class SignInViewModel : MeetupManager.ViewModels.MasterPageViewModel
    {
        private readonly AccountService accountService;

        public SignInModel Model { get; set; } = new();

        public SignInViewModel(AccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task SignIn()
        {
            var result = await accountService.SignIn(Model);
            if (!result.Succeeded)
            {
                this.AddModelError(vm => vm.Model, "The credentials are incorrect!");
                Context.FailOnInvalidModelState();
            }
            else
            {
                Context.RedirectToRoute("Default");
            }
        }
    }
}

