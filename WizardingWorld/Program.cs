﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;
using WizardingWorld.Infra.Party;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("WizardingWorldContext");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<WizardingWorldDb>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICharactersRepo, CharactersRepo>();
builder.Services.AddTransient<ISpellsRepo, SpellsRepo>();
builder.Services.AddTransient<IHousesRepo, HousesRepo>();
builder.Services.AddTransient<ICountriesRepo, CountriesRepo>();
builder.Services.AddTransient<IAddressRepo, AddressesRepo>();
builder.Services.AddTransient<ICharacterAddressesRepo, CharacterAddressesRepo>();
builder.Services.AddTransient<IWandsRepo, WandsRepo>();
builder.Services.AddTransient<IWoodsRepo, WoodsRepo>();
builder.Services.AddTransient<ICoreMaterialsRepo, CoreMaterialsRepo>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    _ = app.UseMigrationsEndPoint();
}
else {
    _ = app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

using (IServiceScope scope = app.Services.CreateScope()) {
    GetRepo.SetService(app.Services);
    WizardingWorldDb? db = scope.ServiceProvider.GetService<WizardingWorldDb>();
    _ = (db?.Database?.EnsureCreated());
    WizardingWorldDbInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
