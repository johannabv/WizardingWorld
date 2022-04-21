using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Soft {
    [TestClass] public class IsSoftTested : AssemblyTests{
        protected override void isAllTested() => IsInconclusive("Namespace has to be changed to \"WizardingWord.Soft\"");
    }
}
