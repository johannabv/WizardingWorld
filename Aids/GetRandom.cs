
namespace WizardingWorld.Aids {
    public class GetRandom {
        private static void PutMinFirst<T>(ref T min, ref T max) where T : IComparable<T> {
            if (min.CompareTo(max) < 0) return;
            var v = min;
            min = max;
            max = v;
        }
        public static int Int32(int? min = null, int? max = null) {
            var minValue = min ?? -1000;
            var maxValue = max ?? 1000;
            PutMinFirst(ref minValue, ref maxValue);
            return Random.Shared.Next(minValue, maxValue);
        }
        public static double Double(double? min = null, double? max = null) {
            var minValue = min ?? -1000.0;
            var maxValue = max ?? 1000.0;
            PutMinFirst(ref minValue, ref maxValue); 
            return minValue + Random.Shared.NextDouble() * (maxValue - minValue);
        }
        public static char Char(char min = char.MinValue, char max = char.MaxValue) => (char)Int32(min, max);
        public static bool Bool() => Int32() % 2 == 0;
        public static DateTime DateTime(ushort minYear = 1900, ushort maxYear = 2100)
        {
            var year = Int32(minYear, maxYear - 1);
            var day = Int32(1, 364);
            var seconds = Int32(1, 24 * 60 * 60);
            var d = new DateTime(year);
            d = d.AddDays(day).AddSeconds(seconds);
            return d;
        }
        public static string String(ushort minLength = 5, ushort maxLength = 30) {
            var s = string.Empty;
            var length = Int32(minLength, maxLength);
            for (var i = 0; i < length; i++) s += Char('a', 'z');
            return s;
        }
        public static dynamic Value<T>(T? min = default, T? max = default) {
            if (typeof(T) == typeof(bool) || typeof(T) == typeof(bool?)) return Bool();
            else if (typeof(T) == typeof(DateTime) || typeof(T) == typeof(DateTime?)) return DateTime();
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(double?)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
            else if (typeof(T) == typeof(char) || typeof(T) == typeof(char?)) return Char(Convert.ToChar(min), Convert.ToChar(max));
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(int?)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
            else return String();
        }
    }
}
