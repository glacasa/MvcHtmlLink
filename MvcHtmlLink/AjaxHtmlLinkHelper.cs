using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using System.Web.WebPages;

namespace MvcHtmlLink
{
    public static class AjaxHtmlLinkHelper
    {

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, AjaxOptions ajaxOptions)
        {
            return ActionHtmlLink(ajaxHelper, actionName, (string)null /* controllerName */, ajaxOptions);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            return ActionHtmlLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            return ActionHtmlLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions)
        {
            return ActionHtmlLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return ActionHtmlLink(ajaxHelper, actionName, (string)null /* controllerName */, routeValues, ajaxOptions, htmlAttributes);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            return ActionHtmlLink(ajaxHelper, actionName, controllerName, null /* values */, ajaxOptions, null /* htmlAttributes */);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions)
        {
            return ActionHtmlLink(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, null /* htmlAttributes */);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, object routeValues, AjaxOptions ajaxOptions, object htmlAttributes)
        {
            RouteValueDictionary newValues = ObjectToDictionary(routeValues);
            RouteValueDictionary newAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return ActionHtmlLink(ajaxHelper, actionName, controllerName, newValues, ajaxOptions, newAttributes);
        }

        public static HtmlLink ActionHtmlLink(this AjaxHelper ajaxHelper, string actionName, string controllerName, RouteValueDictionary routeValues, AjaxOptions ajaxOptions, IDictionary<string, object> htmlAttributes)
        {
            return new HtmlLink(ajaxHelper, actionName, controllerName, routeValues, ajaxOptions, htmlAttributes);
        }





        private static RouteValueDictionary ObjectToDictionary(object value)
        {
            RouteValueDictionary dictionary = new RouteValueDictionary();

            if (value != null)
            {
                foreach (PropertyHelper helper in PropertyHelper.GetProperties(value))
                {
                    dictionary.Add(helper.Name, helper.GetValue(value));
                }
            }

            return dictionary;
        }
    }
}
