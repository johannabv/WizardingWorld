using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages.Extensions {
    public static class ShowRelatedTableHtml {
        public static IHtmlContent ShowRelatedTable<TModel, TView, TEntity, T>(this IHtmlHelper<TModel> h, IList<TEntity>? items, TView x, T y)
                where TModel : IIndexModel<TView> where TView : BaseView {
            return new HtmlContentBuilder(HtmlStrings(h, items, x, y));
        }
        private static List<object> HtmlStrings<TModel, TView, TEntity, T>(IHtmlHelper<TModel> h, IList<TEntity>? items, TView x, T y)
            where TModel : IIndexModel<TView> where TView : BaseView {
            TModel? m = h.ViewData.Model;
            var l = new List<object> {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")
            };
            foreach (string name in m.RelatedIndexColumns) {
                l.Add(new HtmlString("<td>"));
                l.Add(h.Raw(m.GetDisplayName<T>(name)));
                l.Add(new HtmlString("</td>"));
            }
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (TEntity item in items) {
                l.Add(new HtmlString("<tr>"));
                foreach (string name in m.RelatedIndexColumns) {
                    l.Add(new HtmlString("<td>"));
                    l.Add(h.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString("</td>"));
                }
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}