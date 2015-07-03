using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFormsCarCatalog.Model
{
    public enum MenuType
    {
        Home,
        Car,
        Truck,
        Suv
    }

    public class HomeMenuItem : BaseModel
    {
        public HomeMenuItem()
        {
            MenuType = MenuType.Home;
        }
        public string Icon { get; set; }
        public MenuType MenuType { get; set; }
    }
}
