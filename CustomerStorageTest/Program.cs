using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerStorage;

namespace CustomerStorageTest
{
    class Program
    {
        private const string _quitString = "quit";

        static void Main(string[] args)
        {
            ItemStore itemStore = new ItemStore();
            Customer testCust = new Customer("Jerry");
            itemStore.Store(testCust);
            string nameString = Console.ReadLine();
            while (nameString != _quitString)
            {
                testCust = new Customer(nameString);
                itemStore.Store(testCust);
                nameString = Console.ReadLine();
            }
        }
    }
}
