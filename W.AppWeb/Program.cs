using W.DAL;
using W.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // A�ade soporte para controladores MVC

// Configuraci�n de la base de datos
builder.Services.AddDbContext<PersonaWDBContext>(options =>
{
    var conexionString = builder.Configuration.GetConnectionString("conn");
    options.UseMySql(conexionString, ServerVersion.AutoDetect(conexionString));
});

// Registra tus servicios personalizados
builder.Services.AddScoped<PersonaWDAL>();
builder.Services.AddScoped<PersonaWBL>();

// A�ade los servicios de autorizaci�n (requerido para UseAuthorization)
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANTE: El orden de estos middlewares es crucial
app.UseAuthorization(); // Ahora funcionar� porque los servicios est�n registrados

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
