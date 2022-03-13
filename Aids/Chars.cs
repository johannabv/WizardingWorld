namespace WizardingWorld.Aids {
    public static class Chars { 
        public static bool IsNameChar(this char x) => char.IsLetterOrDigit(x);
        public static bool IsFullInfoChar(this char x) => IsNameChar(x) || x == '.';
    }
}
