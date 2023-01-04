using GetIt.API;
using GetIt.Core.Logging;
using GetIt.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ServicesConfiguration.Configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGetItApp();
builder.Host.UseGetitLogger((context, services, configuration) =>
{
    Configuration.Configure(context, services, configuration);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapProductRoutes();
app.UseAuthorization();

app.MapControllers();
Initializer.InitDatabase(app);
app.Run();
