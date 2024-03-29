﻿namespace WizardingWorld.Aids {
    public static class Strings {
        public static string? Remove(this string? fromString, string theString)
            => Safe.Run(() => fromString?.Replace(theString, string.Empty), string.Empty);
        public static bool IsTypeName(this string? s)
            => Safe.Run(() => s?.All(x => x.IsNameChar()) ?? false);
        public static bool IsTypeFullName(this string? s)
            => Safe.Run(() => s?.All(x => x.IsFullNameChar()) ?? false);
        public static string RemoveTail(this string? s, char separator = '.') {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            for (int i = s.Length; i > 0; i--) {
                char c = s[i - 1];
                s = s[..(i - 1)];
                if (c == separator) return s;
            }
            return s;
        }
        public static string RemoveHead(this string? s, char separator = '.') {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            for (int i = 0; i < s.Length;) {
                char c = s[i];
                s = s[1..];
                if (c == separator) return s;
            }
            return s;
        }
    }
}
