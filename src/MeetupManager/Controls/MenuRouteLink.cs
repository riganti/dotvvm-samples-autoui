using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace MeetupManager.Controls
{
    public class MenuRouteLink : CompositeControl
    {
        
        public DotvvmControl GetContents(
            TextOrContentCapability textOrContent,
            string routeName,
            string activeRouteNamePrefix,
            IDotvvmRequestContext context)
        {
            var routeLink = new RouteLink() { RouteName = routeName }
                .SetCapability(textOrContent)
                .AddCssClass("nav-link");
            
            if (context.Route.RouteName.StartsWith(activeRouteNamePrefix))
            {
                routeLink.AddCssClass("active");
            }

            return routeLink;
        }
        
    }
}
