using Abonamenty.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Abonamenty.ViewModel
{
    public class RentViewModel:ObservableObject
    {
        public RentViewModel()
        {
           
        }


        #region fields and commands
        private DateTime rentDateStart,rentDateEnd;
        private double numberOfDays;
        private ObservableCollection<ManageDeviceViewModelBase> collectionOfDeviceManagementFunction;

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
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
                OnPropertyChanged("RentDateEnd");
                NumberOfDays = (RentDateStart.Date - RentDateEnd.Date).TotalDays;
            }
        }

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

        private string address;
        private string email;
        private string nIP;
        private string comment;

        #endregion
    }

}
