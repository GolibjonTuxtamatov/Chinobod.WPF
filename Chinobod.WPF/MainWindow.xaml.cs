using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;
using Chinobod.WPF.Controls;
using Chinobod.WPF.Models.News;
using Chinobod.WPF.Services.Foundations.Newses;
using Chinobod.WPF.Windows.Newses;

namespace Chinobod.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INewsService newsService;
        private IQueryable<News> news;
        private NewsWindow newsWindow;

        public MainWindow(INewsService newsService)
        {
            InitializeComponent();
            DataContext = this;
            this.newsService = newsService;
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;
        }

        private void NetworkChange_NetworkAddressChanged(object? sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (IsInternetAvailable())
                {
                    addNewsBtn.IsEnabled = true;
                    refreshNewsBtn.IsEnabled = true;
                    Window_Loaded(this, null);
                }
                else
                {
                    addNewsBtn.IsEnabled = false;
                    refreshNewsBtn.IsEnabled = false;
                    Window_Loaded(this, null);
                }
            });
        }

        private void MainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimized_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Closed_Click(object sender, RoutedEventArgs e)
        {
            if(newsWindow != null)
                newsWindow.Close();
            NetworkChange.NetworkAvailabilityChanged -= NetworkChange_NetworkAddressChanged;
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsInternetAvailable())
                {
                    news = this.newsService.RetrieveAllNewses();

                    newsesList.ItemsSource = news;
                }
            }
            catch
            {
                addNewsBtn.IsEnabled = false;
                refreshNewsBtn.IsEnabled = false;
                MessageBox.Show("Internet aloqasini tekshiring!");
            }
        }

        private void addNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            newsWindow = new NewsWindow(this.newsService);

            newsWindow.ShowDialog();
        }

        private void refreshNewsBtn_Click(object sender, RoutedEventArgs e) =>
            newsesList.ItemsSource = this.newsService.RetrieveAllNewses();

        private bool IsInternetAvailable()
        {
            try
            {
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus != OperationalStatus.Up)
                        continue;

                    if (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        networkInterface.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                    {
                        IPv4InterfaceStatistics statistics = networkInterface.GetIPv4Statistics();
                        if (statistics.BytesReceived > 0 && statistics.BytesSent > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                // Handle exceptions if necessary
            }
            return false;
        }
    }
}