using Microsoft.OpenApi.Models;
using WebApplication.Config;
var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args); ;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(s => { });
builder.Services.AddResponseCaching();

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddControllers();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Examen"); });

app.UseCors(corsPolicyBuilder =>
    corsPolicyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseResponseCaching();
app.Run();
