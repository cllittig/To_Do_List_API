using ToDoList.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//configuração da conexão com o banco PostgresSQL


builder.Services.AddDbContext<ToDoListDbContext>(options =>
options.UseMySql("server=localhost;initial catalog=to_do_list;uid=root;pwd=32130708", ServerVersion.AutoDetect("server=localhost;initial catalog=to_do_list;uid=root;pwd=32130708")));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
