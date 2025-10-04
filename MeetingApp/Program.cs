var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// {controller=Home}/{action=Index}/{id?}
// app.MapDefaultControllerRoute();

app.MapControllerRoute(         // yukardakiyle aynı
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
