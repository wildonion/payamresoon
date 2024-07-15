using DotNetEnv;
using DotNetEnv.Configuration;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MassTransitConfig.ConfigureMassTransit(builder.Services, builder.Configuration);



var configuration = new ConfigurationBuilder()
    .AddDotNetEnv(".env", LoadOptions.TraversePath()) // Simply add the DotNetEnv configuration source!
    .Build();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();


app.MapControllers();

app.Run();
