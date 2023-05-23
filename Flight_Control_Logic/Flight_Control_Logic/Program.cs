using Flight_Control_Logic.BLogic;
using Flight_Control_Logic.SignalR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<RouteProvider>();
builder.Services.AddSingleton<FlightControl>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(o =>
o.AddDefaultPolicy(o =>
o.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:3002")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapHub<AirportHub>("/airport");

app.Run();