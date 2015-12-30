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
    public class AddSubscriberViewModel : SubscriptionViewModelBase
    {
        public AddSubscriberViewModel()
        {

            TypeOfOffer = new ObservableCollection<tariff>();
            SaveCommand = new SimpleRelayCommand(Save);

            using (SubscriptionContext context = new SubscriptionContext())
            {

                foreach (tariff t in context.tariffs)
                {
                    TypeOfOffer.Add(t);
                }
            }

            using (SubscriptionContext context = new SubscriptionContext())
            {
                var result = (from s in context.subscriptions orderby s.subscriptionId descending select s).FirstOrDefault();

                if (result == null)
                {
                    SubscriptionId = "A1000";
                }
                else
                {
                    SubscriptionId = (result.subscriptionId + 1).ToString();
                }

            }
        }

        //Dodanie abonamentu klienta
        private void Save()
        {
            try
            {
                SubscriptionContext context = new SubscriptionContext();
                subscription subscript = new subscription();
                subscript.registration_data = DateTime.Now;
                subscript.tariff = SelectedOffer;

                context.subscriptions.Add(subscript);
                context.SaveChanges();
                MessageBox.Show("Dodano abonament.");


            }
            catch (Exception ex)
            {
                File.AppendAllText(MainWindowViewModel.PathToLog, ex.ToString());
                MessageBox.Show("Błąd! Nie udało się dodać abonamentu.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #region fields

        public tariff SelectedOffer
        {
            get
            {
                return selectedOffer;
            }

            set
            {
                selectedOffer = value;
                OnPropertyChanged("SelectedOffer");
            }
        }

        public ObservableCollection<tariff> TypeOfOffer
        {
            get
            {
                return typeOfOffer;
            }

            set
            {
                typeOfOffer = value;
                OnPropertyChanged("TypeOfOffer");
            }
        }

        public override string Name
        {
            get
            {
                return "Dodaj abonenta";
            }


        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string NIP
        {
            get
            {
                return nIP;
            }

            set
            {
                nIP = value;
                OnPropertyChanged("NIP");
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }

            set
            {
                comment = value;
                OnPropertyChanged("Comment");
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

        public ICommand SaveCommand { get; set; }
        private ObservableCollection<tariff> typeOfOffer;
        private tariff selectedOffer;
        private string subscriptionId;
        private string address;
        private string email;
        private string nIP;
        private string comment;

        #endregion
    }
}
