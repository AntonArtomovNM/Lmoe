using Lmoe.Host;
using SimpleInjector;
using Container = SimpleInjector.Container;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var container = new Container();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore();
});
container.Initialize(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.UseSimpleInjector(container);
container.Verify();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
