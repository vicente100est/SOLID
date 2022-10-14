using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SolidAsp.Models.Service;
using SolidAsp.Models.ViewModels;

namespace SolidAsp.Controllers
{
    public class BeerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(BeerViewModel beer)
        {
            if (!ModelState.IsValid)
            {
                return View(beer);
            }

            var beerService = new BeerService();
            beerService.Create(beer);

            return Ok();
        }
    }
}
