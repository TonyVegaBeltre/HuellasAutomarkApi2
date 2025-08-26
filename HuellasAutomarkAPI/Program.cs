using HuellasAutomarkAPI.Application.Services;
using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Application.ApplicationInjection;
using HuellasAutomarkAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// DbContext Configuration
builder.Services.AddDbContext<HuellasAutomarkDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers().AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped(typeof(IGeneric<>), typeof(GenericService<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddInfrastructureServices();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Huellas Automark API",
        Version = "v1",
        Description = "API para gestión de estudiantes con huellas automark"
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Huellas Automark v1");
    c.RoutePrefix = ""; // Set Swagger UI at the app's root);
});
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
//app.UseAuthorization();
//app./*MapStaticAssets*/();
//app.MapRazorPages()
//   .WithStaticAssets();

app.Run();
