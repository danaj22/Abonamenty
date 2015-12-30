using Abonamenty.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Abonamenty.ViewModel
{
    public class AddDeviceViewModel: SubscriptionViewModelBase
    {
        public AddDeviceViewModel()
        {
            SaveCommand = new SimpleRelayCommand(Save);
            Title = "DODAWANIE URZĄDZENIA";
        }
        private void Save()
        {
            //dodawanie urządzenia do bazy

            //tworzenie obiektów i przypisanie im wartości z wypełnionego formularza
            genre tmpGenre = new genre();
            tmpGenre.genre_name = KindOfDevice.ToLower();

            device tmpDevice = new device();
            tmpDevice.genre = tmpGenre;
            tmpDevice.manufacturer_name = ManufacturerName.ToLower();
            tmpDevice.model_name = ModelName.ToLower();
            tmpDevice.serial_number = SerialNumber.ToLower();

            try
            {
                CostPerDay = CostPerDay.Replace(".", ",");
                tmpDevice.price = Convert.ToDouble(CostPerDay);
            }

            catch (Exception e)
            {
                File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                System.Windows.MessageBox.Show("Zła wartość liczbowa");
                return;
            }

            try
            {
                using (SubscriptionContext context = new SubscriptionContext())
                {
                    context.devices.Add(tmpDevice);
                    context.SaveChanges();
                }
                System.Windows.MessageBox.Show("Dodano urządzenie do bazy.");
            }
            catch (Exception e)
            {
                File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                System.Windows.MessageBox.Show("Nie dodano urządzenia do bazy.");
            }
        }
        #region fields
        public override string Name
        {
            get
            {
                return "Dodaj urządzenie";
            }
        }

        public string ManufacturerName
        {
            get
            {
                return manufacturerName;
            }

            set
            {
                manufacturerName = value;
                OnPropertyChanged("ManufacturerName");
            }
        }

        public string ModelName
        {
            get
            {
                return modelName;
            }

            set
            {
                modelName = value;
                OnPropertyChanged("ModelName");
            }
        }

        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }

            set
            {
                serialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }

        public string CostPerDay
        {
            get
            {
                return costPerDay;
            }

            set
            {
                costPerDay = value;
                OnPropertyChanged("CostPerDay");
            }
        }

        public string KindOfDevice
        {
            get
            {
                return kindOfDevice;
            }

            set
            {
                kindOfDevice = value;
                OnPropertyChanged("KindOfDevice");
            }
        }

        public string Title { get; set; }
        public ICommand SaveCommand { get; set; }
        private string kindOfDevice;
        private string costPerDay;
        private string serialNumber;
        private string modelName;
        private string manufacturerName;
        #endregion

    }
}
