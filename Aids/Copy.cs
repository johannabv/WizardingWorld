using System.Reflection;

namespace WizardingWorld.Aids {
    public static class Copy {
        public static void Properties(object? from, object? to) {
            Type? tFrom = from?.GetType();
            Type? tTo = to?.GetType();
            foreach (PropertyInfo piFrom in tFrom?.GetProperties() ?? Array.Empty<PropertyInfo>()) {
                object? v = piFrom.GetValue(from, null);
                PropertyInfo? piTo = tTo?.GetProperty(piFrom.Name);
                piTo?.SetValue(to, v, null);
            }
        }
    }
}
