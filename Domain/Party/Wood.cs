using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface IWoodsRepo : IRepo<Wood> { }
    public sealed class Wood : NamedEntity<WoodData> {
        public Wood() : this(new()) { }
        public Wood(WoodData d) : base(d) { }
        public override string ToString() => $"{Name}: {Description}";
    }
}
