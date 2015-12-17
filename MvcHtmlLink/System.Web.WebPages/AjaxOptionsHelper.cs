using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Ajax;

namespace MvcHtmlLink.System.Web.WebPages
{
    internal class AjaxOptionsHelper
    {
        private AjaxOptions AjaxOptions { get; set; }

        internal AjaxOptionsHelper(AjaxOptions ajaxOptions)
        {
            this.AjaxOptions = ajaxOptions;
        }

        internal string InsertionModeString
        {
            get
            {
                switch (AjaxOptions.InsertionMode)
                {
                    case InsertionMode.Replace:
                        return "Sys.Mvc.InsertionMode.replace";
                    case InsertionMode.InsertBefore:
                        return "Sys.Mvc.InsertionMode.insertBefore";
                    case InsertionMode.InsertAfter:
                        return "Sys.Mvc.InsertionMode.insertAfter";
                    default:
                        return ((int)AjaxOptions.InsertionMode).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        private static string PropertyStringIfSpecified(string propertyName, string propertyValue)
        {
            if (!String.IsNullOrEmpty(propertyValue))
            {
                string escapedPropertyValue = propertyValue.Replace("'", @"\'");
                return String.Format(CultureInfo.InvariantCulture, " {0}: '{1}',", propertyName, escapedPropertyValue);
            }
            return String.Empty;
        }

        private static string EventStringIfSpecified(string propertyName, string handler)
        {
            if (!String.IsNullOrEmpty(handler))
            {
                return String.Format(CultureInfo.InvariantCulture, " {0}: Function.createDelegate(this, {1}),", propertyName, handler.ToString());
            }
            return String.Empty;
        }

        internal string ToJavascriptString()
        {
            // creates a string of the form { key1: value1, key2 : value2, ... }
            // This method is used for generating obtrusive JavaScript (using MicrosoftMvcAjax.js) which is no longer 
            // actively maintained. Consequently, we'll ignore the AllowCache option if it's set for this code path.
            StringBuilder optionsBuilder = new StringBuilder("{");
            optionsBuilder.AppendFormat(CultureInfo.InvariantCulture, " insertionMode: {0},", InsertionModeString);
            optionsBuilder.Append(PropertyStringIfSpecified("confirm", AjaxOptions.Confirm));
            optionsBuilder.Append(PropertyStringIfSpecified("httpMethod", AjaxOptions.HttpMethod));
            optionsBuilder.Append(PropertyStringIfSpecified("loadingElementId", AjaxOptions.LoadingElementId));
            optionsBuilder.Append(PropertyStringIfSpecified("updateTargetId", AjaxOptions.UpdateTargetId));
            optionsBuilder.Append(PropertyStringIfSpecified("url", AjaxOptions.Url));
            optionsBuilder.Append(EventStringIfSpecified("onBegin", AjaxOptions.OnBegin));
            optionsBuilder.Append(EventStringIfSpecified("onComplete", AjaxOptions.OnComplete));
            optionsBuilder.Append(EventStringIfSpecified("onFailure", AjaxOptions.OnFailure));
            optionsBuilder.Append(EventStringIfSpecified("onSuccess", AjaxOptions.OnSuccess));
            optionsBuilder.Length--;
            optionsBuilder.Append(" }");
            return optionsBuilder.ToString();
        }
    }
}
