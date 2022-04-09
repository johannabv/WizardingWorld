﻿namespace WizardingWorld.Infra.Initializers {
    public static class WizardingWorldDbInitializer {
        public static void Init(WizardingWorldDb? db) {
            new CharacterInitializer(db).Init();
            new SpellInitializer(db).Init();
            new CountriesInitializer(db).Init();
            new CurrenciesInitializer(db).Init();
            new HousesInitializer(db).Init();
            new PlaceInitializer(db).Init();
            new CountryCurrenciesInitializer(db).Init();
            new CharacterAddressesInitializer(db).Init();
        }
    }
}