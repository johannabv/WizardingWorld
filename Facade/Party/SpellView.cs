﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class SpellViewFactory : BaseViewFactory<SpellView, Spell, SpellData> {
        protected override Spell toEntity(SpellData d) => new(d);
    }
    public class SpellView : BaseView{
        [DisplayName("Name of spell"), Required] public string? SpellName { get; set; }
        [DisplayName("Description"), Required] public string? Description { get; set; }
        [DisplayName("Type")] public string? Type { get; set; }
        [DisplayName("Full info")] public string? FullInfo { get; set; }
    }
}