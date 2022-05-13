using Microsoft.AspNetCore.Authorization;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages.Party {
    //[Authorize]
    public class SpellsPage : PagedPage<SpellView, Spell, ISpellsRepo> {
        public SpellsPage(ISpellsRepo r) : base(r) { }
        protected override Spell ToObject(SpellView? item) => new SpellViewFactory().Create(item);
        protected override SpellView ToView(Spell? entity) => new SpellViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(SpellView.SpellName),
            nameof(SpellView.Description),
            nameof(SpellView.Type)
        };
    }
}
