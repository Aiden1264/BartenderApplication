using Microsoft.AspNetCore.Mvc;
using BartenderApplication.Data;
using BartenderApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var menu = GetMenu();
            return View(menu);
        }

        // GET: /Cocktail/PlaceOrder
        public IActionResult PlaceOrder()
        {
            // Provide the menu as a SelectList to populate a dropdown in the view
            ViewBag.Cocktails = new SelectList(GetMenu());
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

            // If validation fails, repopulate the SelectList before returning the view
            ViewBag.Cocktails = new SelectList(GetMenu());
            return View(order);
        }

        private List<string> GetMenu()
        {
            // Centralized menu list so multiple actions can reuse it
            return new List<string>
            {
                "Mojito",
                "Old Fashioned",
                "Margarita",
                "Cosmopolitan",
                "Whiskey Sour"
            };
        }

        // GET: /Cocktail/OrderQueue
        public IActionResult OrderQueue()
        {
            var orders = _context.CocktailOrders.ToList();
            return View(orders);
        }
    }
}


