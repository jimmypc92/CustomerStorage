using System;
using System.Collections.Generic;

namespace CustomerStorage
{
    public class Customer : IStorableDict
    {
        private string _name;
        private DateTime _firstVisit;

        public Customer()
        {
        }

        public Customer(string name)
        {
            _name = name;
        }

        public Customer(string name, DateTime firstVisit)
        {
            _name = name;
            _firstVisit = firstVisit;
        }

        public string Name { get; set; }

        public DateTime FirstVisit { get; set; }

        /// <summary>
        /// Implementation of IStorableDict
        /// </summary>
        /// <returns>Key Value representation of Customer</returns>
        public Dictionary<string, string> ToStorable()
        {
            Dictionary<string, string> keyValueStore = new Dictionary<string, string>();
            if(_name != null)
            {
                keyValueStore["Name"] = _name;
            }
            if (_firstVisit != null)
            {
                keyValueStore["FirstVisit"] = FirstVisit.ToString();
            }
            return keyValueStore;
        }

        public string StorableTypeName()
        {
            return "Customer";
        }
    }
}
