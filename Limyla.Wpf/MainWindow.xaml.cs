using Limyla.Wpf.ViewModels;
using System.Windows;

namespace Limyla.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>ViewModel to associate to the page</summary>
        public PageXViewModel ViewModel { get; set; } = new PageXViewModel();

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new PageXViewModel();

            DataContext = this;
        }
    }
}
