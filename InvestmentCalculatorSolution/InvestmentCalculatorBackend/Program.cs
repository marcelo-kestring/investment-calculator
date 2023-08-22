var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    //options.AddDefaultPolicy(
    //    policy =>
    //    {
    //        policy.WithOrigins("https://localhost:4200",
    //                           "http://localhost:4200");
    //    });
    options.AddPolicy("AllowAnyOrigin", builderOrigin =>
    {
        builderOrigin.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});


// Add services to the container.

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

app.UseCors("AllowAnyOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
