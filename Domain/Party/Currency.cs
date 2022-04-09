﻿using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICurrencyRepo : IRepo<Currency> { }
    public sealed class Currency : NamedEntity<CurrencyData> {
        public Currency() : this(new ()) { }
        public Currency(CurrencyData d) : base(d) { }
        
    }
}
