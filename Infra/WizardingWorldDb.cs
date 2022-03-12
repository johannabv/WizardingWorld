using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Infra {
    public sealed class WizardingWorldDb : DbContext {
        public WizardingWorldDb(DbContextOptions<WizardingWorldDb> options) : base(options) { }
        public DbSet<CharacterData>? Characters { get; set; }
        //public DbSet<AddressData>? Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        public static void InitializeTables(ModelBuilder b) {
            var s = nameof(WizardingWorldDb)[0..^2];
            _ = (b?.Entity<CharacterData>()?.ToTable(nameof(Characters), s));
            //_ = (b?.Entity<AddressData>()?.ToTable(nameof(Addresses), s));
        }
    }
}
