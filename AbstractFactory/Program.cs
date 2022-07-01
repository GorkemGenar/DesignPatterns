using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();

            Console.ReadLine();
        }
    }

    public abstract class Logging
    {
        public abstract void Log();
    }

    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged by Log4NetLogger");
        }
    }

    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Logged by NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache();
    }

    public class MemCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached by MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache()
        {
            Console.WriteLine("Cached by RedisCache");
        }
    }

    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }
    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory _crossCuttingConcernsFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _crossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _crossCuttingConcernsFactory.CreateLogger();
            _caching = _crossCuttingConcernsFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log();
            _caching.Cache();
            Console.WriteLine("Products listed.");
        }
    }
}
