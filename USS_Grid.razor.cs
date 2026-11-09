using Microsoft.AspNetCore.Components;
using System.Reflection;
using USS.Base.Model;

namespace USS.Base.Web
{
    public partial class USS_Grid<T> where T : BaseEntityModel, new()
    {

        [Parameter]
        public bool IdVisible { get; set; } = true;

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool IsAction { get; set; }

        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public List<BaseGridModel<T>> Values { get; set; }

        [Parameter]
        public EventCallback<List<BaseGridModel<T>>> ValuesChanged { get; set; }

        [Parameter]
        public EventCallback<BaseGridModel<T>> OnEdit { get; set; }

        [Parameter]
        public EventCallback<BaseGridModel<T>> OnSave { get; set; }


        [Parameter]
        public EventCallback<BaseGridModel<T>> OnDelete { get; set; }

        [Parameter]
        public EventCallback<BaseGridModel<T>> OnCancel { get; set; }


        [Parameter]
        public EventCallback<string> OnDeleteClose { get; set; }

        public Type type { get; set; }

        public List<GridColumn> Columns { get; set; }
        public USS_Grid()
        {
            type = typeof(T);
            var t1 = type.GetTypeInfo();
            if (t1.IsGenericType)  type = t1.GenericTypeArguments[0];

            Columns = new List<GridColumn>();
            foreach (var prop in type.GetProperties())
            {
                if (prop.Name != "Item")
                {
                    var column = new GridColumn()
                    {
                        Name = prop.Name,
                        Title = prop.Name,
                        DataType = prop.PropertyType.Name,
                        InputType = ControlType.Text
                    };
                    if(prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                    {
                        column.InputType = ControlType.DateTimeLocal;
                    }

                    else if (prop.PropertyType == typeof(DateOnly) || prop.PropertyType == typeof(DateOnly?))
                    {
                        column.InputType = ControlType.Date;
                    }
                    else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
                    {
                        column.InputType = ControlType.Checkbox;
                    }
                    else if (prop.PropertyType == typeof(byte) || prop.PropertyType == typeof(byte?) ||
                                prop.PropertyType == typeof(short) || prop.PropertyType == typeof(short?) ||
                                prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?) ||
                                prop.PropertyType == typeof(long) || prop.PropertyType == typeof(long?) ||
                                prop.PropertyType == typeof(float) || prop.PropertyType == typeof(float?) ||
                                prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?) ||
                                prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                    {
                        column.InputType = ControlType.Number;
                    }
                    Columns.Add(column);
                }
            }
        }
    }
}
