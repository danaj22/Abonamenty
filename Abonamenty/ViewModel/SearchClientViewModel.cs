using Abonamenty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonamenty.ViewModel
{
    public class SearchClientViewModel : SubscriptionViewModelBase
    {
        public override string Name
        {
            get
            {
                return "Szukaj klienta";
            }
        }

        public ObservableCollection<client> CollectionOfClients
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

        private ObservableCollection<client> collectionOfClients;

    }
}
