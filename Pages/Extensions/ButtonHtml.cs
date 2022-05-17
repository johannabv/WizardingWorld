using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class ButtonHtml {
        public static IHtmlContent MyBtn<TModel>(
            this IHtmlHelper<TModel> h, string handler, string id) {
            List<object> s = HtmlStrings(handler, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings(string handler, string id, IPageModel? m) {
            List<object> l = new List<object> {
                new HtmlString($"<a style=\"text-decoration:none;\" href=\"/{PageName(m)}/{handler}?"),
                new HtmlString($"handler={handler}&amp;"),
                new HtmlString($"id={id}&amp;"),
                new HtmlString($"order={m?.CurrentOrder}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{handler}</a>")
            };
            return l;
        }
        private static string? PageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
