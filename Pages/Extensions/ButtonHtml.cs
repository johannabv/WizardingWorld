using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class ButtonHtml {
        public static IHtmlContent Button<TModel>(this IHtmlHelper<TModel> h, string handler, string id) {
            var s = htmlStrings(handler, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings(string handler, string id, IPageModel? m) {
            var l = new List<object>();
            l.Add(new HtmlString($"<a href=\"/{pageName(m)}?"));
            l.Add(new HtmlString($"handler={handler}&amp;"));
            l.Add(new HtmlString($"id={id}&amp;"));
            l.Add(new HtmlString($"order={m?.CurrentSort}&amp;"));
            l.Add(new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"));
            l.Add(new HtmlString($"filter={m?.CurrentFilter}\">"));
            l.Add(new HtmlString($"{handler}</a>"));
            return l;
        }
        private static string? pageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
