using AspNetCoreRateLimit;
using Protection_API.StartupConfig;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();

builder.Services.AddWatchDogServices();

builder.Services.AddMemoryCache();
builder.AddRateLimitServices();

var app = builder.Build();

app.UseWatchDogExceptionLogger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();

app.UseIpRateLimiting();

app.UseWatchDog(opts =>
{
    opts.WatchPageUsername = app.Configuration.GetValue<string>("WatchDog:UserName");
    opts.WatchPagePassword = app.Configuration.GetValue<string>("WatchDog:Password");
    opts.Blacklist = "health";
});

app.Run();
