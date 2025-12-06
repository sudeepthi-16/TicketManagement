
//without swagger

//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//var builder = WebApplication.CreateBuilder(args);

////cors
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAngular",
//        policy => policy.WithOrigins("http://localhost:4200")
//                        .AllowAnyHeader()
//                        .AllowAnyMethod());
//});

//builder.Services.AddControllers();

//var app = builder.Build();

//app.UseCors("AllowAngular");

//app.MapControllers();

//app.Run();

//with swagger

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS for Angular Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngular");
app.MapControllers();
app.Run();
