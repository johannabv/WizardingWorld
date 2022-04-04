﻿using WizardingWorld.Domain;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
        where TView : BaseView, new()
        where TEntity : BaseEntity
        where TRepo : IOrderedRepo<TEntity> {
        protected OrderedPage(TRepo r) : base(r) { }
        public string? CurrentSort {
            get => repo.CurrentSort;
            set => repo.CurrentSort = value;
        }
        public string? SortOrder(string propertyName) => repo.SortOrder(propertyName); 
    }
}
