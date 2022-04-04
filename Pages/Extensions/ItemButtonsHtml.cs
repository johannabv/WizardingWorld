using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class ItemButtonsHtml {
        public static IHtmlContent ItemButtons<TModel>(this IHtmlHelper<TModel> h, string id) {
            var s = HtmlStrings(h, id);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel>(IHtmlHelper<TModel> h,  string id) {
            var l = new List<object> {
                h.Button("Edit", id),
                new HtmlString("&nbsp;"),
                h.Button("Details", id),
                new HtmlString("&nbsp;"),
                h.Button("Delete", id)
            };
            return l;
        }
    }
}
