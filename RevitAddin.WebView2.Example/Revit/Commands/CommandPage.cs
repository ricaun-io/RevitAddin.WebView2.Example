using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.WebView2.Example.Views;

namespace RevitAddin.WebView2.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandPage : IExternalCommand, IExternalCommandAvailability
    {
        private static PageView window;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            if (window is null)
            {
                window = new PageView(new WebView2Page());
                window.Closed += (s, e) => { window = null; };
                window.Show();
            }
            window?.Activate();

            return Result.Succeeded;
        }

        public bool IsCommandAvailable(UIApplication uiapp, CategorySet selectedCategories)
        {
            return true;
        }
    }

}
