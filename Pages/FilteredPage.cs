﻿using WizardingWorld.Domain;
using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
        where TView : BaseView, new() 
        where TEntity : BaseEntity
        where TRepo : IFilteredRepo<TEntity> {
        protected FilteredPage(TRepo r) : base(r) { }
        public string? CurrentFilter {
            get => Repo.CurrentFilter;
            set => Repo.CurrentFilter = value;
        }
    }
}
