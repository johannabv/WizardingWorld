using WizardingWorld.Data.Enums;

namespace WizardingWorld.Data.Party {
    public sealed class CharacterData : BaseData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public IsoGender? Gender { get; set; }
        public DateTime? DoB { get; set; }
        public string? HogwartsHouse { get; set; }
        public Side? Organisation { get; set; }
    }
}
