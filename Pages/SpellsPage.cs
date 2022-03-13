﻿using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public class SpellsPage : BasePage<SpellView, Spell, ISpellRepo> {
        public SpellsPage(ISpellRepo r) : base(r) { }
        protected override Spell ToObject(SpellView? item) => new SpellViewFactory().Create(item);
        protected override SpellView ToView(Spell? entity) => new SpellViewFactory().Create(entity);
    }
}
