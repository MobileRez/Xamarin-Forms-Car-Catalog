using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinFormsCarCatalog.Helpers;
using XamarinFormsCarCatalog.Model;
using XamarinFormsCarCatalog.ViewModel;

namespace XamarinFormsCarCatalog.Views
{
    class HomeView : MasterDetailPage
    {
        private HomeViewModel ViewModel
        {
            get { return BindingContext as HomeViewModel; }
        }
        HomeMasterView master;
        private Dictionary<MenuType, NavigationPage> pages;
        public HomeView()
        {
            pages = new Dictionary<MenuType, NavigationPage>();
            BindingContext = new HomeViewModel();

            Master = master = new HomeMasterView(ViewModel);

            var homeNav = new NavigationPage(master.PageSelection)
            {
                BarBackgroundColor = Color.FromHex("#3498DB"),
                BarTextColor = Color.White
            };
            Detail = homeNav;

            pages.Add(MenuType.Home, homeNav);

            master.PageSelectionChanged = async menuType =>
            {

                if (Detail != null && Device.OS == TargetPlatform.WinPhone)
                {
                    await Detail.Navigation.PopToRootAsync();
                }

                NavigationPage newPage;
                if (pages.ContainsKey(menuType))
                {
                    newPage = pages[menuType];
                }
                else
                {
                    newPage = new NavigationPage(master.PageSelection)
                    {
                        BarBackgroundColor = Color.FromHex("#3498DB"),
                        BarTextColor = Color.White
                    };
                    pages.Add(menuType, newPage);
                }
                Detail = newPage;
                Detail.Title = master.PageSelection.Title;
                if (Device.Idiom != TargetIdiom.Tablet)
                    IsPresented = false;
            };

            Icon = "slideout.png";
        }
    }

    public class HomeMasterView : BaseView
    {
        public Action<MenuType> PageSelectionChanged;
        private Page _pageSelection;
        private MenuType _menuType = MenuType.Home;

        public Page PageSelection
        {
            get { return _pageSelection; }
            set
            {
                _pageSelection = value;
                if (PageSelectionChanged != null) PageSelectionChanged(_menuType);
            }
        }
        private Page _home, _car, _truck, _suv;
        public HomeMasterView(HomeViewModel viewModel)
        {
            Icon = "slideout.png";
            BindingContext = viewModel;

            var layout = new StackLayout { Spacing = 0 };

            var label = new ContentView
            {
                //left, top, right, bottom
                Padding = new Thickness(10, 36, 0, 5),
                BackgroundColor = Color.Transparent,
                Content = new Label
                {
                    Text = "MENU",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                }
            };

            layout.Children.Add(label);

            var listView = new ListView();

            DataTemplate cell;

            if (Device.OS == TargetPlatform.WinPhone)
            {
                cell = new DataTemplate(typeof(FancyListCell));
                BackgroundColor = Color.FromHex("#CCCCCC");
            }
            else
            {
                cell = new DataTemplate(typeof(ListImageCell));
                cell.SetBinding(TextCell.TextProperty, HomeViewModel.TitlePropertyName);
                cell.SetBinding(ImageCell.ImageSourceProperty, "Icon");
            }

            listView.ItemsSource = viewModel.MenuItems;
            if (_home == null)
                _home = new HomePage();

            PageSelection = _home;
            //change to correct page
            listView.ItemSelected += (sender, args) =>
            {
                var menuItem = listView.SelectedItem as HomeMenuItem;
                _menuType = menuItem.MenuType;
                switch (menuItem.MenuType)
                {
                    case MenuType.Home:
                        if (_home == null)
                            _home = new HomePage();

                        PageSelection = _home;
                        break;
                    case MenuType.Car:
                        if (_car == null)
                            _car = new CarPage();

                        PageSelection = _car;
                        break;
                    case MenuType.Truck:
                        if (_truck == null)
                            _truck = new TruckPage();

                        PageSelection = _truck;
                        break;
                    case MenuType.Suv:
                        if (_suv == null)
                            _suv = new SuvPage();

                        PageSelection = _suv;
                        break;
                }
            };

            listView.SelectedItem = viewModel.MenuItems[0];
            layout.Children.Add(listView);

            Content = layout;
        }
    }
}