﻿using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra {
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData>
        where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        internal int SkippedItemsCount => PageSize * PageIndex;
        internal static int ItemsCountInPage = 10;
        public int PageIndex { get; set; }
        public int TotalPages => totalPages;
        public bool HasNextPage => PageIndex < TotalPages - 1;
        public bool HasPreviousPage => PageIndex > 0;
        public int PageSize { get; set; } = ItemsCountInPage;
        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        protected internal override IQueryable<TData> CreateSQL() => AddSkipAndTake(base.CreateSQL());
        internal IQueryable<TData> AddSkipAndTake(IQueryable<TData> q) => q.Skip(SkippedItemsCount).Take(PageSize);
        internal int totalPages => (int)Math.Ceiling(CountPages);
        internal double CountPages => ItemsCount / (double)PageSize;
        internal int ItemsCount => base.CreateSQL().Count();
    }
}
