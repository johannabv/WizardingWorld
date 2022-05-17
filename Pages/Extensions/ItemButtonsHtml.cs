using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WizardingWorld.Pages.Extensions {
    public static class ItemButtonsHtml {
        public static IHtmlContent ItemButtons<TModel>(
            this IHtmlHelper<TModel> h, string id) {
            List<object> s = HtmlStrings(h, id);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel>(IHtmlHelper<TModel> h, string id) {
            List<object> l = new List<object> {
                h.MyBtn("Edit", id),
                new HtmlString("&nbsp;"),
                h.MyBtn("Details", id),
                new HtmlString("&nbsp;"),
                h.MyBtn("Delete", id)
            };
            return l;
        }
    }
}
