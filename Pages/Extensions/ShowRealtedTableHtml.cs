using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages.Extensions {
    public static class ShowRealtedTableHtml {
        public static IHtmlContent ShowRealtedTable<TModel, TView>(
            this IHtmlHelper<TModel> h, IList<TView>? items)
                where TModel : IIndexModel<TView> where TView : BaseView {
            var s = HtmlStrings(h, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : BaseView {
            var m = h.ViewData.Model;
            var l = new List<object> {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")
            };
            foreach (var name in m.IndexColumnsRelatedTable) {
                l.Add(new HtmlString("<td>"));
                l.Add(m.DisplayName(name));
                l.Add(new HtmlString("</td>"));
            }
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>()) {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumnsRelatedTable) {
                    l.Add(new HtmlString("<td>"));
                    l.Add(h.Raw(typeof(TView).GetProperty(name)?.GetValue(item)));
                    l.Add(new HtmlString("</td>"));
                }
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}
