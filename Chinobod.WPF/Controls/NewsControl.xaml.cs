using System.Windows;
using System.Windows.Controls;
using Chinobod.WPF.Brokers.APIBroker;
using Chinobod.WPF.Services.Foundations.Newses;
using Chinobod.WPF.Windows.Newses;
using MaterialDesignThemes.Wpf;

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



        public DateTimeOffset NewsCreatedDate
        {
            get { return (DateTimeOffset)GetValue(NewsCreatedDateProperty); }
            set { SetValue(NewsCreatedDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewsCreatedDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewsCreatedDateProperty =
            DependencyProperty.Register("NewsCreatedDate", typeof(DateTimeOffset), typeof(NewsControl), new PropertyMetadata(default));



        public bool NewsShouldDelete
        {
            get { return (bool)GetValue(NewsShouldDeleteProperty); }
            set { SetValue(NewsShouldDeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NewsShouldDelete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NewsShouldDeleteProperty =
            DependencyProperty.Register("NewsShouldDelete", typeof(bool), typeof(NewsControl), new PropertyMetadata(true));



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

        private void UpdateNews_Click(object sender, RoutedEventArgs e)
        {
            var newsWindow = new NewsWindow(this.newsService);
            newsWindow.NewsId = NewsId;
            newsWindow.NewsTitle = NewsTitle;
            newsWindow.NewsDescription = NewsDescription;
            newsWindow.NewsCreatedDate = NewsCreatedDate;
            newsWindow.ShouldDelete = NewsShouldDelete;
            newsWindow.ShowDialog();
        }
    }
}
