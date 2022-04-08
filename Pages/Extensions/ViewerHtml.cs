﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace WizardingWorld.Pages.Extensions {
    public static class ViewerHtml {
        public static IHtmlContent ViewerFor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
            var s = HtmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent ViewerFor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, dynamic value) {
            var s = HtmlStrings(h, e, value);
            return new HtmlContentBuilder(s);
        }
        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.DisplayFor(e),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return l;
        }
        private static List<object> HtmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, dynamic value) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.Raw(value),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            }; 
            return l;
        }
    }
}
