using Api.Config;
using Data.Context;
using DevIO.Api.Configuration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.WebApiConfig();

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.ResolveDependencies();

builder.Services.AddDbContext<DataDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSwaggerConfig();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseMvcConfiguration();

app.MapControllers();

app.UseSwaggerConfig(apiVersionDescriptionProvider);

app.Run();
