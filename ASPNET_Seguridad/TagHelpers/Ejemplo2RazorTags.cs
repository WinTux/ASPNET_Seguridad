using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace ASPNET_Seguridad.TagHelpers
{
    [HtmlTargetElement("ejemplo2", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class Ejemplo2RazorTags : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }
        private IHtmlHelper htmlHelper;
        public Ejemplo2RazorTags(IHtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (htmlHelper as IViewContextAware).Contextualize(viewContext);
            htmlHelper.ViewBag.Nombre = "Pepe";
            htmlHelper.ViewBag.Estatura = 1.78;
            htmlHelper.ViewBag.Casado = false;
            htmlHelper.ViewBag.Edad = 19;
            output.TagName = "";
            output.Content.SetHtmlContent(
                await htmlHelper.PartialAsync("TagHelpers/Ejemplo2")
            );
        }
    }
}
