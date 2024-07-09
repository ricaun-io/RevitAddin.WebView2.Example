using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RevitAddin.WebView2.Example.Views;
using System;

namespace RevitAddin.WebView2.Example.Revit.Commands
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand, IExternalCommandAvailability
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elementSet)
        {
            UIApplication uiapp = commandData.Application;

            return Result.Succeeded;
        }

        public bool IsCommandAvailable(UIApplication uiapp, CategorySet selectedCategories)
        {
            return true;
        }
    }
}
