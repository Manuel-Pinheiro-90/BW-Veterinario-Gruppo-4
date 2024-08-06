using BW_Clinica_Veterinaria.Context;
using BW_Clinica_Veterinaria.Interface;
using BW_Clinica_Veterinaria.Service;
using Microsoft.EntityFrameworkCore;
using BW_Clinica_Veterinaria.Interface;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProprietarioService, ProprietarioService>();

builder.Services
    .AddScoped<IAnimalService, AnimalService>()
    ;

var conn = builder.Configuration.GetConnectionString("CON")!;
builder.Services
    .AddDbContext<DataContext>(opt => opt.UseSqlServer(conn))
    ;

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
