using DefaultNamespace;
using Infrostructure.Models;
using Infrostructure.Response;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<DapperConText>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ISkillServer,SkillServer>();
builder.Services.AddScoped<IRequestService,RequestService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "WebAPI1"));
}

app.UseCors();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();



