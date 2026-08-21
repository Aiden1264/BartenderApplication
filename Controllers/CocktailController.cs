using Microsoft.AspNetCore.Mvc;
using BartenderApplication.Data;
using BartenderApplication.Models;

namespace BartenderApplication.Controllers
{
    public class CocktailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CocktailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Cocktail/Menu
        public IActionResult Menu()
        {
            // Later you can replace this with a real menu table
            var menu = new List<string>
            {
                "Mojito",
                "Old Fashioned",
                "Margarita",
                "Cosmopolitan",
                "Whiskey Sour"
            };

            return View(menu);
        }

        // GET: /Cocktail/PlaceOrder
        public IActionResult PlaceOrder()
        {
            return View();
        }

        // POST: /Cocktail/PlaceOrder
        [HttpPost]
        public IActionResult PlaceOrder(CocktailOrder order)
        {
            if (ModelState.IsValid)
            {
                _context.CocktailOrders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("OrderQueue");
            }

            return View(order);
        }

        // GET: /Cocktail/OrderQueue
        public IActionResult OrderQueue()
        {
            var orders = _context.CocktailOrders.ToList();
            return View(orders);
        }
    }
}

