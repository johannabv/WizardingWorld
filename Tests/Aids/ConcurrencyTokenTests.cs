using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WizardingWorld.Aids;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public class ConcurrencyTokenTests : TypeTests {
        [TestMethod] public void ToStrTest() {
            byte[] array = new byte[] {1, 2, 3};
            string actual = ConcurrencyToken.ToStr(array);
            string expected = "";
            foreach(byte item in array) expected += item.ToString();
            AreEqual(expected, actual);
        }
        [TestMethod] public void ToByteArrayTest() {
            string s = GetRandom.String();
            byte[] actual = ConcurrencyToken.ToByteArray(s);
            byte[] expected = Encoding.ASCII.GetBytes(s);
            for(int i = 0; i < expected.Length; i++) AreEqual(expected[i], actual[i]);
        }

    }
}
