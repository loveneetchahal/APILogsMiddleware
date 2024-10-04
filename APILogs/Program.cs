using APILogs.DbContexts;
using APILogs.Mappers;
using APILogs.Middlewares;
using APILogs.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

/*Options*/
builder.Services.AddOptions<RequestResponseLoggerOption>().Bind(builder.Configuration.GetSection("RequestResponseLogger")).ValidateDataAnnotations();

/*IOC*/
builder.Services.AddSingleton<IRequestResponseLogger, RequestResponseLogger>();
builder.Services.AddScoped<IRequestResponseLogModelCreator, RequestResponseLogModelCreator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*Middleware*/
app.UseMiddleware<RequestResponseLoggerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
