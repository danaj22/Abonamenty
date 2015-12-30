using Abonamenty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Abonamenty.ViewModel
{
    public class SubscriptionViewModel : ObservableObject
    {
        public SubscriptionViewModel()
        {
            SubscriptionFunctionality = new ObservableCollection<SubscriptionViewModelBase>();
            SubscriptionFunctionality.Add(new AddSubscriberViewModel());
            SubscriptionFunctionality.Add(new AddTariffViewModel());
            SubscriptionFunctionality.Add(new AddDeviceViewModel());
            SubscriptionFunctionality.Add(new EditDeviceViewModel());
            SubscriptionFunctionality.Add(new DeleteDeviceViewModel());


            SearchCommand = new SimpleRelayCommand(Search);
            CollectionOfClients = new ObservableCollection<subscription>();

            ListOfSearchingParameters = new List<string>();
            ListOfSearchingParameters.Add("Nazwa klienta");
            ListOfSearchingParameters.Add("Nr abonamentu");
            ListOfSearchingParameters.Add("NIP");
            ListOfSearchingParameters.Add("Nazwisko");
            ListOfSearchingParameters.Add("Adres e-mail");

        }
        private string selectedParameter;
        private List<string> listOfSearchingParameters;
        private ICommand searchCommand;
        private string searchingPhrase;

        public string SearchingPhrase
        {
            get
            {
                return searchingPhrase;
            }

            set
            {
                searchingPhrase = value;
                OnPropertyChanged("SearchingPhrase");
            }
        }


        public ObservableCollection<SubscriptionViewModelBase> SubscriptionFunctionality
        {
            get
            {
                return subscriptionFunctionality;
            }

            set
            {
                subscriptionFunctionality = value;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return searchCommand;
            }

            set
            {
                searchCommand = value;
            }
        }

        public SubscriptionViewModelBase SearchContent
        {
            get
            {
                return searchContent;
            }

            set
            {
                searchContent = value;
                OnPropertyChanged("SearchContent");
            }
        }

        public SubscriptionViewModelBase SelectedFuncionality
        {
            get
            {
                return selectedFuncionality;
            }

            set
            {
                selectedFuncionality = value;
                OnPropertyChanged("SelectedFuncionality");
                if(SelectedFuncionality is AddSubscriberViewModel)
                {
                    SearchContent = new AddSubscriberViewModel();
                }
                if(SelectedFuncionality is AddTariffViewModel)
                {
                    SearchContent = new AddTariffViewModel();
                }
                if(SelectedFuncionality is AddDeviceViewModel)
                {
                    SearchContent = new AddDeviceViewModel();
                }
                if(SelectedFuncionality is EditDeviceViewModel)
                {
                    SearchContent = new EditDeviceViewModel();
                }
                if(SelectedFuncionality is DeleteDeviceViewModel)
                {
                    SearchContent = new DeleteDeviceViewModel();
                }
                
            }
        }

        public ObservableCollection<subscription> CollectionOfClients
        {
            get
            {
                return collectionOfClients;
            }

            set
            {
                collectionOfClients = value;
                OnPropertyChanged("CollectionOfClients");
            }
        }

        public List<string> ListOfSearchingParameters
        {
            get
            {
                return listOfSearchingParameters;
            }

            set
            {
                listOfSearchingParameters = value;
            }
        }

        public string SelectedParameter
        {
            get
            {
                return selectedParameter;
            }

            set
            {
                selectedParameter = value;
                OnPropertyChanged("SelectedParameter");
            }
        }

        private SubscriptionViewModelBase searchContent;
        private SubscriptionViewModelBase selectedFuncionality;
        private ObservableCollection<subscription> collectionOfClients;

        private ObservableCollection<SubscriptionViewModelBase> subscriptionFunctionality;
        private void Search()
        {
            SearchClientViewModel searchContentTemp = new SearchClientViewModel();
            searchContentTemp.CollectionOfClients = new ObservableCollection<client>();

            using (SubscriptionContext context = new SubscriptionContext())
            {
                if (SelectedParameter == "Nazwa klienta")
                {
                    //int i = Convert.ToInt32(SearchingPhrase);

                    var result = (from c in context.clients where c.name == SearchingPhrase select c).FirstOrDefault();

                    client cli = (client)result;
                    

                    searchContentTemp.CollectionOfClients.Add(cli);
                   
                    //foreach (subscription s in result)
                    //{
                    //    CollectionOfClients.Add(s);
                    //System.Windows.MessageBox.Show(s.registration_data.ToString() + s.tariff_id.ToString());

                    // }
                }
                else if (SelectedParameter == "Nr abonamentu")
                {

                }

            }


            SearchContent = searchContentTemp;
        }
    }
}
