using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//autofac yapýsýný burada kurduk...
// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

//IHostBuilder hostBuilder = builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());


// Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


builder.Services.AddControllers();
builder.Services.AddCors();// Güvenlik amaçlý bir yer. Baþka yerden istek gelirse kabul etme demek udemy videosunda var
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,// issuer i kontrol et. doðrulayayým mý
            ValidateAudience = true, // audience yi de kontrol et
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

builder.Services.AddDependencyResolvers(new ICoreModule[] {new CoreModule()});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IStudentService, StudentManager>();
//builder.Services.AddSingleton<IStudentDal, EfStudentDal>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}

app.ConfigureCustomExceptionMiddleware(); // try cache kontrolü yapýyoruz.

app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyOrigin());

app.UseCors(builder => builder.WithOrigins("https://webapitoki.azurewebsites.net").AllowAnyHeader().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();// Eve girmek için anahtar - Sýrasý önemli

app.UseAuthorization();// Evde ne yapýlabilir yetkileri-Mutfaða girebilirsin gibi

app.MapControllers();

app.Run();
