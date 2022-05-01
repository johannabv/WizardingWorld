using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;
using WizardingWorld.Tests.Facade.Party;

namespace Tests.Facade.Party {
    [TestClass] public class WandViewFactoryTests
        : ViewFactoryTests<WandViewFactory, WandView, Wand, WandData> {
        protected override Wand ToObject(WandData d) => new(d);
    }
}
