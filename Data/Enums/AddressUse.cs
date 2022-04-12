using System.ComponentModel;

namespace WizardingWorld.Data.Enums {
    public enum AddressUse {
        [Description("Not known")] NotKnown = 0,
        [Description("School")] School = 1,
        [Description("Job")] Job = 2,
        [Description("Headquarters")] Headquarters = 3,
        [Description("Home")] Home = 4,
        [Description("Other")] Other = 5
    }
}
