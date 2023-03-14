using Microsoft.Extensions.DependencyInjection;
using UrunSatisTeslimatSistemi.Extensions;

namespace UrunSatisTeslimatSistemi
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            ServiceCollection services = new();

            services.AddServicesDI();
            services.CreateProvider();

            //// To customize application configuration such as set high DPI settings or default font,
            //// see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();

            //var builder = new HostBuilder()
            //   .ConfigureServices((hostContext, services) =>
            //   {
            //       services.AddScoped<Form1>();
            //       services.AddServicesDI();

            //       services.AddDbContext<DatabaseContext>();
            //       //services.AddDbContext<DatabaseContext>( options =>
            //       //{
            //       //    options.UseSqlServer("name = connectionStrings:con");

            //       //});



            //   });

            //var host = builder.Build();




            Application.Run(new Form1());

        }







    }
}