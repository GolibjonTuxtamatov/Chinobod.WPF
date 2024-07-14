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

namespace Chinobod.WPF.Windows.Newses
{
    /// <summary>
    /// Interaction logic for NewsWindow.xaml
    /// </summary>
    public partial class NewsWindow : Window
    {
        public NewsWindow()
        {
            InitializeComponent();
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

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(NewsTitle) && !string.IsNullOrEmpty(NewsDescription))
            {
                MessageBox.Show($"{NewsTitle} {NewsDescription} {ShouldDelete}");
            }
            else
            {
                MessageBox.Show("Sarlavha va Tasvirlash yozilsin!", "Xato", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
