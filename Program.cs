using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using _2026_sistem_peminjaman_ruangan_backend.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("BolehkanReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Alamat React kamu
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// 1. Tambahkan layanan Controller dan Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Setting Database
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Konfigurasi HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("BolehkanReact");
app.UseAuthorization();

// 4. Map Controllers (PENTING)
app.MapControllers();

app.Run();