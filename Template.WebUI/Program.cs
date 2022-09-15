using Template.Infrastructure.Services;

DotNetEnv.Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.RegisterDbContext();
builder.RegisterAuthentication();
builder.RegisterCors();
builder.RegisterAppServices();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.ExecuteMigrations();
app.UseWebCors();
app.UseAuthentication();
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


// insercion de super admin si no hay usuarios registrados
 new CreacionSuperAdmin(builder.Configuration["Email"], builder.Configuration["Password"]);

Boolean autenticado = false;
if (!autenticado) 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
