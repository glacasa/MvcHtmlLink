using MvcHtmlLink;
using System.Collections.Generic;
using System.Web.Routing;
using System.Web.WebPages;

namespace System.Web.Mvc.Html
{
    public static class HtmlLinkHelper
    {
        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName)
        {
            return BeginActionLink(htmlHelper, actionName, null /* controllerName */, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, object routeValues)
        {
            return BeginActionLink(htmlHelper, actionName, null /* controllerName */, TypeHelper.ObjectToDictionary(routeValues), new RouteValueDictionary());
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, object routeValues, object htmlAttributes)
        {
            return BeginActionLink(htmlHelper, actionName, null /* controllerName */, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues)
        {
            return BeginActionLink(htmlHelper, actionName, null /* controllerName */, routeValues, new RouteValueDictionary());
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return BeginActionLink(htmlHelper, actionName, null /* controllerName */, routeValues, htmlAttributes);
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName)
        {
            return BeginActionLink(htmlHelper, actionName, controllerName, new RouteValueDictionary(), new RouteValueDictionary());
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            return BeginActionLink(htmlHelper, actionName, controllerName, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return BeginActionLink(htmlHelper, actionName, controllerName, protocol, hostName, fragment, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginActionLink(this HtmlHelper htmlHelper, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(null, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }


        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper, object routeValues)
        {
            return BeginRouteLink(htmlHelper, TypeHelper.ObjectToDictionary(routeValues));
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper, RouteValueDictionary routeValues)
        {
            return BeginRouteLink(htmlHelper, routeValues, new RouteValueDictionary());
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName)
        {
            return BeginRouteLink(htmlHelper,  routeName, (object)null /* routeValues */);
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, object routeValues)
        {
            return BeginRouteLink(htmlHelper,  routeName, TypeHelper.ObjectToDictionary(routeValues));
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, RouteValueDictionary routeValues)
        {
            return BeginRouteLink(htmlHelper,  routeName, routeValues, new RouteValueDictionary());
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  object routeValues, object htmlAttributes)
        {
            return BeginRouteLink(htmlHelper,  TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return BeginRouteLink(htmlHelper,  null /* routeName */, routeValues, htmlAttributes);
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, object routeValues, object htmlAttributes)
        {
            return BeginRouteLink(htmlHelper,  routeName, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(routeName, null, null, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, string protocol, string hostName, string fragment, object routeValues, object htmlAttributes)
        {
            return BeginRouteLink(htmlHelper,  routeName, protocol, hostName, fragment, TypeHelper.ObjectToDictionary(routeValues), HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this HtmlHelper htmlHelper,  string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(routeName, null, null, protocol, hostName, fragment, routeValues, htmlHelper.RouteCollection, htmlHelper.ViewContext.RequestContext, true);
            return new HtmlLink(htmlHelper.ViewContext, targetUrl, htmlAttributes);
        }
    }
}
