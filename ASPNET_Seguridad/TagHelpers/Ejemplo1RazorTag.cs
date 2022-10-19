using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace ASPNET_Seguridad.TagHelpers
{
    [HtmlTargetElement("ejemplo1", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class Ejemplo1RazorTag : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        private IHtmlHelper htmlHelper;
        public Ejemplo1RazorTag(IHtmlHelper htmlHelper) {
            this.htmlHelper = htmlHelper;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (htmlHelper as IViewContextAware).Contextualize(viewContext);
            output.TagName = "";
            output.Content.SetHtmlContent(
                await htmlHelper.PartialAsync("TagHelpers/Ejemplo1")
            );
        }
    }
}
