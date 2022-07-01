﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonalCar personelCar = new PersonalCar
            {
                Brand = "Bmw",
                Model = "3.20",
                HirePrice = 2500
            };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);

            Console.WriteLine("Personel Hiring Price: {0}", personelCar.HirePrice);
            Console.WriteLine("Special Offer Hiring Price: {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        private CarBase _carBase;
        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get { return _carBase.HirePrice -= _carBase.HirePrice*10/100 ; }
            set { }
        }
    }
}
