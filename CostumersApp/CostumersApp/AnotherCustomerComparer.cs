using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumersApp
{
    class AnotherCustomerComparer : IComparer<Costumer>
    {
        public int Compare(Costumer x, Costumer y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }
}
