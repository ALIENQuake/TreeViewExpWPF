using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace TreeViewExpWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            TreeView.Items.Clear();

            var Directory = TextBox.Text;
            var EnumerationOptions = new EnumerationOptions
            {
                IgnoreInaccessible = true,
                RecurseSubdirectories = true
            };

            await Task.Run(() =>
            {
                foreach (var file in System.IO.Directory.EnumerateDirectories(Directory, "*", EnumerationOptions))
                {
                    Dispatcher.BeginInvoke(() =>
                    {
                        var tvItem = new TreeViewItem();
                        tvItem.Header = file;
                        TreeView.Items.Add(tvItem);
                    }, DispatcherPriority.Background);
                }
            });
        }
    }
}