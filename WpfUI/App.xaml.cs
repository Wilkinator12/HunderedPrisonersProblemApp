using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Windows;
using WpfUI.Contexts;
using WpfUI.Contexts.Abstractions;
using WpfUI.Data;
using WpfUI.ViewModels;
using WpfUI.Views;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        public static IMapper Mapper { get; private set; } = null!;

        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            // Configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();


            // Dependency Injection
            var services = new ServiceCollection();
            services.AddSingleton(config);

            services.AddHundredPrisonersProblemLibrary();
            services.AddAutoMapper(typeof(App));


            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();

            services.AddTransient<HeaderView>();
            services.AddTransient<HeaderViewModel>();

            services.AddTransient<NewSimulationView>();
            services.AddTransient<NewSimulationViewModel>();

            services.AddTransient<CompletedSimulationsView>();
            services.AddTransient<CompletedSimulationsViewModel>();

            services.AddTransient<SimulationInfoView>();
            services.AddTransient<SimulationInfoViewModel>();

            services.AddTransient<BoxSelectionInfoView>();
            services.AddTransient<BoxSelectionInfoViewModel>();


            services.AddSingleton<ISessionContext, SessionContext>();


            services.AddTransient<IUIDataAccess, UIDataAccess>();


            // Logging
            ConfigureLogging(config, services);


            ServiceProvider = services.BuildServiceProvider();


            // Mapping
            Mapper = ServiceProvider.GetService<IMapper>()!;


            ServiceProvider.GetService<MainWindow>()!.Show();
        }


        private void ConfigureLogging(IConfiguration config, IServiceCollection services)
        {
            string logFilePathName = "LogFilePath";
            var filePathName = config.GetValue<string>(logFilePathName);
            if (filePathName == null) throw new Exception($"Log file path not found for {logFilePathName}");



            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(filePathName, rollingInterval: RollingInterval.Month)
                .CreateLogger();

            services.AddSingleton<ILogger>(logger);

            services.AddLogging(builder =>
            {
                builder.AddSerilog(logger);
            });
        }
    }

}
