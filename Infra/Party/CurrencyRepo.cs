using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Infra.Party {
    public class CurrencyRepo : Repo<Currency, CurrencyData>, ICurrencyRepo {
        public CurrencyRepo(WizardingWorldDb? db) : base(db, db?.Currencies) { }
        protected override Currency ToDomain(CurrencyData d) => new(d);
        internal override IQueryable<CurrencyData> AddFilter(IQueryable<CurrencyData> q) {
            var y = CurrentFilter;
            return string.IsNullOrWhiteSpace(y) ? q : q.Where(
                x => DoesContain(x.ID, y)
                || DoesContain(x.Code, y)
                || DoesContain(x.EnglishName, y)
                || DoesContain(x.NativeName, y)
            );
        }
    }
}
