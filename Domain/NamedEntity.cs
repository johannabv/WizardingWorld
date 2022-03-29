using WizardingWorld.Data;

namespace WizardingWorld.Domain {
    public abstract class NamedEntity<TData> : BaseEntity<TData> where TData : NamedData, new() {
        public NamedEntity() : this(new TData()) { }
        public NamedEntity(TData d) : base(d) { }
        public string EnglishName => GetValue(Data?.EnglishName);
        public string Code => GetValue(Data?.Code);
        public string NativeName => GetValue(Data?.NativeName);
    }
}
