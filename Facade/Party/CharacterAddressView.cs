using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Enums;
using WizardingWorld.Domain.Party;

namespace WizardingWorld.Facade.Party {
    public sealed class CharacterAddressViewFactory : BaseViewFactory<CharacterAddressView, CharacterAddress, CharacterAddressData> {
        protected override CharacterAddress ToEntity(CharacterAddressData d) => new(d);
    }
    public class CharacterAddressView : BaseView { 
        [Required] [DisplayName("Character")] public string CharacterID { get; set; } = string.Empty;
        [Required] [DisplayName("Place")] public string AddressID { get; set; } = string.Empty;
        [DisplayName("Use for")] public AddressUse? UseFor { get; set; }
    }
}
