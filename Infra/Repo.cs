﻿using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Party {
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain, TData> where TDomain : BaseEntity<TData>, new() where TData : BaseData, new() {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c,s) { }
        internal protected static bool DoesContain(string? value, string? subValue) => (subValue is null) || (value?.Contains(subValue) ?? false);
    }
}
