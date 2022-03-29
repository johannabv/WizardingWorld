namespace WizardingWorld.Infra {
    public abstract class BaseRepo {

    }
    public abstract class CrudRepo : BaseRepo { }
    public abstract class FilteredRepo : CrudRepo { }
    public abstract class OrderedRepo : FilteredRepo { }
    public abstract class PagedRepo : OrderedRepo { }
}
