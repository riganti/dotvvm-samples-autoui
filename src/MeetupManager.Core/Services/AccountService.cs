using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeetupManager.Core.Data;
using MeetupManager.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeetupManager.Core.Services
{
    public class AccountService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = httpContextAccessor;
        }


        public async Task<SignInResult> SignIn(SignInModel model)
        {
            return await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);
        }

        public async Task<MyProfileModel> GetMyProfile()
        {
            var user = await GetCurrentUser();

            return new MyProfileModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                LocationPreferences = user.AppUserLocationPreferences.Select(p => p.LocationId).ToList()
            };
        }

        private async Task<AppUser> GetCurrentUser()
        {
            var userIdentity = httpContextAccessor.HttpContext!.User.Identity!;
            if (!userIdentity.IsAuthenticated)
            {
                throw new SecurityException("User not signed in!");
            }

            var user = await userManager.Users
                .Include(u => u.AppUserLocationPreferences)
                .SingleAsync(u => u.UserName == userIdentity.Name);
            return user!;
        }

        public async Task SaveProfile(MyProfileModel model)
        {
            var user = await GetCurrentUser();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            
            user.AppUserLocationPreferences.Clear();
            foreach (var locationId in model.LocationPreferences)
            {
                user.AppUserLocationPreferences.Add(new AppUserLocationPreference() { LocationId = locationId });
            }

            await userManager.UpdateAsync(user);
        }

    }
}
