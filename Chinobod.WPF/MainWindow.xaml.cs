using System.Windows;
using System.Windows.Input;
using Chinobod.WPF.Models.News;
using Chinobod.WPF.Services.Foundations.Newses;

namespace Chinobod.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INewsService newsService;
        private IQueryable<News> news;

        public MainWindow(INewsService newsService)
        {
            InitializeComponent();
            DataContext = this;
            this.newsService = newsService;
            news = this.newsService.RetrieveAllNewses();
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
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newsesList.ItemsSource = news;
        }
    }
}