using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class TabHiderHtml {
        public static IHtmlContent TabHider<TModel>(this IHtmlHelper<TModel> h, string name) {
            return new HtmlContentBuilder(HtmlStrings(name, h.ViewData.Model as IPageModel));
        }
        private static List<object> HtmlStrings(string? name, IPageModel? m) {
            name ??= "Unspecified";
            var l = new List<object> {
                new HtmlString($"<a href=\"/{PageName(m)}?"),
                new HtmlString($"handler=Index&amp;"),
                new HtmlString($"order={m?.SortOrder(name)}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\">"),
                new HtmlString($"{name}</a>")
            };
            return l;
        }
        private static string? PageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
