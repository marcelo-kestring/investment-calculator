using InvestmentCalculatorBackend.Business;
using System.Diagnostics.CodeAnalysis;

namespace Principal
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
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

            builder.Services.AddScoped<IRendimentoService, RendimentoService>();
            builder.Services.AddScoped<IRendimentoLiquidoService, RendimentoLiquidoService>();

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
        }

    }
}