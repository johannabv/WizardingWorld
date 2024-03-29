﻿using System.Globalization;
using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CountriesInitializer : BaseInitializer<CountryData> {
        public CountriesInitializer(WizardingWorldDb? db) : base(db, db?.Countries) { }
        protected override IEnumerable<CountryData> GetEntities {
            get {
                List<CountryData> l = new();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    RegionInfo c = new(new CultureInfo(cul.Name, false).LCID);
                    string id = c.ThreeLetterISORegionName;
                    if (!IsCorrectIsoCode(id)) continue;
                    if (l.FirstOrDefault(x => x.Id == id) is not null) continue;
                    CountryData d = CreateCountry(id, c.EnglishName, c.NativeName);
                    l.Add(d);
                }
                return l;
            }
        } 
        internal static CountryData CreateCountry(string code, string name, string description) 
            => new() { 
                Id = code ?? BaseData.NewId, 
                Name = name, 
                Code = code ?? BaseEntity.DefaultStr, 
                Description = description
            };
    }
}
