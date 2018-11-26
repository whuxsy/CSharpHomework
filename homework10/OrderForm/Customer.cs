using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    public class Customer
    {
        #region customer's name
        public string Name { get; set; }
        #endregion

        #region customer's phone
        public string Phone { get; set; }
        #endregion

        #region constructor
        public Customer() { }
        public Customer(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            return $"{Name}   {Phone}";
        }
        #endregion
    }
}
