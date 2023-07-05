
using Mwalimu_Hub_WebApi.Services;
using Mwalimu_Hub_WebApi.Services.AdminService;
using Mwalimu_Hub_WebApi.Services.TeacherService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(option => { option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseAuthorization();

app.MapControllers();

app.Run();
