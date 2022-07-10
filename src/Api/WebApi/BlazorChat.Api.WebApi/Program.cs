namespace BlazorChat.Api.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbConfiguration(builder.Configuration);
            builder.Services.RegisterServices();
            builder.Services.AddRegisterServices();

            builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .AddFluentValidation();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.ConfigureAuth(builder.Configuration);
            builder.Services.AddSwaggerGen();
            
            //CORS
            builder.Services.AddCors(c => c.AddPolicy("DefaultPolicy", build =>
            {
                build.AllowAnyHeader()
                    .AllowAnyMethod().AllowAnyOrigin();
            }));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.ConfigureExceptionHandling(app.Environment.IsDevelopment());
            app.UseCors("DefaultPolicy");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}