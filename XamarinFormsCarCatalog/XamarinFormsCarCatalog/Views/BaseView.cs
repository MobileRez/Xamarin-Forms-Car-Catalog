using Xamarin.Forms;
using XamarinFormsCarCatalog.ViewModel;

namespace XamarinFormsCarCatalog.Views
{
    public class BaseView : ContentPage
    {
        public BaseView()
        {
            SetBinding(TitleProperty, new Binding(BaseViewModel.TitlePropertyName));
            SetBinding(IconProperty, new Binding(BaseViewModel.IconPropertyName));
        }
    }
}
