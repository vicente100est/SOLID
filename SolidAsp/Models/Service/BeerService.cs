using SolidAsp.Models.Db;
using SolidAsp.Models.ViewModels;
using SolidAsp.Utils;

namespace SolidAsp.Models.Service
{
    public class BeerService
    {
        public void Create(BeerViewModel beer)
        {
            var beerDb = new BeerDB();
            var log = new Log();

            beerDb.Save(beer);
            log.Save($"Se guardo una la cerveza {beer.GetInfo()}");
        }
    }
}
