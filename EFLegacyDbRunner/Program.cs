using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EFLegacy.Data;
using static System.Console;

namespace EFLegacyDbRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Get all customers");
            using (var myContext = new LegacyDemoDbContext())
            {
                var allCustomers = myContext.Customers.OrderBy(c => c.CustomerName).Select(c => c);
                foreach (var customer in allCustomers)
                    WriteLine($"{customer.CustomerName} ({customer.CustomerEmail}) born {customer.Birthdate.ToShortDateString()}");

                var customersWithAddresses = myContext.Customers.Where(c => c.Addresses.Any()).Include(c => c.Addresses).Select(c => c);
                foreach (var customer in customersWithAddresses)
                    WriteLine($"{customer.CustomerName} from {customer.Addresses.First().City}, {customer.Addresses.First().State}");
            }

                //Keep it open for viewers
                ReadLine();
        }
    }
}
