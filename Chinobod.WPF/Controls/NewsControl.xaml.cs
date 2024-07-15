using System.Windows;
using System.Windows.Controls;
using Chinobod.WPF.Brokers.APIBroker;
using Chinobod.WPF.Services.Foundations.Newses;

namespace Chinobod.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        private readonly IApiBroker apiBroker;
        private readonly INewsService newsService;

        public NewsControl()
        {
            InitializeComponent();
            this.apiBroker = new ApiBroker();
            newsService = new NewsService(this.apiBroker);
        }

        public Guid NewsId
        {
            get { return (Guid)GetValue(NewsIdProperty); }
            set { SetValue(NewsIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewsId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewsIdProperty =
            DependencyProperty.Register("NewsId", typeof(Guid), typeof(NewsControl), new PropertyMetadata(Guid.Empty));

        public static readonly DependencyProperty NewsTitleProperty =
        DependencyProperty.Register("NewsTitle", typeof(string), typeof(NewsControl), new PropertyMetadata(string.Empty));

        public string NewsTitle
        {
            get { return (string)GetValue(NewsTitleProperty); }
            set { SetValue(NewsTitleProperty, value); }
        }

        public static readonly DependencyProperty NewsDescriptionProperty =
            DependencyProperty.Register("NewsDescription", typeof(string), typeof(NewsControl), new PropertyMetadata(string.Empty));

        public string NewsDescription
        {
            get { return (string)GetValue(NewsDescriptionProperty); }
            set { SetValue(NewsDescriptionProperty, value); }
        }

        private async void DeleteNews_Click(object sender, RoutedEventArgs e)
        {
            if(NewsId != Guid.Empty)
            {
                var respond = 
                    MessageBox.Show($"{NewsTitle}ni o'chirishni xoxlaysizmi?",
                    "O'chirish",MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (respond == MessageBoxResult.Yes)
                {
                    var news = await this.newsService.RemoveNewsAsync(NewsId);
                    var mainWindow = new MainWindow(this.newsService);
                    mainWindow.newsesList.Items.Remove(news);
                }

            }
        }
    }
}
