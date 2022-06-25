﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WizardingWorld.Aids;
using WizardingWorld.Data.Enums;
using WizardingWorld.Data.Party;

namespace WizardingWorld.Tests.Aids {
    [TestClass] public abstract class GetRandomTests : TypeTests {
        private void Test<T>(T min, T max) where T : IComparable<T> {
            dynamic? x = GetRandom.Value(min, max);
            dynamic? y = GetRandom.Value(min, max);
            int i = 0;
            while (x == y) {
                y = GetRandom.Value(min, max);
                if (i == 2) AreNotEqual(x, y);
                i++;
            }
            IsInstanceOfType(x, typeof(T));
            IsInstanceOfType(y, typeof(T));
            IsTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            IsTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            IsTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            AreNotEqual(x, y);
        }
        private static void Test<T>(Func<T> f, int count = 5) {
            T x = f();
            T y = f();
            int i = 0;
            while (x.Equals(y)) {
                y = f();
                if (i == count) AreNotEqual(x, y);
                i++;
            }
        }

        [DataRow(-1000, 1000)]
        [DataRow(-1000, 0)]
        [DataRow(0, 1000)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [DataRow(1000, -1000)]
        [TestMethod] public void Int32Test(int min, int max) => Test(min, max);

        [DataRow(-1000L, 1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(0L, 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [DataRow(1000L, -1000L)]
        [TestMethod] public void Int64Test(long min, long max) => Test(min, max);

        [DataRow(-1000.0, 1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(1000.0, -1000.0)]
        [TestMethod] public void DoubleTest(double min, double max) => Test(min, max);

        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', 'p')]
        [DataRow('A', 'z')]
        [TestMethod] public void CharTest(char min, char max) => Test(min, max);

        [TestMethod] public void BoolTest() => Test(() => GetRandom.Bool());

        [DynamicData(nameof(DateTimeValues), DynamicDataSourceType.Property)]
        [TestMethod] public void DateTimeTest(DateTime min, DateTime max) => Test(min, max);
        private static IEnumerable<object[]> DateTimeValues => new List<object[]>() {
                 new object[]{ DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100) },
                 new object[]{ DateTime.Now.AddYears(100), DateTime.Now.AddYears(-100) },
                 new object[]{ DateTime.MaxValue.AddYears(-100), DateTime.MaxValue },
                 new object[]{ DateTime.MinValue, DateTime.MinValue.AddYears(100) }
        };
        [TestMethod]  public void StringTest() {
            dynamic? x = GetRandom.Value<string>();
            dynamic? y = GetRandom.Value<string>();
            IsInstanceOfType(x, typeof(string));
            IsInstanceOfType(y, typeof(string));
            AreNotEqual(x, y);
        } 
        [TestMethod] public void ValueTest() {
            SpellData? x = GetRandom.Value<SpellData>() as SpellData;
            SpellData? y = GetRandom.Value<SpellData>() as SpellData;
            IsNotNull(x);
            IsNotNull(y);
            AreNotEqual(x.Id, y.Id, nameof(x.Id));
            AreNotEqual(x.SpellName, y.SpellName, nameof(x.SpellName));
            AreNotEqual(x.Description, y.Description, nameof(x.Description));
            AreNotEqual(x.Type, y.Type, nameof(x.Type));
        }
        [TestMethod] public void EnumOfGenericTest() => Test(() => GetRandom.EnumOf<IsoGender>());
        
        [DataRow(typeof(IsoGender))]
        [TestMethod] public void EnumOfTest(Type type) => Test(() => GetRandom.EnumOf(type));
        
        [DataRow(typeof(bool?), false)]
        [DataRow(typeof(int), false)]
        [DataRow(typeof(Side?), false)]
        [DataRow(typeof(DateTime?), false)]
        [DataRow(typeof(IsoGender), true)]
        [TestMethod] public void IsEnumTest(Type type, bool expected) => AreEqual(expected, GetRandom.IsEnum(type));

        [DataRow(typeof(bool?), typeof(bool))]
        [DataRow(typeof(int?), typeof(int))]
        [DataRow(typeof(double?), typeof(double))]
        [DataRow(typeof(DateTime?), typeof(DateTime))]
        [DataRow(typeof(IsoGender?), typeof(IsoGender))]
        [TestMethod] public void GetUnderlyingTypeTest(Type nullable, Type expected) => AreEqual(expected, GetRandom.GetUnderlyingType(nullable));
    }
}
