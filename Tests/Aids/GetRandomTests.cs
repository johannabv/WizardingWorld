using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WizardingWorld.Aids;

namespace Tests.Aids {
    [TestClass] public class GetRandomTests : IsTypeTested {
        private void TestForNumbers<T>(T min, T max) where T : IComparable<T>{
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
        [TestMethod] public void Int32Test(int min, int max) => TestForNumbers<int>(min,max);

        [DataRow(-1000.0, 1000.0)] 
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1000.0, -1000.0)]
        [TestMethod] public void DoubleTest(double min, double max) => TestForNumbers<double>(min,max);
        
        [TestMethod] public void CharTest() => IsInconclusive();
        [TestMethod] public void BoolTest() => IsInconclusive();
        [TestMethod] public void DateTimeTest() => IsInconclusive();
        [TestMethod] public void StringTest() => IsInconclusive();
        [TestMethod] public void ValueTest() => IsInconclusive();
    }
}
