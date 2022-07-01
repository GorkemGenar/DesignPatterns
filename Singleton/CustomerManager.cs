using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class CustomerManager
    {
        private static CustomerManager _customerManager;

        static object _lockedObject = new object();

        private CustomerManager()
        {
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (_lockedObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }

            return _customerManager;
        }

        public void Add()
        {
            Console.WriteLine("Added.");
        }
    }
}
