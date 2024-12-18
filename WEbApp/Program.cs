using DefaultNamespace;
using Infrostructure.Models;
using Infrostructure.Response;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<DapperConText>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ISkillServer,SkillServer>();
builder.Services.AddScoped<IRequestService,RequestService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();
