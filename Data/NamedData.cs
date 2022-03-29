namespace WizardingWorld.Data {
    public class NamedData : BaseData {
        public string Code { get; set; } = String.Empty;
        public string? EnglishName { get; set; }
        public string? NativeName { get; set; }
    }
}
