﻿namespace WizardingWorld.Aids
{
    public static class Lists {
        public static T? GetFirst<T>(this List<T>? list) => ((list is null) || (list.Count < 1)) ? default : list[0];
        public static int? Remove<T>(this List<T>? list, Predicate<T> match) => Safe.Run(() => list?.RemoveAll(match), -1);
        public static bool IsEmpty<T>(this List<T>? list) => Safe.Run(() => list?.Count == 0, true);
        public static bool ContainsItem<T>(this List<T>? list, Func<T, bool> match) 
            => Safe.Run(() => (list is not null) && list.SingleOrDefault(match) is not null);
    }
}
