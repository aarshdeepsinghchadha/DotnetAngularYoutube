using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Options;
using YoutubeDevApiDotnet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configuration Settings
builder.Configuration.GetSection("YoutubeApiSettings").Bind(builder.Configuration);
builder.Services.Configure<YoutubeApiSettings>(builder.Configuration.GetSection("YoutubeApiSettings"));

// Register the YouTubeService
builder.Services.AddScoped(provider =>
{
    var youtubeApiSettings = builder.Services.BuildServiceProvider().GetService<IOptions<YoutubeApiSettings>>().Value;
    return new YouTubeService(new BaseClientService.Initializer
    {
        ApiKey = youtubeApiSettings?.ApiKey,
        ApplicationName = "MyYoutubeAPI"
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add CORS configuration to allow requests from Angular app
app.UseCors(builder => builder
    .WithOrigins("http://localhost:4200") // Allow requests from Angular app running on localhost
    .AllowAnyHeader()
    .AllowAnyMethod()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
