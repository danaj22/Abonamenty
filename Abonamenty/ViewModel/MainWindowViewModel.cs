using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonamenty.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        public MainWindowViewModel()
        {

            try
            {
                Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\Abonamenty");
            }
            catch
            {
                System.Windows.MessageBox.Show(@"Nie można utworzyć katalogu C:\ProgramData\DASLSystems\Abonamenty");
            }

            tabs = new ObservableCollection<string>();
            Tabs.Add("aaa");
            Tabs.Add("bbb");
            Title = "Panel zarządzania";

            TabViewModels = new ObservableCollection<ITabViewModel>();
            TabViewModels.Add(new SubscriptionTabViewModel { Header = "Abonamenty" , SubscriptionId="aaa"});
            TabViewModels.Add(new RentTabViewModel { Header = "Wypożyczenia" });
            TabViewModels.Add(new ConsultationViewModel { Header = "Konsultacje" });
            TabViewModels.Add(new ReturnDeviceTabViewModel { Header = "Zwroty" });


            SelectedTabViewModel = TabViewModels[0];
        }
        public static string PathToLog = @"C:\ProgramData\DASLSystems\Abonamenty\log.txt";

        private ObservableCollection<ITabViewModel> tabViewModels;

        private ObservableCollection<string> tabs;

        public ObservableCollection<string> Tabs
        {
            get
            {
                return tabs;
            }

            set
            {
                tabs = value;
                OnPropertyChanged("Tabs");
            }

        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private ITabViewModel selectedTabViewModel;

        public ObservableCollection<ITabViewModel> TabViewModels
        {
            get
            {
                return tabViewModels;
            }

            set
            {
                tabViewModels = value;
                OnPropertyChanged("TabViewModels");
            }
        }

        public ITabViewModel SelectedTabViewModel
        {
            get
            {
                return selectedTabViewModel;
            }

            set
            {
                selectedTabViewModel = value;
                OnPropertyChanged("SelectedTabViewModel");
            }
        }

        private string title;
    }
}
