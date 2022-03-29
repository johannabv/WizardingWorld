namespace WizardingWorld.Data {
    public class EntityData {
        public static string NewId => Guid.NewGuid().ToString();
        public string ID { get; set; } = NewId;
    }
}
