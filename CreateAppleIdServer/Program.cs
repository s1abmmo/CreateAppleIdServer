using CreateAppleIdServer.BackgroundServices;
using CreateAppleIdServer.Models;
using CreateAppleIdServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<StoreDataModel>();
builder.Services.AddHostedService<MainBackgroundService>();
builder.Services.AddScoped<RegistrationInfomationService>();
builder.Services.AddScoped<PhonesService>();
builder.Services.AddTransient<FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0");
//app.Run();
