using AppTestMvvm.Models;
using SL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppTestMvvm.ViewModels
{
    public class ColorViewModel:INotifyPropertyChanged
    {
        public INavigation _nav;
        public IDataStore<Product> DataStore1 => DependencyService.Get<IDataStore<Product>>() ?? new DataStore<Product>("DataBase.db3");
        private readonly IDependencyService _dependencyService;



        public ColorViewModel() : this(new DependencyServiceWrapper())
        {
        }
        public ColorViewModel(INavigation nav)
        {

            _nav = nav;
            CurrentPage = DependencyInject<MainPage>.Get();
        }

        public ColorViewModel(IDependencyService dependencyService)
        {
            _dependencyService = dependencyService;
        }


        public string _colorcode;
        public string Colorcode
        {
            get
            {
                return _colorcode;
            }
            set
            {
                _colorcode = value;
            }
        }
        public string _colorname;
        public string Colorname
        {
            get
            {
                return _colorname;
            }
            set
            {
                _colorname = value;
            }
        }

        #region CurrentPage
        Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }




        public ICommand VALIDATE => new Command(async () =>
        {

            try
            {
                var u = await DataStore1.GetAllAsync();

                if (u.Count() > 0)
                {
                    await CurrentPage.DisplayAlert("Notification !..", "Welcome ..", "Ok ..");
                    var ss = DependencyService.Get<ColorViewModel>() ?? (new ViewModels.ColorViewModel(_nav));
                }
                else
                {
                    await CurrentPage.DisplayAlert("Error !..", "No Data ..", "Ok ..");
                }
            }
            catch (Exception ex)
            {
               
            }

        });
    }
}
