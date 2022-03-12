using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party
{
    public sealed class CharacterViewFactory : BaseViewFactory<CharacterView, Character, CharacterData> {
        protected override Character toEntity(CharacterData d) => new(d);
    }
    public class CharacterView : BaseView{
        [DisplayName("First name")] public string? FirstName { get; set; }
        [DisplayName("Last name"), Required] public string? LastName { get; set; }
        [Required] public bool? Gender { get; set; }
        [DisplayName("Date of Birth")] public DateTime? DoB { get; set; }
        [DisplayName("Hogwartz House"), Required] public string? HogwartsHouse { get; set; }
        [Required] public string? Organisation { get; set; }
        [DisplayName("Full name")] public string? FullName { get; set; }
    }
}
