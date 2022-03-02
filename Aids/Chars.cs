namespace WizardingWorld.Aids
{
    static class Chars { 
        public static bool IsNameChar(this char x) => char.IsLetterOrDigit(x) || x == '_' || x == '.'; 
    }
}
