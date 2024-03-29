﻿namespace WizardingWorld.Data.Party {
    public sealed class AddressData : BaseData {
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? ZipCode { get; set; }
        public string? CountryId { get; set; }
        public string? Description { get; set; }
    }
}
