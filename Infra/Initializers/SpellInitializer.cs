using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra.Initializers
{
    public sealed class SpellInitializer : BaseInitializer<SpellData> {
        public SpellInitializer(WizardingWorldDb? db) : base(db, db?.Spells) { }
        internal static SpellData CreateSpell(string spellName, string description, string type) {
            var spell = new SpellData {
                ID = spellName + type,
                SpellName = spellName,
                Description = description,
                Type = type
            };
            return spell;
        }
        protected override IEnumerable<SpellData> GetEntities => new[] {
            CreateSpell("Accio", "summoning stuff", "neutral"),
            CreateSpell("Avada Kadavra", "killing curse", "attack"),
            CreateSpell("Protego", "protection", "defense")
        };
    }
    
}
