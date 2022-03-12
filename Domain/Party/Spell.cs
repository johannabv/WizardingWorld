using WizardingWorld.Data.Party;

namespace WizardingWorld.Domain.Party {
    public interface ISpellRepo : IRepo<Spell> { }
    public sealed class Spell : Entity<SpellData>{
        public Spell() : this(new SpellData()) { }
        public Spell(SpellData d) : base(d) { }
        public string SpellName => getValue(Data?.SpellName);
        public string Description => getValue(Data?.Description);
        public string Type => getValue(Data?.Type);
        public override string ToString() => $"{SpellName} ({Type}), {Description}";
    }
}
