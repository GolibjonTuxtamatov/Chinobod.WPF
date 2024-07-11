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
            this.DataContext = this;
        }

        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
    }
}
