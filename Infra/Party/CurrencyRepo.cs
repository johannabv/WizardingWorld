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
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
                x => x.ID.Contains(y)
                || x.Code.Contains(y)
                || x.EnglishName.Contains(y)
                || x.NativeName.Contains(y)
            );
        }
    }
}
