using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using OnlineMuhasebeServer.Persistance.Context;
using OnlineMuhasebeServer.WebAPI.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);

builder.Services.AddScoped<CompanyDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using(var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser
        {
            UserName = "tsaydam",
            Email = "tanersaydam@gmail.com",
            Id = Guid.NewGuid().ToString(),
            FirstNameLastName = "Taner Saydam"
        }, "Password123*").Wait();
    }
}

app.Run();
