using MvcHtmlLink.System.Web.WebPages;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private const string LinkOnClickFormat = "Sys.Mvc.AsyncHyperlink.handleClick(this, new Sys.UI.DomEvent(event), {0});";
        private const string FormOnClickValue = "Sys.Mvc.AsyncForm.handleClick(this, new Sys.UI.DomEvent(event));";
        private const string FormOnSubmitFormat = "Sys.Mvc.AsyncForm.handleSubmit(this, new Sys.UI.DomEvent(event), {0});";

        private readonly ViewContext _viewContext;

        public HtmlLink(ViewContext viewContext, string targetUrl, IDictionary<string, object> htmlAttributes, AjaxOptions ajaxOptions = null)
        {
            _viewContext = viewContext;
            _viewContext.Writer.Write(GenerateLink(targetUrl, htmlAttributes, ajaxOptions));
        }
        
        private string GenerateLink(string targetUrl, IDictionary<string, object> htmlAttributes, AjaxOptions ajaxOptions)
        {
            TagBuilder tag = new TagBuilder("a");

            tag.MergeAttributes(htmlAttributes);
            tag.MergeAttribute("href", targetUrl);

            if (ajaxOptions != null)
            {
                if (_viewContext.UnobtrusiveJavaScriptEnabled)
                {
                    tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
                }
                else
                {
                    tag.MergeAttribute("onclick", GenerateAjaxScript(ajaxOptions, LinkOnClickFormat));
                }
                //tag.MergeAttributes(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            }

            return tag.ToString(TagRenderMode.StartTag);
        }

        private static string GenerateAjaxScript(AjaxOptions ajaxOptions, string scriptFormat)
        {
            var ajaxOptionsHelper = new AjaxOptionsHelper(ajaxOptions);
            string optionsString = ajaxOptionsHelper.ToJavascriptString();

            return String.Format(CultureInfo.InvariantCulture, scriptFormat, optionsString);
        }


        public void Dispose()
        {
            _viewContext.Writer.Write("</a>");
        }
    }
}
