using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }
        // GET: MenuPizze
        public IActionResult Index()
        {
            using(PizzaContext context = new PizzaContext())
            {
                List<Pizza> pizzaList = context.Pizzas.ToList();
                return View(pizzaList);

            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizzaFound = context.Pizzas.Where(pizza => pizza.PizzaId == id).FirstOrDefault();

                if (pizzaFound == null)
                {
                    return NotFound($"La pizza con id {id} non è stato trovato");
                }
                else
                {
                    return View("Details", pizzaFound);
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", pizza);
            }

            using (PizzaContext context = new PizzaContext())
            {
                context.Pizzas.Add(pizza);
                context.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizza = context.Pizzas.Where(p => p.PizzaId == id).FirstOrDefault();

                if (pizza == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(pizza);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View(pizza);
            }

            using (PizzaContext context = new PizzaContext())
            {
                Pizza editPizza=context.Pizzas.Where(p => p.PizzaId == id).FirstOrDefault();    
                if(editPizza == null)
                {
                    return NotFound();
                }


                editPizza.Name = pizza.Name;
                editPizza.Img = pizza.Img;
                editPizza.Description=pizza.Description;
                editPizza.Price = pizza.Price;
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza pizza = context.Pizzas.Where(pizza => pizza.PizzaId == id).FirstOrDefault();

                if(pizza == null)
                {
                    return NotFound();
                }

                context.Pizzas.Remove(pizza);   
                context.SaveChanges();
                return RedirectToAction("Index");

            }

        }


    }
}
