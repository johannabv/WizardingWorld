﻿using System.Reflection;

namespace WizardingWorld.Aids {
    public static class Methods {
        public static bool HasAttribute<TAttribute>(this MemberInfo? m) where TAttribute : Attribute
            => m?.GetAttribute<TAttribute>() is not null;
        public static TAttribute? GetAttribute<TAttribute>(this MemberInfo? m) where TAttribute : Attribute
            => Safe.Run(() => m?.GetCustomAttributes<TAttribute>()?.FirstOrDefault());
    }
}
