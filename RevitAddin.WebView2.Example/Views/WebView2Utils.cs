using Microsoft.Web.WebView2.Core;
using ricaun.Revit.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RevitAddin.WebView2.Example.Views
{
    public class ViewModel : ObservableObject
    {
        public static ViewModel Instance { get; } = new ViewModel();
        public Uri Uri { get; set; } = new Uri("https://aps-single-page.glitch.me/");
    }

    public static class WebView2Utils
    {
        private const string UserDataFolder = "RevitAddin.WebView2.Example";
        public static async Task InitializeWebAsync(this Microsoft.Web.WebView2.Wpf.WebView2 webView)
        {
            try
            {
                var userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), UserDataFolder);

                var env = await CoreWebView2Environment.CreateAsync(
                    userDataFolder: userDataFolder
                );

                await webView.EnsureCoreWebView2Async(env);
                webView.WebMessageReceived += (sender, args) =>
                {
                    Console.WriteLine(args.TryGetWebMessageAsString());
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
