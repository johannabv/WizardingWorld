using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Data.Party;
using WizardingWorld.Domain.Party;
using WizardingWorld.Facade.Party;

namespace WizardingWorld.Tests.Facade.Party {
    [TestClass] public class WandViewFactoryTests
        : ViewFactoryTests<WandViewFactory, WandView, Wand, WandData> {
        protected override Wand ToObject(WandData d) => new(d);
    }
}
