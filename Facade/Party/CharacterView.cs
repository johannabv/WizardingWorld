using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CharacterViewFactory : BaseViewFactory<CharacterView, Character, CharacterData> {
        protected override Character ToEntity(CharacterData d) => new(d);
        public override CharacterView Create(Character? e) {
            CharacterView v = base.Create(e);
            v.FullName=e?.ToString();
            v.Gender=e?.Gender;
            v.Organization=e?.Organization;
            return v;
        }
        public override Character Create(CharacterView? v) {
            v ??= new CharacterView();
            v.Gender ??= IsoGender.NotApplicable;
            v.Organization ??= Side.NotKnown;
            return base.Create(v);
        }
    }
    public sealed class CharacterView : BaseView{
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name"), Required] public string? LastName { get; set; }
        [DisplayName("Gender"), Required] public IsoGender? Gender { get; set; }
        [DisplayName("Date of Birth")] public DateTime? DoB { get; set; }
        [DisplayName("Hogwartz House")] public string? HogwartsHouse { get; set; }
        [DisplayName("Organization")] public Side? Organization { get; set; }
        [DisplayName("Full info")] public string? FullName { get; set; }
    }
}
