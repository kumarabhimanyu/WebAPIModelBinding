using Microsoft.EntityFrameworkCore;
using MyFirstAPI;
using MyFirstAPI.Data;
using Newtonsoft.Json;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyFirstAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyFirstAPIContext") ?? 
    throw new InvalidOperationException("Connection string 'MyFirstAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("Hello", () => "Hello Abhimanyu");

app.MapGet("/todoitems", async (http) => {
    var todoItems = new List<ToDoItems>();
    
    todoItems.Add (new ToDoItems { Id = 1, Name="Write an Article", IsComplete = true });
    todoItems.Add(new ToDoItems { Id = 2, Name = "Submit Assignment", IsComplete = false });

    await http.Response.WriteAsJsonAsync(todoItems);
});

app.MapPost("/addtodo", async (ToDoItems item) => {
    var todoItems = new List<ToDoItems>();

    todoItems.Add(new ToDoItems { Id = item.Id, Name = item.Name, IsComplete = item.IsComplete });
    return Results.Ok(JsonConvert.SerializeObject(todoItems));
    
});


app.Run();
