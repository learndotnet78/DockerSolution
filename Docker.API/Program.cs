using Docker.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
IConfiguration Configuration = new ConfigurationBuilder()
  .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
  .AddEnvironmentVariables()
  .AddCommandLine(args)
  .Build();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new GlobalExceptionFilter());
});
builder.Services.AddSingleton<IConfiguration>(Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", builder =>
    {
        builder.WithOrigins(["*"])
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//
app.UseSwagger();
app.UseSwaggerUI();
//}
app.UseCors("EnableCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
