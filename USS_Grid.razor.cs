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
        public PropertyInfo[] Properties { get; set; }
        public USS_Grid()
        {
            type = typeof(T);
            var t1 = type.GetTypeInfo();
            if (t1.IsGenericType)  type = t1.GenericTypeArguments[0];

            Properties = type.GetProperties();
            Properties = Properties.Where(p=> p.Name!="Item").ToArray();
        }
    }
}
