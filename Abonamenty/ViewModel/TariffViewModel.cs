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
    public class TariffViewModel : ObservableObject
    {
        public TariffViewModel()
        {
            SaveTariffCommand = new SimpleRelayCommand(SaveTariff);
        }

        private string nameOfTariff;

        public string NameOfTariff
        {
            get
            {
                return nameOfTariff;
            }

            set
            {
                nameOfTariff = value;
                OnPropertyChanged("NameOfTariff");
            }
        }

        public int NumberOfPhones
        {
            get
            {
                return numberOfPhones;
            }

            set
            {
                numberOfPhones = value;
                OnPropertyChanged("NumberOfPhones");
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

        public ICommand SaveTariffCommand
        {
            get
            {
                return saveTariffCommand;
            }

            set
            {
                saveTariffCommand = value;
            }
        }

        private int numberOfPhones;
        private double discount;
        private ICommand saveTariffCommand;
        private void SaveTariff()
        {
            if(!string.IsNullOrEmpty(NameOfTariff))
            {
                try
                {
                    SubscriptionContext context = new SubscriptionContext();
                    tariff TariffToAdd = new tariff();
                    TariffToAdd.name_tarriff = NameOfTariff;
                    TariffToAdd.number_of_calling = NumberOfPhones;
                    TariffToAdd.discount = Discount;

                    context.tariffs.Add(TariffToAdd);
                    context.SaveChanges();

                    System.Windows.MessageBox.Show( "Taryfa została poprawnie dodana do bazy","Komunikat");

                }
                catch(Exception ex)
                {
                    File.AppendAllText(MainWindowViewModel.PathToLog,ex.ToString());
                }

            }
        }
    }
}
