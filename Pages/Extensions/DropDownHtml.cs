using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace WizardingWorld.Pages.Extensions {
    public static class DropDownHtml {
        public static IHtmlContent DropDownFor<TModel, TResult>
            (this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> list) {
            return new HtmlContentBuilder(HtmlStrings(h, e, list));
        }
        private static List<object> HtmlStrings<TModel, TResult>
            (IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, IEnumerable<SelectListItem> list) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"), 
                new HtmlString("<dd class=\"col-sn-2\">"),
                h.LabelFor(e, null, new { @class = "control-label" }),
                new HtmlString("</dd>"), 
                new HtmlString("<dd class=\"col-sn-10\">"),
                h.DropDownListFor(e, list, new { @class = "form-control" }),
                h.ValidationMessageFor(e, null, new { @class = "text-danger" }),
                new HtmlString("</dd>"), 
                new HtmlString("</dl>")
            };
            return l;
        }
    }
}
