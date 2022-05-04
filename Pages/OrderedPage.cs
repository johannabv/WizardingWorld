﻿using System.ComponentModel;
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
            get => OrderedPage<TView, TEntity, TRepo>.FromCurrentOrder(repo.CurrentOrder);
            set => repo.CurrentOrder = OrderedPage<TView, TEntity, TRepo>.ToCurrentOrder(value);
        } 
        private static string? FromCurrentOrder(string? value) {
            bool isDesc = value?.Contains("_desc") ?? false;
            string? propertyName = value?.Replace("_desc", string.Empty);
            PropertyInfo? pi = typeof(TView).GetProperty(propertyName);
            string? displayName = OrderedPage<TView, TEntity, TRepo>.GetDisplayName(pi);
            return isDesc ? displayName + "_desc" : displayName;
        }
        private static string? GetDisplayName(PropertyInfo? pi) => pi?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
        private static string? ToCurrentOrder(string? value) {
            var isDesc = value?.Contains("_desc") ?? false;
            var displayName = value?.Replace("_desc", string.Empty);
            foreach (var pi in typeof(TView).GetProperties()) {
                if (!OrderedPage<TView, TEntity, TRepo>.IsThisDisplayName(pi, displayName)) continue;
                return isDesc ? pi.Name + "_desc" : pi.Name;
            }
            return value;
        }
        private static bool IsThisDisplayName(PropertyInfo pi, string? displayName) => GetDisplayName(pi) == displayName; 
        public string? SortOrder(string displayName) => repo.SortOrder(OrderedPage<TView, TEntity, TRepo>.ToCurrentOrder(displayName)); 
    }
}
