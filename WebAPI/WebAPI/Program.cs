
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("http://localhost:4110")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddSingleton<WebAPI.Services.MemoryRepository>();
            builder.Services.AddSingleton<WebAPI.Interfaces.GetDataInterface>(sp => sp.GetRequiredService<WebAPI.Services.MemoryRepository>());
            builder.Services.AddSingleton<WebAPI.Interfaces.FormSubmitInterface>(sp => sp.GetRequiredService<WebAPI.Services.MemoryRepository>());

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
