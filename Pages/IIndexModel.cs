using WizardingWorld.Facade.Party;

namespace WizardingWorld.Pages {
    public interface IIndexModel<TView> where TView: BaseView{
        public string[] IndexColumns { get; }
        public IList<TView>? Items { get; set; }
        public object? GetValue(string name, TView v);
        string? DisplayName(string name);
    }
}