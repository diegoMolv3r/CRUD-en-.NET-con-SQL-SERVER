using RegistroDeTickets.Data.Entidades; 
using RegistroDeTickets.Service;
using Microsoft.EntityFrameworkCore;
using RegistroDeTickets.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RegistroDeTicketsPw3Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITicketService, TicketService>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Inicio}/{id?}")
    .WithStaticAssets();

app.MapControllers();

app.Run();
