using System;
using System.Collections.Generic;
using System.Text;

namespace USS.Base.Web
{
    public class GridColumn
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string DataType { get; set; }
        public ControlType InputType { get; set; }
    }
}
