﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CharacterViewFactory : BaseViewFactory<CharacterView, Character, CharacterData> {
        protected override Character ToEntity(CharacterData d) => new(d);
        public override CharacterView Create(Character? e) {
            var v = base.Create(e);
            v.FullName=e?.ToString();
            return v;
        }
    }
    public sealed class CharacterView : BaseView{
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name"), Required] public string? LastName { get; set; }
        [DisplayName("Gender"), Required] public IsoGender? Gender { get; set; }
        [DisplayName("Date of Birth")] public DateTime? DoB { get; set; }
        [DisplayName("Hogwartz House"), Required] public string? HogwartsHouse { get; set; }
        [DisplayName("Organisation"), Required] public string? Organisation { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
