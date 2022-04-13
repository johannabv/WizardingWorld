namespace WizardingWorld.Data {
    public abstract class NamedData : BaseData {
        public string Code { get; set; } = String.Empty;
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
