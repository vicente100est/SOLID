using System;

namespace S
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Beer
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public Beer(string Name, string Brand)
        {
            this.Name = Name;
            this.Brand = Brand;
        }
    }

    public class BeerDB
    {
        private Beer _beer;
        public BeerDB(Beer beer)
        {
            this._beer = beer;
        }
        public void Save()
        {
            Console.WriteLine($"Guardados {_beer.Name} y {_beer.Brand}");
        }
    }

    public class BeerRequest
    {
        private Beer _beer;
        public BeerRequest(Beer beer)
        {
            this._beer = beer;
        }
        public void Send()
        {
            Console.WriteLine($"Enviamos {_beer.Name} y {_beer.Brand}");
        }
    }
}
