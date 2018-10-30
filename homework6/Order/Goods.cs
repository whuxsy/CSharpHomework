using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest
{
    public class Goods
    {
        private double price;

        #region constructor
        public Goods() { }
        public Goods(string name, double value)
        {
            Name = name;
            Price = value;
        }
        #endregion 

        #region goods name
        public string Name { get; set; }
        #endregion

        #region goods price
        public double Price
        {
            get { return price; }
            set
            {
                if (value >= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("price must up to 0");
                }
            }
        }
        #endregion

        #region override the ToString()
        public override string ToString()
        {
            return $"{Name}  {Price}";
        }
        #endregion
    }
}

