﻿using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;

namespace WizardingWorld.Infra.Initializers {
    public abstract class BaseInitializer<TData> where TData : BaseData{
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s) {
            db = c;
            set = s;
        }
        public void Init() {
            if (set?.Any() ?? true) return;
            set.AddRange(GetEntities);
            db?.SaveChanges();
        } 
        protected abstract IEnumerable<TData> GetEntities { get; }
        internal static bool IsCorrectIsoCode(string id) => !string.IsNullOrWhiteSpace(id) && char.IsLetter(id[0]);
    } 
    public static class WizardingWorldDbInitializer {
        public static void Init(WizardingWorldDb? db) {
            new CharacterInitializer(db).Init();
            new SpellInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new HousesInitializer(db).Init();
        }
    }
}
