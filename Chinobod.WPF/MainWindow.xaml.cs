using System.Windows;
using System.Windows.Input;
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
            if(newsWindow != null)
                newsWindow.Close();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            newsesList.ItemsSource = news;
        }

        private void addNewsBtn_Click(object sender, RoutedEventArgs e)
        {
            newsWindow = new NewsWindow(this.newsService);

            newsWindow.ShowDialog();
        }

        private void refreshNewsBtn_Click(object sender, RoutedEventArgs e) =>
            newsesList.ItemsSource = this.newsService.RetrieveAllNewses();
    }
}