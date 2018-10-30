using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    public class Customer
    {       
        #region customer's name
        public string Name { get; set; }
        #endregion

        #region constructor
        public Customer() { }
        public Customer(string name)
        {
            Name = name;

        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            return $"{Name}";
        }
        #endregion
    }
}
