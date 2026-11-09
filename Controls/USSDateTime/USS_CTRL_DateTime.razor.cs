using Microsoft.AspNetCore.Components;

namespace USS.Base.Web.Controls.USSDateTime
{
    public partial class USS_CTRL_DateTime
    {
        [Parameter]
        public DateTime? Value
        {
            get;
            set
            {
                field = value;
                ValueChanged.InvokeAsync(value);
            }

        }

        [Parameter]
        public EventCallback<DateTime?> ValueChanged { get; set; }


        [Parameter]
        public string Text { get; set; }


        [Parameter]
        public bool Disabled { get; set; }
    }
}
