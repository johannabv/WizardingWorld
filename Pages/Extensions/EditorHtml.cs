using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace WizardingWorld.Pages.Extensions
{
    public static class EditorHtml
    {
        public static IHtmlContent Editor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
            l.Add(new HtmlString("<div class=\"row\">"));
            
            l.Add(new HtmlString("<dd class=\"col-sn-2\">"));
            l.Add(h.LabelFor(e, null, new { @class = "control-label" }));
            l.Add(new HtmlString("</dd>"));
            
            l.Add(new HtmlString("<dd class=\"col-sn-10\">"));
            l.Add(h.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } }));
            l.Add(new HtmlString("&nbsp;"));
            l.Add(new HtmlString("&nbsp;"));
            l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
            l.Add(new HtmlString("</dd>"));
            
            l.Add(new HtmlString("</div>"));
            return l;
        }
    }
}
