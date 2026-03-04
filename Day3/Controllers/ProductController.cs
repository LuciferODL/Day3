using Microsoft.AspNetCore.Mvc;
using Day3.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Day3.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Iphone 14 Pro Max", Price = 30000000, Description = "Dien thoai cao cap cua Apple" },
            new Product { Id = 2, Name = "Samsung Galaxy S23 Ultra", Price = 25000000, Description = "Dien thoai cao cap cua Samsung" },
            new Product { Id = 3, Name = "Xiaomi Mi 13 Pro", Price = 20000000, Description = "Dien thoai cao cap cua Xiaomi" },
        };
        public IActionResult Index()
        {
            return View(products);
        }
        //Hien thi chi tiet sp
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Hien thi form tao sp moi 
        public IActionResult Create()
        {
            return View();
        }
        //Xu li DL tu form tao sp moi
        [HttpPost]
        public IActionResult Create(Product newProduct)
        {
            products.Add(newProduct);
            return RedirectToAction("Index"); //goi lai ds ten index 
        }
        //Hien thi form chinh sua SP
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Xu li DL tu Form chinh sua SP
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == updatedProduct.Id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            return RedirectToAction("Index");
        }
    }
}