//using System;
//using ArquitecturaG1.DAO;
//using ArquitecturaG1.Models.DTO;

//namespace ArquitecturaG1
//{
//    internal static class Program
//    {
//        static void Main()
//        {
//            //Prueba de extracción de datos por consola
//            //IdiomasDao IdiomasDao = new IdiomasDao();
//            //List<IdiomasDto> ListaIdiomas = IdiomasDao.VerIdiomas("Spanish");
//            //Console.WriteLine(ListaIdiomas[2].CountryCode.ToString());
//            PaisesDao paisesDao = new PaisesDao();
//            List<PaisesDto> ListaPaises = paisesDao.VerPaises("Spain");
//            Console.WriteLine(ListaPaises[0].Name.ToString());
//        }
//    }
//}

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
