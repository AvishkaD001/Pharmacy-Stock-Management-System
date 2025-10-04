var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Add session support
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Set session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// ✅ Fix: Ensure HttpContext.Session Works
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

// ✅ Fix: Ensure Authentication Runs Before Authorization (If Needed)
app.UseAuthentication();
app.UseAuthorization();

// ✅ Fix: Enable Session Middleware Correctly
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Supplier}/{action=Register}/{id?}");

app.Run();
