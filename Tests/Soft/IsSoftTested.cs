using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Soft {
    [TestClass] public class IsSoftTested : IsAssemblyTested{
        protected override void AreAllThingsTested() => IsInconclusive("Namespace has to be changed to \"WizardingWord.Soft\"");
    }
}
