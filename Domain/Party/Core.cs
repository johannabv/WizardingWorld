using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ICoresRepo : IRepo<Core> { }
    public sealed class Core : NamedEntity<CoreData> {
        public Core() : this(new()) { }
        public Core(CoreData d) : base(d) { }
        public override string ToString() => $"{Name}: {Description}";
    }
}
