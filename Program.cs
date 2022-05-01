using DemoSession_WebAPI.Converters;
using DigitalPhotoPrinting.Models;
using DigitalPhotoPrinting.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);
var connectionStrings = builder.Configuration["ConnectionStrings:DefaultConnection"];

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConverter());
});


builder.Services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionStrings));
builder.Services.AddScoped<AccountService, AccountServiceImpl>();
builder.Services.AddScoped<ImageService, ImageServiceImpl>();
builder.Services.AddScoped<AdminService, AdminServiceImpl>();

var app = builder.Build();
var env = app.Environment;

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
app.UseStaticFiles();

app.MapControllers();

if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials()
     );
}

//app.MapGet("/", () => "Hello World!");

app.Run();
