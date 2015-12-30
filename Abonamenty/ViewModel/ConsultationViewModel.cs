using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonamenty.ViewModel
{
    public class ConsultationViewModel : ObservableObject, ITabViewModel
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
    }
}
