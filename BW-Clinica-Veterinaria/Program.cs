using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurazione della connessione al database
var conn = builder.Configuration.GetConnectionString("CON")!;
builder.Services
    .AddDbContext<DataContext>(opt => opt.UseSqlServer(conn));

// Aggiungere il servizio di autenticazione basata sui cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Utente/Login";
    });

// Registrazione del servizio HTTP context accessor
builder.Services.AddHttpContextAccessor();

// Registrazione del servizio UtenteService
builder.Services.AddScoped<IUtenteService, UtenteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Abilitare l'autenticazione e l'autorizzazione
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
