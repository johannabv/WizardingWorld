namespace WizardingWorld.Infra.Initializers {
    public static class WizardingWorldDbInitializer {
        public static void Init(WizardingWorldDb? db) {
            new CharacterInitializer(db).Init();
            new SpellInitializer(db).Init();
            new HousesInitializer(db).Init();
            new AddressInitializer(db).Init();
            new WoodsInitializer(db).Init();
            new CoreMaterialsInitializer(db).Init();
        }
    }
}
