using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Master.Data;

var builder = WebApplication.CreateBuilder(args);
var strConnection = builder.Configuration["StrConnection"];

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<MasterContext>(options => options.UseSqlServer(strConnection));
builder.Services.AddSwaggerGen(c => {c.SwaggerDoc("v1", new() { Title = "apinetcore", Version = "v1" });});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "apinetcore v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();