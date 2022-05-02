using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IWoodsRepo : IRepo<Wood> { }
    public sealed class Wood : BaseEntity<WoodData> {
        public Wood() : this(new()) { }
        public Wood(WoodData d) : base(d) { }
        public string Name => GetValue(Data?.Name);
        public string Description => GetValue(Data?.Description);
        public string Traits => GetValue(Data?.Traits);
        public override string ToString() => $"{Name}: {Traits}";
    }
}
