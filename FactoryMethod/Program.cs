using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new GaLogger();
        }
    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new AbcLogger();
        }
    }

    public interface ILogger
    {
        void Log();
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public class GaLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged by Ga logger.");
        }
    }

    public class AbcLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged by Abc logger.");
        }
    }

    public class CustomerManager
    {
        public void Save()
        {
            Console.WriteLine("Saved.");
            ILogger logger = new LoggerFactory2().CreateLogger();
            logger.Log();
        }
    }

}
