using Autodesk.Revit.UI;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RevitAddin.WebView2.Example.Revit
{
    internal class DockablePanePageProvider : IDockablePaneProvider
    {
        private IFrameworkElementCreator frameworkElementCreator;
        private Page page;

        public DockablePanePageProvider(IFrameworkElementCreator frameworkElementCreator)
        {
            this.frameworkElementCreator = frameworkElementCreator;
        }
        public DockablePanePageProvider(Func<Page> action)
        {
            this.frameworkElementCreator = new FrameworkElementCreator(action);
        }
        public DockablePanePageProvider(Page page)
        {
            this.page = page;
        }
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Tabbed,
                MinimumHeight = 320,
                MinimumWidth = 320,
            };
            data.FrameworkElement = page;

            if (page is null)
                data.FrameworkElementCreator = frameworkElementCreator;
        }
    }

    public class FrameworkElementCreator : IFrameworkElementCreator
    {
        public Func<Page> action;
        public FrameworkElementCreator(Func<Page> action)
        {
            this.action = action;
        }
        public FrameworkElement CreateFrameworkElement()
        {
            return action();
        }
    }
}