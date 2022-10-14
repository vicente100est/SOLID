using System;
using System.Collections;
using System.Collections.Generic;

namespace O
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Abierto cerrado
        }

        public interface IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal GetPrice();
        }

        public class Water : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal GetPrice()
            {
                return Price * Invoice;
            }
        }

        public class Alcohol : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal Promo { get; set; }
            public decimal GetPrice()
            {
                return (Price * Invoice) - Promo;
            }
        }

        public class Sugary : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal Expiration { get; set; }
            public decimal GetPrice()
            {
                return (Price * Invoice) - Expiration;
            }
        }

        public class Energizing : IDrink
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public decimal Invoice { get; set; }
            public decimal GetPrice()
            {
                return Price * Invoice;
            }
        }

        public class Invoice
        {
            public decimal GetTotal(IEnumerable<IDrink> lstDrink)
            {
                decimal total = 0;
                foreach (var drink in lstDrink)
                {
                    total += drink.GetPrice();
                }
                return total;
            }
        }
    }
}
