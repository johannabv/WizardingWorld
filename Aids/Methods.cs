﻿using System.Reflection;

namespace WizardingWorld.Aids
{
    public static class Methods
    {
        public static bool HasAttribute<TAttribute>(this MethodInfo? m) where TAttribute : Attribute
            => Safe.Run(() => m?.GetCustomAttributes<TAttribute>()?.FirstOrDefault() is not null, false);
    }
}
