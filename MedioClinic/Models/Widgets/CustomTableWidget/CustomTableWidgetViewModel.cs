using CMS.CustomTables;
using CMS.DataEngine;
using System.Collections.Generic;

namespace MedioClinic.Models.Widgets
{
    public class CustomTableWidgetViewModel
    {
        public string CustomTableCodeName { get; set; }
        public int MaxRows { get; set; }    
        public string OrderBy { get; set; }

        // Hanlded via controller
        public List<string> ColumnNames { get; set; }
        public ObjectQuery<CustomTableItem> CustomTableData { get; set; }
    }
}