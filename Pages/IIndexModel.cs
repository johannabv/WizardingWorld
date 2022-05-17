using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public interface IIndexModel<TView> where TView: BaseView{
        public string[] IndexColumns { get; }
        public string[] RelatedIndexColumns { get; }
        public IList<TView>? Items { get; set; }
        object? GetValue(string name, TView v);
        object? GetValue<T>(string name, T item);
        string? DisplayName(string name);
        string? GetDisplayName<T>(string propertyName);
    }
}