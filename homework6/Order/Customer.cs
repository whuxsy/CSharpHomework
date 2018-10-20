using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    public class Customer
    {
        #region customer's id
        public uint Id { get; set; }
        #endregion

        #region customer's name
        public string Name { get; set; }
        #endregion

        #region constructor
        public Customer() { }
        public Customer(uint id, string name)
        {
            Id = id;
            Name = name;

        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            return $"customersId: {Id}, customersName: {Name}";
        }
        #endregion
    }
}
