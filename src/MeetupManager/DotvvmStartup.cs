﻿using DotVVM.AutoUI;
using DotVVM.AutoUI.Controls;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using MeetupManager.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MeetupManager
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);

            config.Styles.Register<ValidationSummary>()
                .AddClass("alert alert-danger validation-summary");
            config.Styles.Register<GridView>()
                .AddClass("table table-striped table-bordered");
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");

            config.RouteTable.Add("LocationList", "locations", "Views/LocationList.dothtml");
            config.RouteTable.Add("LocationDetail", "location/{Id?:int}", "Views/LocationDetail.dothtml");

            config.RouteTable.Add("MeetupList", "meetups", "Views/MeetupList.dothtml");
            config.RouteTable.Add("MeetupDetail", "meetup/{Id?:int}", "Views/MeetupDetail.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddCodeControls("cc", typeof(MenuRouteLink));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.RegisterStylesheetFile("bootstrap-css", "wwwroot/lib/bootstrap/css/bootstrap.min.css");
            config.Resources.RegisterScriptFile("bootstrap", "wwwroot/lib/bootstrap/js/bootstrap.min.js", dependencies: new[] { "bootstrap-css", "jquery" });
            config.Resources.RegisterScriptFile("jquery", "wwwroot/lib/jquery/jquery.min.js");
            config.Resources.RegisterStylesheetFile("bootstrap-icons","wwwroot/lib/bootstrap-icons/font/bootstrap-icons.min.css");
            config.Resources.RegisterStylesheetFile("styles", "wwwroot/styles.css");
        }

		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            options.AddHotReload();
            options.AddAutoUI();
        }
    }
}