using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;
using WizardingWorld.Facade;

namespace WizardingWorld.Tests.Facade {
    [TestClass] public class IsoNamedViewTests : AbstractClassTests<IsoNamedView, NamedView> {
        private class TestClass : IsoNamedView { }
        protected override IsoNamedView CreateObj() => new TestClass();
        [TestMethod] public void CodeTest() => IsRequired<string>("ISO three-letter code");
        [TestMethod] public void NameTest() => IsDisplayNamed<string>("English name");
        [TestMethod] public void DescriptionTest() => IsDisplayNamed<string>("Native name");
    }
}
