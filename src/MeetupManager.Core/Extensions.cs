using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.AutoUI.Annotations;
using DotVVM.Framework.Controls;
using MeetupManager.Core.Data;
using MeetupManager.Core.Selection;
using MeetupManager.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeetupManager.Core
{
    public static class Extensions
    {

        public static IServiceCollection AddMeetupManagerCoreServices(this IServiceCollection services)
        {
            services.AddEntityFrameworkSqlite()
                .AddDbContext<AppDbContext>();

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.Scan(a => a.FromAssemblies(typeof(Extensions).Assembly)

                .AddClasses(c => c.InNamespaces("MeetupManager.Core.Services"))
                    .AsSelf()
                    .WithScopedLifetime()
                    
                .AddClasses(c => c.AssignableTo(typeof(ISelectionProvider<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()

                .AddClasses(c => c.AssignableTo(typeof(ISelectionProvider<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            );

            return services;
        }

        public static async Task LoadFromQueryableAsync<T>(this GridViewDataSet<T> dataSet, IQueryable<T> source)
        {
            source = dataSet.ApplyFilteringToQueryable(source);
            dataSet.Items = await dataSet.ApplyOptionsToQueryable(source).ToListAsync();
            dataSet.PagingOptions.TotalItemsCount = await source.CountAsync();
            dataSet.IsRefreshRequired = false;
        }

    }
}
