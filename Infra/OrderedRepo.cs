using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData>
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        public string? CurrentSort { get; set; }
        public static string DescendingString => "_desc";
        protected internal override IQueryable<TData> CreateSQL() => AddSort(base.CreateSQL());
        internal IQueryable<TData> AddSort(IQueryable<TData> q) { 
            if(string.IsNullOrWhiteSpace(CurrentSort)) return q;
            var e = LambdaExpression;
            if (e == null) return q;
            if (IsDescending) return q.OrderByDescending(e);
            return q.OrderBy(e);
        }
        internal bool IsDescending => CurrentSort?.EndsWith(DescendingString) ?? false;
        internal bool IsSameProperty(string s) => (string.IsNullOrEmpty(s)? false : (CurrentSort?.StartsWith(s) ?? false));
        internal string PropertyName => CurrentSort?.Replace(DescendingString, "") ?? "";
        internal PropertyInfo? PropertyInfo => typeof(TData).GetProperty(PropertyName);
        internal Expression<Func<TData, object>>? LambdaExpression {
            get {
                if(PropertyInfo is null) return null;
                var param = Expression.Parameter(typeof(TData), "x");
                var property = Expression.Property(param, PropertyInfo);
                var body = Expression.Convert(property, typeof(object));
                return Expression.Lambda<Func<TData,object>>(body, param);
            }
        }
        public string SortOrder(string propertyName) {
            var n = propertyName;
            if (!IsSameProperty(n)) return n + DescendingString;
            if (IsDescending) return n;
            return n + DescendingString;
        }
    }
}
