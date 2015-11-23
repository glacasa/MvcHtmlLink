using MvcHtmlLink;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.WebPages;

namespace System.Web.Mvc.Ajax
{
    public static class AjaxHtmlLinkHelper
    {
        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions)
        {
            return BeginActionLink(ajaxHelper, actionName, (string)null /* controllerName */, ajaxOptions);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginActionLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return BeginActionLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginActionLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return BeginActionLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return BeginActionLink(ajaxHelper, actionName, controllerName, null /* values */, ajaxOptions, null /* htmlAttributes */);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginActionLink(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = TypeHelper.ObjectToDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return BeginActionLink(ajaxHelper, actionName, controllerName, newValues, ajaxOptions, newAttributes);
        }

        public static HtmlLink BeginActionLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return new HtmlLink(ajaxHelper.ViewContext, targetUrl, htmlAttributes, ajaxOptions);
        }



    }
}
