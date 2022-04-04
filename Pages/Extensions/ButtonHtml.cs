using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class ButtonHtml {
        public static IHtmlContent Button<TModel>(this IHtmlHelper<TModel> h, string handler, string id) {
            var s = HtmlStrings(handler, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings(string handler, string id, IPageModel? m) {
            var l = new List<object> {
                new HtmlString($"<a href=\"/{pageName(m)}/{handler}?"),
                new HtmlString($"handler={handler}&amp;"),
                new HtmlString($"id={id}&amp;"),
                new HtmlString($"order={m?.CurrentSort}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{handler}</a>")
            };
            return l;
        }
        private static string? pageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
