using EcommerceWeb.Mvc;
using EcommerceWeb.Mvc.Services.Middleware;
using Microsoft.AspNetCore.Rewrite;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddAuthenticationConfiguration()
   .AddHttpContextAccessor();
builder.Services
  .AddApiClientConfiguration(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    var options = new RewriteOptions()
        .AddRedirect("old-url", "new-url", (int)HttpStatusCode.MovedPermanently);

    app.UseRewriter(options);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseTokenMiddleware();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "productDetails",
    pattern: "Products/{productId}",
    defaults: new { controller = "Product", action = "Details" });


app.Run();
