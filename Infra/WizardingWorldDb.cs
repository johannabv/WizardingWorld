using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra {
    public sealed class WizardingWorldDb : DbContext {
        public WizardingWorldDb(DbContextOptions<WizardingWorldDb> options) : base(options) { }
        public DbSet<CharacterData>? Characters { get; set; }
        public DbSet<SpellData>? Spells { get; set; }
        public DbSet<CountryData>? Countries { get; set; }
        public DbSet<HouseData>? Houses { get; set; }
        public DbSet<AddressData>? Addresses { get; set; }
        public DbSet<CharacterAddressData>? CharacterAddresses { get; set; }
        public DbSet<WandData>? Wands { get; set; }
        public DbSet<WoodData>? Woods { get; set; }
        public DbSet<CoreMaterialData>? Cores { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            string s = nameof(WizardingWorldDb)[0..^2];
            _ = (b?.Entity<CharacterData>()?.ToTable(nameof(Characters), s));
            _ = (b?.Entity<SpellData>()?.ToTable(nameof(Spells), s));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            _ = (b?.Entity<HouseData>()?.ToTable(nameof(Houses), s));
            _ = (b?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
            _ = (b?.Entity<CharacterAddressData>()?.ToTable(nameof(CharacterAddresses), s));
            _ = (b?.Entity<WandData>()?.ToTable(nameof(Wands), s));
            _ = (b?.Entity<WoodData>()?.ToTable(nameof(Woods), s));
            _ = (b?.Entity<CoreMaterialData>()?.ToTable(nameof(Cores), s));
        }
    }
}
