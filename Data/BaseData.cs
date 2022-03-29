namespace WizardingWorld.Data {
    public class BaseData {
        public static string NewId => Guid.NewGuid().ToString();
        public string ID { get; set; } = NewId;
    }
}
