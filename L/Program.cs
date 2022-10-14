using System;
using System.Globalization;

namespace L
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SaleWithTaxes sale = new LocalSale(100, "Mariana", 0.16m);
            sale.CalculateTaxes();
            sale.Generate();

            AbstractSale sale2 = new ForeignSale(200, "Vicente");
            sale.Generate();
        }

        public abstract class AbstractSale //T
        {
            protected decimal amout;
            protected string customer;

            public abstract void Generate();
        }

        public abstract class SaleWithTaxes : AbstractSale
        {
            protected decimal taxes;

            public abstract void CalculateTaxes();
        }

        public class LocalSale : SaleWithTaxes //S
        {
            public LocalSale(decimal amountm, string customer, decimal taxes)
            {
                this.amout = amout;
                this.customer = customer;
                this.taxes = taxes;
            }
            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }

            public override void CalculateTaxes()
            {
                Console.WriteLine("Se calculan los impuestos");
            }
        }

        public class ForeignSale : AbstractSale //S
        {
            public ForeignSale(decimal amountm, string customer)
            {
                this.amout = amout;
                this.customer = customer;
            }

            public override void Generate()
            {
                Console.WriteLine("Se genera la venta");
            }
        }
    }
}
