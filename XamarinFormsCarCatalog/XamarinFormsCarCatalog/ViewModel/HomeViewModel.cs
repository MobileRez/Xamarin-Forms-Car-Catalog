using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFormsCarCatalog.Model;

namespace XamarinFormsCarCatalog.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<HomeMenuItem> MenuItems { get; set; }
        public HomeViewModel()
        {
            CanLoadMore = true;
            Title = "Dashboard";
            MenuItems = new ObservableCollection<HomeMenuItem>();
            MenuItems.Add(new HomeMenuItem
            {
                Id = 0,
                Title = "Home",
                MenuType = MenuType.Home,
                Icon = "about.png"
            });
            MenuItems.Add(new HomeMenuItem
            {
                Id = 1,
                Title = "Car",
                MenuType = MenuType.Car,
                Icon = "blog.png"
            });
            MenuItems.Add(new HomeMenuItem
            {
                Id = 2,
                Title = "Truck",
                MenuType = MenuType.Suv,
                Icon = "twitternav.png"
            });
            MenuItems.Add(new HomeMenuItem
            {
                Id = 3,
                Title = "Suv",
                MenuType = MenuType.Suv,
                Icon = "about.png"
            });
        }
    }
}
