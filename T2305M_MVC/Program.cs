using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// connect db
string connectionString = "Data Source=localhost,1433;Database=T2305M;User Id=sa;Password=sa123456;TrustServerCertificate=true";
builder.Services.AddDbContext<T2305M_MVC.Entities.DataContext>(
    options=> options.UseSqlServer(connectionString)
    );
//end

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

// Chọn Action và controller nào là trang chủ
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Hello}/{id?}");

app.Run();

