using WizardingWorld.Data.Enums;

namespace WizardingWorld.Data.Party {
    public sealed class CharacterAddressData : BaseData {
        public string CharacterId { get; set; } = string.Empty;
        public string AddressId { get; set; } = string.Empty;
        public AddressUse? UseFor { get; set; }
    }
}
