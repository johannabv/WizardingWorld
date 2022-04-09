using WizardingWorld.Data;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain;

namespace WizardingWorld.Infra.Initializers {
    public sealed class CharacterAddressesInitializer : BaseInitializer<CharacterAddressData> {
        public CharacterAddressesInitializer(WizardingWorldDb? db) : base(db, db?.CharacterAddresses) { }
        internal static CharacterAddressData CreateCharacterAddresses(string characterId, string placeId, string code, string? name = null, string? description = null) {
            var obj = new CharacterAddressData {
                ID = BaseData.NewId,
                CharacterID = characterId,
                AddressID = placeId,
                Code = code ?? BaseEntity.DefaultStr,
                Description = description
            };
            return obj;
        }
        protected override IEnumerable<CharacterAddressData> GetEntities => new[] {
            CreateCharacterAddresses("test", "test", "test"),
        };
    }
}