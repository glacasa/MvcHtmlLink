using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;

namespace MvcHtmlLink
{
    public class HtmlLink : IDisposable
    {
        private readonly ViewContext _viewContext;

        public HtmlLink(ViewContext viewContext, string targetUrl, IDictionary<string, object> htmlAttributes, AjaxOptions ajaxOptions = null)
        {
            _viewContext = viewContext;
            _viewContext.Writer.Write(GenerateLink(targetUrl, htmlAttributes, ajaxOptions));
        }
        
        private static string GenerateLink(string targetUrl, IDictionary<string, object> htmlAttributes, AjaxOptions ajaxOptions)
        {
            TagBuilder tag = new TagBuilder("a");

            tag.MergeAttributes(htmlAttributes);
            tag.MergeAttribute("href", targetUrl);

            if (ajaxOptions != null)
            {
                tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            }

            return tag.ToString(TagRenderMode.StartTag);
        }


        public void Dispose()
        {
            _viewContext.Writer.Write("</a>");
        }
    }
}
