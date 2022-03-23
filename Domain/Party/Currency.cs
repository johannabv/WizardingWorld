using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICurrencyRepo : IRepo<Currency> { }
    public sealed class Currency : Entity<CurrencyData> {
        public Currency() : this(new CurrencyData()) { }
        public Currency(CurrencyData d) : base(d) { }
        public string Name => GetValue(Data?.Name);
        public string Code => GetValue(Data?.Code);
        public override string ToString() => $"{Name} ({Code})";
    }
}
