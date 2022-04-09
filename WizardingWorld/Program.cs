using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WizardingWorld.Data;
using WizardingWorld.Domain;
using WizardingWorld.Domain.Party;
using WizardingWorld.Infra;
using WizardingWorld.Infra.Initializers;
using WizardingWorld.Infra.Party;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("WizardingWorldContext");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<WizardingWorldDb>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddTransient<ICharacterRepo, CharacterRepo>();
builder.Services.AddTransient<ISpellRepo, SpellRepo>();
builder.Services.AddTransient<IHouseRepo, HouseRepo>();
builder.Services.AddTransient<ICountryRepo, CountryRepo>();
builder.Services.AddTransient<ICurrencyRepo, CurrencyRepo>();
builder.Services.AddTransient<IPlaceRepo, PlaceRepo>();
builder.Services.AddTransient<ICountryCurrencyRepo, CountryCurrencyRepo>();
builder.Services.AddTransient<ICharacterAddressRepo, CharacterAddressRepo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using(var scope = app.Services.CreateScope()) {
    GetRepo.SetService(app.Services);
    var db = scope.ServiceProvider.GetService<WizardingWorldDb>();
    db?.Database?.EnsureCreated();
    WizardingWorldDbInitializer.Init(db);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
