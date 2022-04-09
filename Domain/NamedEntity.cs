using WizardingWorld.Data;

namespace WizardingWorld.Domain {
    public abstract class NamedEntity<TData> : BaseEntity<TData> where TData : NamedData, new() {
        public NamedEntity() : this(new TData()) { }
        public NamedEntity(TData d) : base(d) { }
        public string Name => GetValue(Data?.Name);
        public string Code => GetValue(Data?.Code);
        public string Description => GetValue(Data?.Description);
    }
}
