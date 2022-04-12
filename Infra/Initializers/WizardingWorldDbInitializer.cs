namespace WizardingWorld.Infra.Initializers {
    public static class WizardingWorldDbInitializer {
        public static void Init(WizardingWorldDb? db) {
            new CharacterInitializer(db).Init();
            new SpellInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new HousesInitializer(db).Init();
            new AddressInitializer(db).Init();
            new CountryCurrenciesInitializer(db).Init();
            new WoodsInitializer(db).Init();
        }
    }
}
