using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonamenty.ViewModel
{
    public abstract class SubscriptionViewModelBase : ObservableObject
    {
        public abstract string Name { get; }
    }
}
