﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Extensions {
    public static class ShowTableHtml {
        public static IHtmlContent ShowTable<TModel, TView>(this IHtmlHelper<TModel> h, IList<TView>? items)
                where TModel : IIndexModel<TView> where TView : BaseView {
            var s = HtmlStrings(h, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : BaseView {
            var m = h.ViewData.Model;
            var l = new List<object>();
            l.Add(new HtmlString("<table class=\"table\">"));
            l.Add(new HtmlString("<thead>"));
            l.Add(new HtmlString("<tr>"));
            foreach (var name in m.IndexColumns) {
                l.Add(new HtmlString("<th>"));
                l.Add(h.TabHider(name));
                l.Add(new HtmlString("</th>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>()) {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumns) {
                    l.Add(new HtmlString("<td>"));
                    l.Add(h.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString("</td>"));
                }
                l.Add(new HtmlString("<td>"));
                l.Add(h.ItemButtons(item.ID));
                l.Add(new HtmlString("</td>"));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}