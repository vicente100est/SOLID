using SolidAsp.Models.ViewModels;

namespace SolidAsp.Models.Db
{
    public class BeerDB
    {
        public void Save(BeerViewModel beer)
        {
            System.Console.WriteLine($"Guardado {beer.Name}...");
        }
    }
}
