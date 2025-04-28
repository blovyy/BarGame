using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarGamee
{
    public class Customer
    {
        public string Name { get; set; }
        public int SpendMoney { get; set; }
        public int HappinessEffect { get; set; }

        public Customer(string name, int spendMoney, int happinessEffect)
        {
            Name = name;
            SpendMoney = spendMoney;
            HappinessEffect = happinessEffect;
        }
    }
}
