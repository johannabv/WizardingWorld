using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WizardingWorld.Aids;
using WizardingWorld.Data.Party;

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

        [DataRow(-1000L, 1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(0L, 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [DataRow(1000L, -1000L)]
        [TestMethod] public void Int64Test(long min, long max) => Test<long>(min, max);

        [DataRow(-1000.0, 1000.0)] 
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1000.0, -1000.0)]
        [TestMethod] public void DoubleTest(double min, double max) => Test<double>(min,max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('0', '9')]
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

        [DynamicData(nameof(DateTimeValues), DynamicDataSourceType.Method)]
        [TestMethod] public void DateTimeTest(DateTime min, DateTime max) => Test<DateTime>(min, max);
        private static IEnumerable<object[]> DateTimeValues() => new List<object[]>() {
            new object[]{DateTime.Now.AddYears(-100),DateTime.Now.AddYears(100)},
            new object[]{DateTime.Now.AddYears(100),DateTime.Now.AddYears(-100)},
            new object[]{DateTime.MaxValue.AddYears(-100), DateTime.MaxValue},
            new object[]{DateTime.MinValue, DateTime.MinValue.AddYears(100)}
        };

        [TestMethod] public void StringTest() {
            var x = GetRandom.Value<string>();
            var y = GetRandom.Value<string>();
            IsInstanceofType(x, typeof(string));
            IsInstanceofType(y, typeof(string));
            AreNotEqual(x, y);
        }

        [TestMethod] public void ValueTest() {
            var x = GetRandom.Value<SpellData>() as SpellData;
            var y = GetRandom.Value<SpellData>() as SpellData;
            AreNotEqual(x.ID, y.ID, nameof(x.ID));
            AreNotEqual(x.SpellName, y.SpellName, nameof(x.SpellName));
            AreNotEqual(x.Description, y.Description, nameof(x.Description));
            AreNotEqual(x.Type, y.Type, nameof(x.Type));
        }
    }
}
