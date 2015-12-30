using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonamenty.ViewModel
{
    public class SubscriptionTabViewModel : ObservableObject , ITabViewModel
    { 
        private string header;

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

        private string subscriptionId;


    }
}
