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

        public HtmlLink(AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            _viewContext = ajaxHelper.ViewContext;

            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);

            _viewContext.Writer.Write(GenerateLink(ajaxHelper, targetUrl, ajaxOptions, htmlAttributes));
        }

        private static string GenerateLink(AjaxHelper ajaxHelper, string targetUrl, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("a");

            tag.MergeAttributes(htmlAttributes);
            tag.MergeAttribute("href", targetUrl);

            if (ajaxHelper.ViewContext.UnobtrusiveJavaScriptEnabled)
            {
                tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            }
            else
            {
                throw new NotImplementedException();
                //tag.MergeAttribute("onclick", GenerateAjaxScript(ajaxOptions, LinkOnClickFormat));
            }

            return tag.ToString(TagRenderMode.StartTag);
        }

        public void Dispose()
        {
            _viewContext.Writer.Write("</a>");
        }

    }
}
