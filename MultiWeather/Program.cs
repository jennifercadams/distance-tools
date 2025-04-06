using MultiWeather.Services.WeatherApiService;
using MultiWeather.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<WeatherApiCache>();

// Add CORS origin depending on environment
string[] origin = builder.Environment.IsDevelopment() ? 
    [ "http://localhost:5173" ] : 
    [ "https://jennifercadams.github.io", "https://multi-weather.onrender.com" ];
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins(origin);
        });
});

if (builder.Environment.IsDevelopment())
{
    // Load .env
    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotEnv.Load(dotenv); 

    // Add Swagger dependencies
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
