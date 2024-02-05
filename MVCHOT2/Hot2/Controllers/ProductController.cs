using Hot2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hot2.Controllers
{
    public class ProductController : Controller
    {



        // Connects to the database
        private SalesOrderContext Context { get; set; }

        // This Constructor accepts the DB Context objects thats enabled by DI
        // Accepts a Product context that holds a list of Products Info
        public ProductController(SalesOrderContext ctx)
        {
            Context = ctx;
        }


        public IActionResult List()
        {
            // Sending list of both Products and Category
            var products = Context.Products.Include(c => c.Category).OrderBy(m => m.ProductName).ToList();

            return View(products);
        }




        // ++++++ ADDING A PRODUCT ++++++ \\
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add New Product";

            // Puts the Categories of the Products in a list to be able to be edited
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();

            return View("AddEdit", new Product());
        }
        // ++++++ ADDING A CONTACT ++++++ \\




        // ------ EDITING A PRODUCT ------ \\
        [HttpGet]
        public IActionResult AddEdit(int id)
        {

            ViewBag.Action = "Edit Product";

            // Puts the Categories back in after the load to be added and show Validation Errors
            ViewBag.Categories = Context.Categories.OrderBy(c => c.CategoryName).ToList();

            //LINQ Query to find the Record with the given id - PK Search
            var products = Context.Products.Find(id);
            return View(products); // sends the product to the edit page to auto fill the info
        }
        // ------ EDITING A PRODUCT ------ \\




        // xxxxxx DELETE A PRODUCT xxxxxx \\
        [HttpGet]
        public IActionResult Delete(int id) // id parameter is sent from the url
        {
            ViewBag.Action = "Delete Product";

            var products = Context.Products.Find(id);
            return View(products); // sends the Product to the Delete page to auto fill the info
        }
        // xxxxxx DELETE A PRODUCT xxxxxx \\




        // ++++++ ADDING A PRODUCT ++++++ \\
        [HttpPost]
        public IActionResult AddEdit(Product products)
        {
            if (ModelState.IsValid)
            {
                // Either add a new Product or edit a Product
                if (products.ProductID == 0)
                {
                    Context.Products.Add(products);
                }
                else
                {
                    Context.Products.Update(products);
                }

                Context.SaveChanges();

                return RedirectToAction("List", "Product");
            }
            else
            {
                // Show our Validation errors
                ViewBag.Action = (products.ProductID == 0) ? "Add" : "Edit";

                // Puts the Categories back in after the load to be added and show Validation Errors
                ViewBag.Categories = Context.Categories.OrderBy(g => g.CategoryName).ToList();

                return View(products);
            }
        }
        // ++++++ ADDING A PRODUCT ++++++ \\




        // xxxxxx DELETE A PRODUCT xxxxxx \\
        [HttpPost]
        public IActionResult Delete(Product products)
        {
            ViewBag.Action = "Delete Product";

            Context.Products.Remove(products);
            Context.SaveChanges();

            return RedirectToAction("List", "Product");
        }
        // xxxxxx DELETE A PRODUCT xxxxxx \\



    }
}
