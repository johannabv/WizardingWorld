using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Soft {
    [TestClass] public class IsSoftTested : IsAssemblyTested{
        protected override void IsAllTestsDone() => IsInconclusive("Namespace has to be changed to \"WizardingWord.Soft\"");
    }
}
