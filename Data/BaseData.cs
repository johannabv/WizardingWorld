namespace WizardingWorld.Data {
    public abstract class BaseData {
        public static string NewId => Guid.NewGuid().ToString();
        public string ID { get; set; } = NewId;
    }
}
