using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASPNET_Seguridad.TagHelpers
{
    [HtmlTargetElement("sumar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class SumarTag : TagHelper
    {
        [HtmlAttributeName("n1")]
        public double a { get; set; }
        [HtmlAttributeName("n2")]
        public double b { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.SetHtmlContent(
                string.Format("<h3>{0} + {1} = {2}</h3>", a, b , a+b)
            );
        }
    }
}
