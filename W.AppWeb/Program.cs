using W.DAL;
using W.BL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Añade soporte para controladores MVC

// Configuración de la base de datos
builder.Services.AddDbContext<PersonaWDBContext>(options =>
{
    var conexionString = builder.Configuration.GetConnectionString("conn");
    options.UseMySql(conexionString, ServerVersion.AutoDetect(conexionString));
});

// Registra tus servicios personalizados
builder.Services.AddScoped<PersonaWDAL>();
builder.Services.AddScoped<PersonaWBL>();

// Añade los servicios de autorización (requerido para UseAuthorization)
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
app.UseAuthorization(); // Ahora funcionará porque los servicios están registrados

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
