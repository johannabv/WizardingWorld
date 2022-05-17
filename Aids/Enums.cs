using System.ComponentModel;
using System.Reflection;

namespace WizardingWorld.Aids {
    public static class Enums {
        public static string Description(this Enum v) {
            FieldInfo? i = v.GetType().GetField(v.ToString());
            DescriptionAttribute? a = i?.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return a?.Description ?? v.ToString();
        }
    }
}
