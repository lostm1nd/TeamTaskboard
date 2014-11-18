namespace TeamTaskboard.Web.Helpers
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.UI.Fluent;

    public static class KendoHelpers
    {
        public static GridBuilder<T> CustomKendoGrid<T>
            (this HtmlHelper helper, string gridName, string controllerName, Expression<Func<T, object>> modelIdExpression,
                bool withCreate = true, int pageSize = 10, Action<GridColumnFactory<T>> columns = null) where T : class
        {
            if (columns == null)
            {
                columns = cols =>
                {
                    cols.AutoGenerate(true);
                    cols.Command(c => { c.Edit(); c.Destroy(); }).Title("Actions");
                };
            }

            var grid = helper.Kendo()
                .Grid<T>()
                .Name(gridName)
                .Columns(columns)
                .Pageable(page => page.Refresh(true))
                .Sortable()
                .Groupable()
                .Filterable()
                .Editable(edit => edit.Mode(GridEditMode.PopUp));

            if (withCreate)
            {
                grid.ToolBar(toolbar => toolbar.Create());
            }
                
            grid.DataSource(data =>
                data
                    .Ajax()
                    .PageSize(pageSize)
                    .Model(m => m.Id(modelIdExpression))
                    .Read(read => read.Action("Read", controllerName))
                    .Create(create => create.Action("Create", controllerName))
                    .Update(update => update.Action("Update", controllerName))
                    .Destroy(destroy => destroy.Action("Destroy", controllerName))
                    );

            return grid;
        }
    }
}