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
    public class RentTabViewModel : ObservableObject, ITabViewModel
    {
        public RentTabViewModel()
        {
            RentDateStart = DateTime.Now;
            RentDateEnd = DateTime.Now;
            CalculateCommand = new SimpleRelayCommand(Calculate);
            RentCommand = new SimpleRelayCommand(Rent);

            CollectionOfDevices = new ObservableCollection<device>();

            //dadanie urządzeń do listy urządzeń wyświetlanych na liście dostępnych do wypozyczenia 
            using (SubscriptionContext context = new SubscriptionContext())
            {
                //var result = (from d in context.devices select d).ToList();

                //porównanie daty zwrotu z datą dzisiejszą,
                //jeśli dzisiaj powinien być oddany to będzie już dostępny na liście
                
                foreach(rent r in context.rents)
                {
                    if (r.date_of_return < DateTime.Now || r.date_of_rent > DateTime.Now)
                    {
                        //pobranie z listy wypozyczen-urzadzen urządzenie, ktore jest aktualanie niezajęte
                        var result2 = (from dr in context.devices_rents where r.rentId == dr.rent_id select dr.device).First();

                        //zmienna tymczasowa potrzebna do zaktualizowania statusu wypozyczenia
                        device deviceToChangeIsRentedStatus = (device)result2;


                        //context.devices.Attach(deviceToChangeIsRentedStatus);
                        deviceToChangeIsRentedStatus.is_rented = false;
                        
                    }

                }
                context.SaveChanges();

                var result = (from d in context.devices select d).ToList();

                //odrzucenie urządzeń ktore sa aktualnie wypozyczone 
                foreach (device dev in result)
                {

                    if (!dev.is_rented)
                    {
                        CollectionOfDevices.Add(dev);
                    }
                }
            }

        }
        
        private void Calculate()
        {
            TotalCost = 0;
            foreach (device dev in CollectionOfDevices)
            {
                if (dev.IsChecked)
                {
                    TotalCost += (double)dev.price * NumberOfDays;
                }
            }

            try
            {
                int subscriptionTmp = Convert.ToInt16(SubscriptionId);
                using (SubscriptionContext context = new SubscriptionContext())
                {
                    var result = (from s in context.subscriptions where s.subscriptionId == subscriptionTmp select s).First();
                    Discount = (double)result.tariff.discount;
                }

                TotalCostWithDiscount = Math.Round(TotalCost - TotalCost * 0.01 * Discount,2);
            }
            catch(Exception e)
            {
                File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                System.Windows.MessageBox.Show("Nie można policzyć wartości. Popraw dane.");
            }

        }
        private void Rent()
        {
            MessageBoxResult mbrTmp = MessageBox.Show("Czy na pewno wypożyczyć te urządzenia?","Pytanie",MessageBoxButton.YesNoCancel,MessageBoxImage.Question,MessageBoxResult.Yes);

            if(mbrTmp == MessageBoxResult.Yes)
            {
                rent RentToAdd = new rent();
                RentToAdd.date_of_rent = RentDateStart;
                RentToAdd.date_of_return = RentDateEnd;
                RentToAdd.total_price = TotalCostWithDiscount;

                try
                {
                    RentToAdd.subscription_id = Convert.ToInt16(SubscriptionId);
                }
                catch(Exception e)
                {
                    File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                    System.Windows.MessageBox.Show("Nie powiodło się pobranie abonenta z bazy. Sprawdź dane.");
                    return;
                }

                using (SubscriptionContext context = new SubscriptionContext())
                {
                    try
                    {

                        context.rents.Add(RentToAdd);
                        context.SaveChanges();

                        foreach (device dev in CollectionOfDevices)
                        {
                            if(dev.IsChecked)
                            {
                                var result = (from d in context.devices where dev.deviceId == d.deviceId select d).First();
                                device deviceToUpdate = (device)result;
                                context.devices.Attach(deviceToUpdate);
                                deviceToUpdate.is_rented = true;

                                //dodawanie do bazy wpisu o wypozyczeniu do tabeli pośredniej miedzy wyporzyczeniami a urzadzeniami
                                devices_rents devRentToAdd = new devices_rents();
                                devRentToAdd.device_id = deviceToUpdate.deviceId;
                                devRentToAdd.rent_id = RentToAdd.rentId;

                                context.devices_rents.Add(devRentToAdd);
                            }
                        }

                        

                        context.SaveChanges();
                        System.Windows.MessageBox.Show("Dodano wypożyczenie.");

                        //aktualizacja danych na liście urządzeń
                        //(wypozyczono coś, wiec trzeba to usunąc z listy dostepnych do wypozyczenia)

                        var result2 = (from d in context.devices select d).ToList();
                        CollectionOfDevices = new ObservableCollection<device>();
                        
                        //odrzucenie urządzeń ktore sa aktualnie wypozyczone 
                        foreach (device dev in result2)
                        {

                            if (!dev.is_rented)
                            {
                                CollectionOfDevices.Add(dev);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        File.AppendAllText(MainWindowViewModel.PathToLog, e.ToString());
                        System.Windows.MessageBox.Show("Nie powiodło się dodanie wypożyczenia do bazy. Sprawdź dane.");
                        return;
                    }


                }

            }
        }

        #region fields and commands
        public ObservableCollection<ManageDeviceViewModelBase> CollectionOfDeviceManagementFunction
        {
            get
            {
                return collectionOfDeviceManagementFunction;
            }

            set
            {
                collectionOfDeviceManagementFunction = value;
                OnPropertyChanged("CollectionOfDeviceManagementFunction");
            }
        }

        public DateTime RentDateStart
        {
            get
            {
                return rentDateStart;
            }

            set
            {
                rentDateStart = value;
                NumberOfDays = (RentDateEnd.Date - RentDateStart.Date).TotalDays;
                OnPropertyChanged("RentDateStart");
            }
        }

        public DateTime RentDateEnd
        {
            get
            {
                return rentDateEnd;
            }

            set
            {
                rentDateEnd = value;
                NumberOfDays = (RentDateEnd.Date - RentDateStart.Date).TotalDays;
                OnPropertyChanged("RentDateEnd");
            }
        }
        private ObservableCollection<device> collectionOfDevices;
        public double NumberOfDays
        {
            get
            {
                return numberOfDays;
            }

            set
            {

                numberOfDays = value;
                OnPropertyChanged("NumberOfDays");
            }
        }

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

        public ICommand CalculateCommand
        {
            get
            {
                return calculateCommand;
            }

            set
            {
                calculateCommand = value;
            }
        }

        public double TotalCost
        {
            get
            {
                return totalCost;
            }

            set
            {
                totalCost = value;
                OnPropertyChanged("TotalCost");
            }
        }

        public string SubscriptionId
        {
            get
            {
                return subscriptionId;
            }

            set
            {
                subscriptionId = value;
                OnPropertyChanged("SubscriptionId");
            }
        }

        public double Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
                OnPropertyChanged("Discount");
            }
        }

        public double TotalCostWithDiscount
        {
            get
            {
                return totalCostWithDiscount;
            }

            set
            {
                totalCostWithDiscount = value;
                OnPropertyChanged("TotalCostWithDiscount");
            }
        }
        
        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                header = value;
                OnPropertyChanged("Header");
            }
        }

        public ICommand RentCommand
        {
            get
            {
                return rentCommand;
            }

            set
            {
                rentCommand = value;
            }
        }

        private ICommand rentCommand;
        private ICommand calculateCommand;
        private string header;
        private double totalCostWithDiscount;
        private double totalCost;
        private DateTime rentDateStart, rentDateEnd;
        private double numberOfDays;
        private ObservableCollection<ManageDeviceViewModelBase> collectionOfDeviceManagementFunction;
        private double discount;
        private string subscriptionId;
        
        #endregion
    }
}
