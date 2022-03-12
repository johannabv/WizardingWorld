using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ISpellRepo : IRepo<Spell> { }
    public sealed class Spell : Entity<SpellData>{
        public Spell() : this(new SpellData()) { }
        public Spell(SpellData d) : base(d) { }
        public string SpellName => Data?.SpellName ?? defaultStr;
        public string Description => Data?.Description ?? defaultStr;
        public string Type => Data?.Type ?? defaultStr;
        public override string ToString() => $"{SpellName} ({Type}), {Description}";
    }
}
