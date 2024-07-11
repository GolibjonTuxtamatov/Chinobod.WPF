using System.Windows;
using Chinobod.WPF.Brokers.APIBroker;
using Chinobod.WPF.Services.Foundations.Newses;
using Microsoft.Extensions.DependencyInjection;

namespace Chinobod.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddTransient<IApiBroker, ApiBroker>();

            services.AddTransient<INewsService, NewsService>();
        }
    }

}