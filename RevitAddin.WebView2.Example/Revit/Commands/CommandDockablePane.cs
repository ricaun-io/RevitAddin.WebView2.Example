using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitAddin.WebView2.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class CommandDockablePane : IExternalCommand, IExternalCommandAvailability
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            App.DockablePaneShow(uiapp);

            return Result.Succeeded;
        }

        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (int.TryParse(applicationData.Application.VersionNumber, out int versionNumber))
            {
                return (versionNumber >= 2024);
            }
            return false;
        }
    }
}
