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


        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteLink(ajaxHelper, null /* routeName */, new RouteValueDictionary(routeValues), ajaxOptions, new Dictionary<string, object>());
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return BeginRouteLink(ajaxHelper, null /* routeName */, new RouteValueDictionary(routeValues), ajaxOptions,                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteLink(ajaxHelper,  null /* routeName */, routeValues, ajaxOptions,                             new Dictionary<string, object>());
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return BeginRouteLink(ajaxHelper,  null /* routeName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, AjaxOptions ajaxOptions)
        {
            return BeginRouteLink(ajaxHelper,  routeName, new RouteValueDictionary(), ajaxOptions,                             new Dictionary<string, object>());
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return BeginRouteLink(ajaxHelper,  routeName, new RouteValueDictionary(), ajaxOptions, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return BeginRouteLink(ajaxHelper,  routeName, new RouteValueDictionary(), ajaxOptions, htmlAttributes);
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, object routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteLink(ajaxHelper,  routeName, new RouteValueDictionary(routeValues), ajaxOptions,                             new Dictionary<string, object>());
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return BeginRouteLink(ajaxHelper,  routeName, new RouteValueDictionary(routeValues), ajaxOptions,
                             HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return BeginRouteLink(ajaxHelper, routeName, routeValues, ajaxOptions, new Dictionary<string, object>());
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);
            return new HtmlLink(ajaxHelper.ViewContext, targetUrl, htmlAttributes, ajaxOptions);
        }

        public static HtmlLink BeginRouteLink(this AjaxHelper ajaxHelper,  string routeName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            string targetUrl = UrlHelper.GenerateUrl(routeName, null /* actionName */, null /* controllerName */, protocol, hostName, fragment, routeValues ?? new RouteValueDictionary(), ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, false /* includeImplicitMvcValues */);
            return new HtmlLink(ajaxHelper.ViewContext, targetUrl, htmlAttributes, ajaxOptions);
        }

    }
}
