using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Aids;

namespace Tests.Aids {
    [TestClass] public class GetRandomTests : IsTypeTested {
        private void Test<T>(T min, T max) where T : IComparable<T>{
            var x = GetRandom.Value(min, max);
            var y = GetRandom.Value(min,max);
            IsInstanceofType(x, typeof(T));
            IsInstanceofType(y, typeof(T));
            IsTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            IsTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            AreNotEqual(x, y);
        }

        [DataRow(-1000, 1000)] 
        [DataRow(-1000, 0)]
        [DataRow(0, 1000)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [DataRow(1000, -1000)]
        [TestMethod] public void Int32Test(int min, int max) => Test<int>(min,max);

        [DataRow(-1000.0, 1000.0)] 
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1000.0, -1000.0)]
        [TestMethod] public void DoubleTest(double min, double max) => Test<double>(min,max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', '9')]
        [DataRow('0','L')]
        [TestMethod] public void CharTest(char min, char max) => Test<char>(min, max);
        [TestMethod] public void BoolTest() {
            var x = GetRandom.Bool();
            var y = GetRandom.Bool();
            var i = 0;
            while (x == y) {
                y = GetRandom.Bool();
                if (i == 5) AreNotEqual(x, y);
                i++;
            }
        }
        [TestMethod] public void DateTimeTest() => IsInconclusive();
        [TestMethod] public void StringTest() => IsInconclusive();
        [TestMethod] public void ValueTest() => IsInconclusive();
    }
}
