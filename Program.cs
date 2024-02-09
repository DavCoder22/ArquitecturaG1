using ArquitecturaG1.Models.AbstractFactory;
using ArquitecturaG1.Models.DAO;
using ArquitecturaG1.Models.DTO;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDatabaseFactory, SqlServerDatabaseFactory>();
builder.Services.AddScoped<IPaisesDao, PaisesDao>(); // Agrega el servicio de PaisesDao
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ArquitecturaG1.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});
// Configure antiforgery service with custom options if needed
builder.Services.AddAntiforgery(options => {
    options.HeaderName = "X-CSRF-TOKEN"; // Configura el nombre de la cabecera para el token antiforgery
    // Puedes configurar más opciones aquí si lo necesitas
});


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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
