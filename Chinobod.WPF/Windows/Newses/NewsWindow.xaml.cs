using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chinobod.WPF.Models.News;
using Chinobod.WPF.Services.Foundations.Newses;

namespace Chinobod.WPF.Windows.Newses
{
    /// <summary>
    /// Interaction logic for NewsWindow.xaml
    /// </summary>
    public partial class NewsWindow : Window
    {
        private readonly INewsService newsService;
        public NewsWindow(INewsService newsService)
        {
            InitializeComponent();
            this.newsService = newsService;
        }



        private string title;

        public string NewsTitle
        {
            get { return title; }
            set { title = value; }
        }


        private string description;

        public string NewsDescription
        {
            get { return description; }
            set { description = value; }
        }

        private bool shouldDelete = true;

        public bool ShouldDelete
        {
            get { return shouldDelete; }
            set { shouldDelete = value; }
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NewsTitle) && !string.IsNullOrEmpty(NewsDescription))
            {
                var news = new News
                {
                    Id = Guid.NewGuid(),
                    Title = NewsTitle,
                    Description = NewsDescription,
                    CreatedDate = DateTimeOffset.Now,
                    ShouldDelete = this.ShouldDelete
                };

                var postedNews = await this.newsService.AddNewsAsync(news);

                if (postedNews != null)
                    MessageBox.Show("Saqlandi!", "Qo'shish", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Nimadur xato boldi!", "Qo'shish", MessageBoxButton.OK, MessageBoxImage.Error);

                this.Close();
            }
            else
            {
                MessageBox.Show("Sarlavha va Tasvirlash yozilsin!", "Xato", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
