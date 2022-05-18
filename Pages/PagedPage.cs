﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using WizardingWorld.Aids;
using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>, IPageModel, IIndexModel<TView>
        where TView : BaseView, new()
        where TEntity : BaseEntity
        where TRepo : IPagedRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        protected override void SetAttributes(int pageIndex, string? currentFilter, string? sortOrder) {
            PageIndex = pageIndex;
            CurrentFilter = currentFilter;
            CurrentOrder = sortOrder;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage  => repo.HasNextPage;
        public bool HasPreviousPage  => repo.HasPreviousPage; 
        public virtual string[] IndexColumns => Array.Empty<string>();
        public virtual string[] RelatedIndexColumns => Array.Empty<string>();
        protected override IActionResult RedirectToIndex() => RedirectToPage("./Index", "Index", new {
            pageIndex = PageIndex,
            currentFilter = CurrentFilter,
            sortOrder = CurrentOrder} 
        );
        protected internal override IActionResult RedirectToEdit(TView v) {
            TempData["Item"] = JsonSerializer.Serialize(v);
            return RedirectToPage("./Edit", "Edit",
            new {
                id = v.ID,
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentOrder
            });
        }
        protected internal override IActionResult RedirectToDelete(string id) {
            TempData["Error"] = "The record you attempted to delete "
                  + "was modified by another user after you selected delete. "
                  + "The delete operation was canceled and the current values in the "
                  + "database have been displayed. If you still want to delete this "
                  + "record, click the Delete button again.";

            return RedirectToPage("./Delete", "Delete",
            new {
                id,
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentOrder
            });
        }

        public virtual object? GetValue<T>(string name, T v)
            => Safe.Run(() => {
                PropertyInfo? pi = v?.GetType()?.GetProperty(name);
                return pi?.GetValue(v);
            }, null);

        public string? GetDisplayName<T>(string propertyName) 
            => Safe.Run(() => {
                PropertyInfo? pInfo = typeof(T).GetProperty(propertyName);
                object[]? obj = pInfo ? .GetCustomAttributes(typeof(DisplayNameAttribute), true);
                return obj?.Cast<DisplayNameAttribute>().Single().DisplayName;
            }, propertyName);
    }
}
