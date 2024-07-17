using Microsoft.OpenApi.Models;
using Infrastructure;
using Application;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});
var services = builder.Services;
services.AddMvc();
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clean-SampleApis", Version = "v1", });
});
services.AddInfrastructre(builder.Configuration);
services.AddApplication();

var app = builder.Build();
app.MapControllers();
app.UseHttpsRedirection();
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clean-SampleApis v1");
    c.RoutePrefix = "";
}
);
app.UseCors(policyName);
app.Run();