using System;
using System.ComponentModel;
using System.Collections.Generic;


namespace XamarinFormsCarCatalog.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            
        }

        private string _title = string.Empty;
        public const string TitlePropertyName = "Title";
        // Gets or sets the "Title" property
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, TitlePropertyName); }
        }

        private string _subTitle = string.Empty;
        // Gets or sets the "Subtitle" property
        public const string SubtitlePropertyName = "Subtitle";
        public string Subtitle
        {
            get { return _subTitle; }
            set { SetProperty(ref _subTitle, value, SubtitlePropertyName); }
        }

        private string _icon;
        // Gets or sets the "Icon" of the viewmodel
        public const string IconPropertyName = "Icon";
        public string Icon
        {
            get { return _icon; }
            set { SetProperty(ref _icon, value, IconPropertyName); }
        }

        private bool _isBusy;
        // Gets or sets if the view is busy.
        public const string IsBusyPropertyName = "IsBusy";
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value, IsBusyPropertyName); }
        }

        private bool _canLoadMore = true;
        // Gets or sets if we can load more.
        public const string CanLoadMorePropertyName = "CanLoadMore";
        public bool CanLoadMore
        {
            get { return _canLoadMore; }
            set { SetProperty(ref _canLoadMore, value, CanLoadMorePropertyName); }
        }

        protected void SetProperty<T>(
            ref T backingStore, T value,
            string propertyName,
            Action onChanged = null)
        {


            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}