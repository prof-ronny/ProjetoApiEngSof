using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using ProjetoApiEngSof.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EngSofContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EngSofContext") ?? throw new InvalidOperationException("Connection string 'EngSofContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Uploads"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
