using System.Windows;
using System.Windows.Controls;

namespace Chinobod.WPF.Controls
{
    /// <summary>
    /// Interaction logic for NewsControl.xaml
    /// </summary>
    public partial class NewsControl : UserControl
    {
        public NewsControl()
        {
            InitializeComponent();
        }

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
    }
}
