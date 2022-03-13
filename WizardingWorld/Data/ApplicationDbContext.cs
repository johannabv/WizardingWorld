using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WizardingWorld.Infra;

namespace WizardingWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }
        private static void InitializeTables(ModelBuilder b) {
            WizardingWorldDb.InitializeTables(b);
        }
    }
}
