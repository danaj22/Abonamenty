using Abonamenty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Abonamenty.ViewModel
{
    public class DeleteDeviceViewModel: SubscriptionViewModelBase
    {
        public  DeleteDeviceViewModel ()
        {
            CollectionOfDevices = new ObservableCollection<device>();
            using (SubscriptionContext context = new SubscriptionContext())
            {
                try
                {

                    foreach(device dev in context.devices)
                    {
                        CollectionOfDevices.Add(dev);
                    }
                }
                catch(Exception e)
                {
                    File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                }
            }
            
            SelectDeviceCommand = new SimpleRelayCommand(SelectDevice);
        }

        //wybór i usunięcie z bazy urządzenia wybranego z listy 
        private void SelectDevice()
        {

            using (SubscriptionContext context = new SubscriptionContext())
            {
                try
                {
                    MessageBoxResult mr = MessageBox.Show("Czy na pewno usunąć to urządzenie?","Pytanie",MessageBoxButton.YesNo);
                    if (mr == MessageBoxResult.Yes)
                    {
                        context.devices.Attach(SelectedDevice);
                        context.devices.Remove(SelectedDevice);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Usunięto urządzenie z bazy.");
                    CollectionOfDevices.Remove(SelectedDevice);

                }
                catch (Exception e)
                {
                    File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                    MessageBox.Show("Błąd! Nie usunięto urządzenia.");
                }
            }
        }



        public override string Name
        {
            get
            {
                return "Usuń urządzenie";
            }
        }
        public ICommand SelectDeviceCommand { get; set; }

        public ObservableCollection<device> CollectionOfDevices
        {
            get
            {
                return collectionOfDevices;
            }

            set
            {
                collectionOfDevices = value;
                OnPropertyChanged("CollectionOfDevices");
            }
        }

        public device SelectedDevice
        {
            get
            {
                return selectedDevice;
            }

            set
            {
                selectedDevice = value;
                OnPropertyChanged("SelectedDevice");
            }
        }

        private device selectedDevice;
        private ObservableCollection<device> collectionOfDevices;

    }
}
