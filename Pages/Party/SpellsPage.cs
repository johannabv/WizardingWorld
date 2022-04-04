using WizardingWorld.Aids;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    public class SpellsPage : PagedPage<SpellView, Spell, ISpellRepo> {
        public SpellsPage(ISpellRepo r) : base(r) { }
        protected override Spell ToObject(SpellView? item) => new SpellViewFactory().Create(item);
        protected override SpellView ToView(Spell? entity) => new SpellViewFactory().Create(entity);
        public string[] IndexColumns { get; } = new[] {
            nameof(SpellView.SpellName),
            nameof(SpellView.Description),
            nameof(SpellView.Type)
        };
        public object? GetValue(string name, SpellView v) 
            => Safe.Run(() => {
                var propertyInfo = v?.GetType()?.GetProperty(name);
                return propertyInfo == null ? null : propertyInfo.GetValue(v);
            }, null);
        
    }
}
