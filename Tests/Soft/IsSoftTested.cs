using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace WizardingWorld.Tests.Soft {
    [TestClass] public class IsSoftTested : AssemblyTests{
        protected override void isAllTested() => IsInconclusive("Namespace has to be changed to \"WizardingWord.Soft\"");
    }
}