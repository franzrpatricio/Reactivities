using Microsoft.EntityFrameworkCore;
using Persistence;

// START UP POINT FOR THE APPLICATION

var builder = WebApplication.CreateBuilder(args);

// WRITE SERVICES HERE
// Add services to the container.
// services = we use inside the application logic; gives more functionality to the logic 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// service to data context
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// WRITE PIPELINE HERE
// Configure the HTTP request pipeline.
// pipeline = middleware
// middleware = has to do something with http requests whether they go in or out
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// THIS REGISTERS THE ENDPOINTS W/ THE APPLICATION
// middleware to map controllers
app.MapControllers(); 

using var scope = app.Services.CreateScope();
// using keyword = if scope = done, all contents of scope will be disposed/destroyed/cleaned up from memory
// by using, "using" keyword, it automatically cleans up after itself when it's finished; like in a self-destruct mode
var services = scope.ServiceProvider;
try{
    var context = services.GetRequiredService<DataContext>(); // Will automatically create the DB if it does exist.
    await context.Database.MigrateAsync(); // asynchronously be applied any pending migrations for the context to DB.
    await Seeder.SeederData(context); //wait for seederdata context, then receive a notification <= DELEGATE 
}
catch (Exception ex){
    // LOG ERRORS OF PROGRAM CLASS
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"May error sa migrations pare. I-check mo.");
}

app.Run();
