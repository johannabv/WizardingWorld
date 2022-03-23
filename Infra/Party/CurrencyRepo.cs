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
    }
}
