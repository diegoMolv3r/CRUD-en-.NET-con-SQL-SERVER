using RegistroDeTickets.Data.Entidades; 
using RegistroDeTickets.Service;
using Microsoft.EntityFrameworkCore;
using RegistroDeTickets.Repository;
using DotNetEnv;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

var googleClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
var googleClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");
var connectionString = Environment.GetEnvironmentVariable("BASE_DE_DATOS");

builder.Services.AddDbContext<RegistroDeTicketsPw3Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Este bloque de codigo es donde se desactiva el Debug en produccion punto 6.1 del TP
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Es bueno mantener la p�gina de desarrollador para el modo de desarrollo
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection(); // Implementar Https Redirection punto 6.3 del TP
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Inicio}/{id?}")
    .WithStaticAssets();

app.MapControllers();

app.Run();