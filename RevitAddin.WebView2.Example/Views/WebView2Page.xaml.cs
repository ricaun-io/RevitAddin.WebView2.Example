using System.Windows.Controls;

namespace RevitAddin.WebView2.Example.Views
{
    public partial class WebView2Page : Page
    {
        public WebView2Page()
        {
            InitializeComponent();
            this.Dispatcher.Invoke(webView.InitializeWebAsync);
            this.DataContext = ViewModel.Instance;
            //this.Loaded += (s, e) =>
            //{
            //    System.Console.WriteLine($"{this.GetHashCode()} \t Loaded");
            //};
            //this.Unloaded += (s, e) =>
            //{
            //    System.Console.WriteLine($"{this.GetHashCode()} \t Unloaded");
            //    webView.Dispose();
            //};
        }
    }
}
