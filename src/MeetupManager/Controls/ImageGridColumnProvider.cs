using DotVVM.AutoUI;
using DotVVM.AutoUI.Controls;
using DotVVM.AutoUI.Metadata;
using DotVVM.AutoUI.PropertyHandlers.GridColumns;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace MeetupManager.Controls
{
    public class ImageGridColumnProvider : GridColumnProviderBase
    {
        public override string[] UIHints => new [] { "Image" };

        public override bool CanHandleProperty(PropertyDisplayMetadata property, AutoUIContext context)
        {
            return property.Type == typeof(string);
        }

        protected override GridViewColumn CreateColumnCore(PropertyDisplayMetadata property, AutoGridViewColumn.Props props, AutoUIContext context)
        {
            var valueBinding = ValueOrBinding<string>.FromBoxedValue(context.CreateValueBinding(property));
            
            return new GridViewTemplateColumn()
            {
                ContentTemplate = new CloneTemplate(
                    new HtmlGenericControl("img")
                        .SetAttribute("src", valueBinding)
                        .SetProperty(d => d.Visible, valueBinding.Select(b => b != null)),
                    new HtmlGenericControl("div")
                        .AddCssClass("img-none")
                        .SetProperty(d => d.Visible, valueBinding.Select(b => b == null))
                )
            };
        }
    }
}
