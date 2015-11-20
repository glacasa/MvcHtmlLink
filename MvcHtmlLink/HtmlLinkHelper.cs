using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;

namespace MvcHtmlLink
{
    public static class HtmlLinkHelper
    {
        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName)
        {
            return ActionHtmlLink(htmlHelper, actionName, null /* controllerName */, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, object routeValues)
        {
            return ActionHtmlLink(htmlHelper, actionName, null /* controllerName */, TypeHelper.ObjectToDictionary(routeValues), new RouteValueDictionary());
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, object routeValues, object htmlAttributes)
        {
            return ActionHtmlLink(htmlHelper, actionName, null /* controllerName */, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues)
        {
            return ActionHtmlLink(htmlHelper, actionName, null /* controllerName */, routeValues, new RouteValueDictionary());
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return ActionHtmlLink(htmlHelper, actionName, null /* controllerName */, routeValues, htmlAttributes);
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            return ActionHtmlLink(htmlHelper, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return ActionHtmlLink(htmlHelper, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return ActionHtmlLink(htmlHelper, actionName, controllerName, protocol, hostName, fragment, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink ActionHtmlLink(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }
    }
}
