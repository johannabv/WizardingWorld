using System.ComponentModel;
using System.Reflection;
using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
        where TView : BaseView, new()
        where TEntity : BaseEntity
        where TRepo : IOrderedRepo<TEntity> {
        protected OrderedPage(TRepo r) : base(r) { }
        public string? CurrentOrder {
            get => FromCurrentOrder(repo.CurrentOrder);
            set => repo.CurrentOrder = ToCurrentOrder(value);
        } 
        private static string? FromCurrentOrder(string? value) {
            bool isDesc = value?.Contains("_desc") ?? false;
            string? propertyName = value?.Replace("_desc", string.Empty);
            PropertyInfo? pi = typeof(TView).GetProperty(propertyName);
            string? displayName = GetDisplayName(pi);
            return isDesc ? displayName + "_desc" : displayName;
        }
        private static string? GetDisplayName(PropertyInfo? pi) => pi?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        private static string? ToCurrentOrder(string? value) {
            bool isDesc = value?.Contains("_desc") ?? false;
            string? displayName = value?.Replace("_desc", string.Empty);
            foreach (PropertyInfo pi in typeof(TView).GetProperties()) {
                if (!IsThisDisplayName(pi, displayName)) continue;
                return isDesc ? pi.Name + "_desc" : pi.Name;
            }
            return value;
        }
        private static bool IsThisDisplayName(PropertyInfo pi, string? displayName) => GetDisplayName(pi) == displayName; 
        public string? SortOrder(string displayName) => repo.SortOrder(ToCurrentOrder(displayName)); 
    }
}
