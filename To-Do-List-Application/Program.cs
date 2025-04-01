using Microsoft.EntityFrameworkCore;
using ToDoList.Model;
using ToDoList.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoListContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("ToDoList")));
builder.Services.AddControllers();
// add cors policy
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services
builder.Services.AddScoped<ToDoListContext, ToDoListContext>();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

//use cors
app.UseCors("CorsPolicy");

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
