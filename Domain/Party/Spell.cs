using WizardingWorld.Data.Enums;

namespace WizardingWorld.Domain.Party {
    public interface ISpellsRepo : IRepo<Spell> { }
    public sealed class Spell : BaseEntity<SpellData>{
        public Spell() : this(new ()) { }
        public Spell(SpellData d) : base(d) { }
        public string SpellName => GetValue(Data?.SpellName);
        public string Description => GetValue(Data?.Description);
        public string Type => GetValue(Data?.Type);
        public override string ToString() => $"{SpellName} ({Type}), {Description}";
    }
}
