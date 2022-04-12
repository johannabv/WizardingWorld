using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data.Enums;

namespace WizardingWorld.Infra {
    public sealed class WizardingWorldDb : DbContext {
        public WizardingWorldDb(DbContextOptions<WizardingWorldDb> options) : base(options) { }
        public DbSet<CharacterData>? Characters { get; set; }
        public DbSet<SpellData>? Spells { get; set; }
        public DbSet<CountryData>? Countries { get; set; }
        public DbSet<CurrencyData>? Currencies { get; set; }
        public DbSet<HouseData>? Houses { get; set; }
        public DbSet<AddressData>? Addresses { get; set; }
        public DbSet<CountryCurrencyData>? CountryCurrencies { get; set; }
        public DbSet<CharacterAddressData>? CharacterAddresses { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            var s = nameof(WizardingWorldDb)[0..^2];
            _ = (b?.Entity<CharacterData>()?.ToTable(nameof(Characters), s));
            _ = (b?.Entity<SpellData>()?.ToTable(nameof(Spells), s));
            _ = (b?.Entity<CountryData>()?.ToTable(nameof(Countries), s));
            _ = (b?.Entity<CurrencyData>()?.ToTable(nameof(Currencies), s));
            _ = (b?.Entity<HouseData>()?.ToTable(nameof(Houses), s));
            _ = (b?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
            _ = (b?.Entity<CharacterAddressData>()?.ToTable(nameof(CharacterAddresses), s));
            _ = (b?.Entity<CountryCurrencyData>()?.ToTable(nameof(CountryCurrencies), s));
        }
    }
}
