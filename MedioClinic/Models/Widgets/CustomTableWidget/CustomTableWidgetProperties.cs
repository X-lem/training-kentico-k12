using System;

using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace MedioClinic.Models.Widgets
{
    public sealed class CustomTableWidgetProperties : IWidgetProperties
    {

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "{$Widget.CustomTable.TableCodeName$}", Order = 0)]
        public string CustomTableCodeName { get; set; }

        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "{$Widget.CustomTable.MaxRows$}", Order = 1)]
        public int MaxRows { get; set; } = 100;

        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "{$Widget.CustomTable.OrderBy}", Order = 2)]
        public string OrderBy { get; set; }
    }
}