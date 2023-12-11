using PlayerControl.Api.Filters;
using PlayerControl.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add(typeof(GlobalExceptionFilter)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatorDependency();
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddRabbitMQDependency(builder.Configuration);

if (builder.Environment.IsEnvironment("Local"))
{
    builder.Configuration.AddUserSecrets<Program>();
}

var connectionString = builder.Configuration.GetConnectionString("DbPgConnection");
builder.Services.AddDatabaseDependency(connectionString);

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
