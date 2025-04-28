using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarGamee
{
    public class CustomerGenerator
    {
        private static Random _random = new Random();
        private static List<Customer> _customers = new List<Customer>
    {
        new Customer("Джон", 50, 5),
        new Customer("Анна", 30, 10),
        new Customer("Мария", 70, 3),
        new Customer("Игорь", 100, 0),
    };

        public static Customer GenerateCustomer()
        {
            return _customers[_random.Next(_customers.Count)];
        }
    }
}