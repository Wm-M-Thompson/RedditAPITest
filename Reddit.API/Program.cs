namespace ThompsonSolutions.Reddit.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunApp(ConfigureBuilder(args));
        }

        private static WebApplicationBuilder ConfigureBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                .AddJsonFile("appsettings.json")
                                .AddUserSecrets(typeof(Program).Assembly)
                                .Build();

            var builder = WebApplication.CreateBuilder(args);
            CompositionRoot.Compose(builder.Services, config);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        private static void RunApp(WebApplicationBuilder builder)
        {
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.MapControllers();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run();
        }
    }
}