using System.Web.Mvc;

using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets;

using Kentico.PageBuilder.Web.Mvc;
using CMS.CustomTables;
using System.Collections.Generic;
using System.Linq;

[assembly: RegisterWidget(
    "MedioClinic.CustomTable.Text",
    typeof(CustomTableWidgetController),
    "{$Widget.CustomTable.Name$}",
    Description = "{$Widget.CustomTable.Description$}",
    IconClass = "icon-table")]

namespace MedioClinic.Controllers.Widgets
{
    public class CustomTableWidgetController : WidgetController<CustomTableWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();

            string customeTableName = "MedioClinic.Diseases";
            var customTable = CustomTableItemProvider.GetItems(customeTableName);

            return PartialView("Widgets/_CustomTableWidget", new CustomTableWidgetViewModel
            {
                CustomTableCodeName = customeTableName,
                ColumnNames = getColumnNames(customTable.FirstOrDefault()),
                CustomTableData = customTable
            });
        }

        private List<string> getColumnNames(CustomTableItem row)
        {
            List<string> colList = new List<string>();
            foreach (string column in row.ColumnNames)
            {
                if (column.StartsWith("Item"))
                {
                    continue;
                }
                else
                {
                    colList.Add(column);
                }
            }

            return colList;
        }
    }
}