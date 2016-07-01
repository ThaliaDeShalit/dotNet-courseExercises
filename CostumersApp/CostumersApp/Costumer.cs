using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostumersApp
{
    class Costumer : IComparable<Costumer>, IEquatable<Costumer>
    {
        private string _name;
        private int _ID;
        private string _address;

        public Costumer(string name, int id, string address)
        {
            _name = name;
            _ID = id;
            _address = address;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }
        }

        public int CompareTo(Costumer otherCostumer)
        {
            return Name.CompareTo(otherCostumer.Name);
        }

        public bool Equals(Costumer otherCostumer)
        {
            return (CompareTo(otherCostumer) == 0 && ID == otherCostumer.ID) ? true : false;
        }
    }
}
