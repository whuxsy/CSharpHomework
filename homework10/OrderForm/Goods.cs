using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    public class Goods
    {

        public string Name { get; set; }
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
        public double price;

        #region constructor
        public Goods() { }
        public Goods(string name, double value)
        {
            Name = name;
            Price = value;
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

