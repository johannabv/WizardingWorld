using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CharacterAddressViewFactory : BaseViewFactory<CharacterAddressView, CharacterAddress, CharacterAddressData> {
        protected override CharacterAddress ToEntity(CharacterAddressData d) => new(d);
    }
    public class CharacterAddressView : NamedView { 
        [Required] [DisplayName("Character")] public string CharacterID { get; set; } = string.Empty;
        [Required] [DisplayName("Place")] public string PlaceID { get; set; } = string.Empty;
        [Required] [DisplayName("Use for")] public new string Code { get; set; } = string.Empty;
    }
}
