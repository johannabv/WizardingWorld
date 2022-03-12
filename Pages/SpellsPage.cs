using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class SpellsPage : BasePage<SpellView, Spell, ISpellRepo> {
        public SpellsPage(ISpellRepo r) : base(r) { }
        protected override Spell toObject(SpellView item) => new SpellViewFactory().Create(item);
        protected override SpellView toView(Spell entity) => new SpellViewFactory().Create(entity);
    }
}
