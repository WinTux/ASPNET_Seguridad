using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPNET_Seguridad.TagHelpers
{
    [HtmlTargetElement("primer",TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PrimerTag : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent("<center><h2>Primer tag</h2></center>");
        }
    }
}
