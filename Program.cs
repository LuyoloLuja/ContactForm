using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get the environment variable (set in Dockerfile)
var sqliteDbPath = Environment.GetEnvironmentVariable("SQLITE_DB_PATH");

// Set default SQLite path for local development
if (string.IsNullOrEmpty(sqliteDbPath))
{
    sqliteDbPath = "Data Source=ContactFormDb.db"; // Local development
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register the database context - SQLite
builder.Services.AddDbContext<ContactFormDbContext>(options =>
    options.UseSqlite(sqliteDbPath));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS for production
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
