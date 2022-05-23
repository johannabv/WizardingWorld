using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Infra;

namespace WizardingWorld.Tests.Infra {
    [TestClass] public class WizardingWorldDbTests : SealedBaseTests<WizardingWorldDb, DbContext> {
        protected override WizardingWorldDb CreateObj() => null;
        protected override void isSealedTest() => IsTrue(typeof(WizardingWorldDb).IsSealed);
    }
}