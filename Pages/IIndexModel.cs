using WizardingWorld.Facade;

namespace WizardingWorld.Pages {
    public interface IIndexModel<TView> where TView: BaseView{
        public string[] IndexColumns { get; }
        public string[] IndexColumnsRelatedTable { get; }
        public IList<TView>? Items { get; set; }
        object? GetValue(string name, TView v);
        string? DisplayName(string name);
    }
}