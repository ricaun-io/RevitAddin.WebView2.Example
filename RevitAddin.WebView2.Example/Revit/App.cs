using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.WebView2.Example.Views;
using ricaun.Revit.UI;
using System;

namespace RevitAddin.WebView2.Example.Revit
{
    [AppLoader]
    public class App : IExternalApplication
    {
        private RibbonPanel ribbonPanel;
        public Result OnStartup(UIControlledApplication application)
        {
            ribbonPanel = application.CreatePanel("WebView2");

            var textBox = ribbonPanel.CreateTextBox()
                    .SetPromptText("URL")
                    .SetValue(ViewModel.Instance.Uri.ToString())
                    .SetLargeImage("Resources/Revit.ico")
                    .AddEnterPressed((e, s) =>
                    {
                        var textBox = e as TextBox;
                        ViewModel.Instance.Uri = new Uri(textBox.Value.ToString());
                    });

            ribbonPanel.RowStackedItems(
                textBox,
                ribbonPanel.CreatePushButton<Commands.CommandPage>("Page")
                    .SetLargeImage("Resources/Revit.ico"),
                ribbonPanel.CreatePushButton<Commands.CommandDockablePane>("Dockable")
                    .SetLargeImage("Resources/Revit.ico")
                );

            if (int.TryParse(application.ControlledApplication.VersionNumber, out int versionNumber))
            {
                if (versionNumber >= 2024)
                    RegisterDockablePane(application);
            }

            return Result.Succeeded;
        }

        private static Guid DockablePaneGuid => new Guid("C36E3BC8-0985-4080-8E84-C10D6AB8D80A");
        private static DockablePaneId DockablePaneId => new DockablePaneId(DockablePaneGuid);
        public static void DockablePaneShow(UIApplication uiapp)
        {
            var dockablePane = uiapp.GetDockablePane(DockablePaneId);
            if (dockablePane.IsShown())
            {
                dockablePane.Hide();
            }
            else
            {
                dockablePane.Show();
            }
        }
        private void RegisterDockablePane(UIControlledApplication application)
        {
            if (DockablePane.PaneIsRegistered(DockablePaneId))
                return;

            //application.RegisterDockablePane(DockablePaneId, "WebView2", new DockablePanePageProvider(() => { return new WebView2Page(); }));
            application.RegisterDockablePane(DockablePaneId, "WebView2", new DockablePanePageProvider(new WebView2Page()));
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            ribbonPanel?.Remove();
            return Result.Succeeded;
        }
    }
}