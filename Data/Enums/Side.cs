using System.ComponentModel;

namespace WizardingWorld.Data.Enums {
    public enum Side {
        [Description("Not known")] NotKnown = 0,
        [Description("Order of the Phoenix")] OoP = 1,
        [Description("Deatheaters")] DeathEaters = 2,
        [Description("Dumbledore's Army")] DA = 3,
    }
}
