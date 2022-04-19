using WizardingWorld.Data.Enums;

namespace WizardingWorld.Data.Party {
    public sealed class CharacterAddressData : BaseData {
        public string CharacterID { get; set; } = string.Empty;
        public string AddressID { get; set; } = string.Empty;
        public AddressUse? UseFor { get; set; }
    }
}
