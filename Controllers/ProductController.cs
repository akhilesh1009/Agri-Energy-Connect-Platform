//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Humanizer;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
//using Microsoft.EntityFrameworkCore;
//using ST10281011_PROG7311_POE_PART_2.Data;
//using ST10281011_PROG7311_POE_PART_2.Models;

//namespace ST10281011_PROG7311_POE_PART_2.Controllers
//{
//    public class ProductController : Controller
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            _context = context;
//            _userManager = userManager;
//            _roleManager = roleManager;
//        }


//        [Authorize(Roles = "Employee")]
//        public IActionResult AddFarmerProfile()
//        {
//            return View();
//        }

//        //Fixing the invalid login attempt assisted by ChatGPT (OpenAI, 2025). See README File for Details.
//        //OpenAI ChatGpt. 2025.
//        //<https://chatgpt.com/share/68232d50-0be4-800d-b0f4-421cc236ce20>

//        //Method for creating the farmer profile and assiging it the 'Farmer' role
//        [HttpPost]
//        [Authorize(Roles = "Employee")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> AddFarmerProfile(AddFarmerViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                //create the user and adds it to the AspNetUsers Table
//                var farmer = new IdentityUser
//                {
//                    UserName = model.Email,
//                    Email = model.Email,
//                    PhoneNumber = model.PhoneNumber,
//                    EmailConfirmed = true
//                };

//                var result = await _userManager.CreateAsync(farmer, model.Password);

//                // Assigns "Farmer" role after successfully creating the user
//                if (result.Succeeded)
//                {
//                    await _userManager.AddToRoleAsync(farmer, "Farmer");
//                    return RedirectToAction(nameof(Index));
//                }
//            }
//            return View(model);
//        }

//        //Source: Haritha Computers & Technology (2020) MVC Search Filter Records Between Two Dates ASP.NET Core Razor Pages Database
//        //Avaliable At: <https://www.youtube.com/watch?v=Bg59HwCO3yQ> [Accessed 12 May 2025]

//        //Filtering by DateRange Logic assisted by ChatGPT (OpenAI, 2025). See README File for Details.
//        //OpenAI ChatGpt. 2025.
//        //<https://chatgpt.com/share/68232d50-0be4-800d-b0f4-421cc236ce20>

//        //Method for diplaying all the products, and only giving 'Employess' permissions to filter the products
//        [Authorize(Roles = "Employee, Farmer")]
//        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, ProductCategories? productType)
//        {
//            var user = await _userManager.GetUserAsync(User);
//            var isEmployee = await _userManager.IsInRoleAsync(user, "Employee");

//            var product = _context.Products.AsQueryable();

//            if (isEmployee)
//            {
//                //Filtering by Date Range for Production Date  
//                if (startDate.HasValue)
//                {
//                    product = product.Where(p => p.ProductionDate >= startDate.Value);
//                }

//                if (endDate.HasValue)
//                {
//                    product = product.Where(p => p.ProductionDate <= endDate.Value);
//                }

//                //Filtering by Product Type
//                if (productType.HasValue)
//                {
//                    product = product.Where(p => p.ProductType == productType.Value);
//                }
//            }
//            return View(await product.ToListAsync());
//        }



//        [Authorize(Roles = "Farmer")]
//        public IActionResult CreateProduct()
//        {
//            return View();
//        }


//        //Method that allows only 'Farmers' to create/add new products
//        [HttpPost]
//        [Authorize(Roles = "Farmer")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> CreateProduct(Product product)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(product);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(product);
//        }




//        //Method that shows the product details for a specific product
//        [Authorize(Roles = "Employee, Farmer")]
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Products
//                .FirstOrDefaultAsync(m => m.ProductId == id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            return View(product);
//        }


//        [Authorize(Roles = "Farmer")]
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Products.FindAsync(id);
//            if (product == null)
//            {
//                return NotFound();
//            }
//            return View(product);
//        }

//        //Method that allows only 'Farmers' to edit the products they added
//        [HttpPost]
//        [Authorize(Roles = "Farmer")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,ProductType,ProductionDate,Price,Quantity,UnitOfMeasure")] Product product)
//        {
//            if (id != product.ProductId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(product);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductExists(product.ProductId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(product);
//        }

//        //Method that allows only 'Farmers' to delete the products they added
//        [Authorize(Roles = "Farmer")]
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var product = await _context.Products
//                .FirstOrDefaultAsync(m => m.ProductId == id);
//            if (product == null)
//            {
//                return NotFound();
//            }

//            return View(product);
//        }

//        //Method that allows only 'Farmers' to confirem the delete for the product
//        [HttpPost, ActionName("Delete")]
//        [Authorize(Roles = "Farmer")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            if (product != null)
//            {
//                _context.Products.Remove(product);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductExists(int id)
//        {
//            return _context.Products.Any(e => e.ProductId == id);
//        }

//        //Method to get product image based on product name
//        public string GetProductImage(string productName, ProductCategories productType)
//        {
//            if (string.IsNullOrEmpty(productName))
//                return null;

//            string NameofProduct = productName.Trim().ToLower().Replace(" ", "");

//            var productImageMap = new Dictionary<string, string>
//            {
//                // Fruits
//                {"apple", "/images/apple.jpeg"},
//                {"apples", "/images/apple.jpeg"},
//                {"orange", "/images/orange.jpeg"},
//                {"oranges", "/images/orange.jpeg"},
//                {"grape", "/images/grape.jpeg"},
//                {"grapes", "/images/grape.jpeg"},
//                {"pear", "/images/pear.jpeg"},
//                {"pears", "/images/pear.jpeg"},
//                {"peach", "/images/peach.jpeg"},
//                {"peaches", "/images/peach.jpeg"},
//                {"mango", "/images/mango.jpeg"},
//                {"mangoes", "/images/mango.jpeg"},

//                // Vegetables
//                {"tomato", "/images/tomato.jpeg"},
//                {"tomatoes", "/images/tomato.jpeg"},
//                {"carrot", "/images/carrot.jpeg"},
//                {"carrots", "/images/carrot.jpeg"},
//                {"potato", "/images/potato.jpeg"},
//                {"potatoes", "/images/potato.jpeg"},
//                {"onion", "/images/onion.jpeg"},
//                {"onions", "/images/onion.jpeg"},

//                // Grains
//                {"wheat", "/images/wheat.jpeg"},
//                {"barley", "/images/barley.jpeg"},

//                // Dairy
//                {"milk", "/images/milk.jpeg"},
//                {"cheese", "/images/cheese.jpeg"},

//                // Livestock
//                {"beef", "/images/beef.jpeg"},
//                {"pork", "/images/pork.jpeg"},
//                {"lamb", "/images/lamb.jpeg"},

//                // Poultry
//                {"chicken", "/images/chicken.jpeg"},
//                {"eggs", "/images/eggs.jpeg"},

//                // Seeds
//                {"sunflowerseeds", "/images/sunflowerseeds.jpeg"},
//                {"pumpkinseeds", "/images/pumpkinseeds.jpeg"},
//            };

//            // Try to find exact match first
//            if (productImageMap.ContainsKey(NameofProduct))
//            {
//                return productImageMap[NameofProduct];
//            }

//            // Try partial matching for compound names
//            foreach (var kvp in productImageMap)
//            {
//                if (NameofProduct.Contains(kvp.Key) || kvp.Key.Contains(NameofProduct))
//                {
//                    return kvp.Value;
//                }
//            }

//            return null;
//        }

//        //Method to get category icon
//        public string GetCategoryIcon(ProductCategories productType)
//        {
//            return productType switch
//            {
//                ProductCategories.Fruits => "fas fa-apple-alt",
//                ProductCategories.Vegetables => "fas fa-carrot",
//                ProductCategories.Grain => "fas fa-seedling",
//                ProductCategories.Dairy => "fas fa-cheese",
//                ProductCategories.LiveStock => "fa-solid fa-cow",
//                ProductCategories.Poultry => "fas fa-egg",
//                ProductCategories.Seeds => "fas fa-seed",
//                _ => "fas fa-leaf"
//            };
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using ST10281011_PROG7311_POE_PART_2.Data;
using ST10281011_PROG7311_POE_PART_2.Models;

namespace ST10281011_PROG7311_POE_PART_2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult AddFarmerProfile()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Employee")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmerProfile(AddFarmerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var farmer = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(farmer, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(farmer, "Farmer");
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [Authorize(Roles = "Employee, Farmer")]
        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, ProductCategories? productType)
        {
            var user = await _userManager.GetUserAsync(User);
            var isEmployee = await _userManager.IsInRoleAsync(user, "Employee");

            var product = _context.Products.AsQueryable();

            if (isEmployee)
            {
                if (startDate.HasValue)
                {
                    product = product.Where(p => p.ProductionDate >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    product = product.Where(p => p.ProductionDate <= endDate.Value);
                }

                if (productType.HasValue)
                {
                    product = product.Where(p => p.ProductType == productType.Value);
                }
            }
            return View(await product.ToListAsync());
        }

        [Authorize(Roles = "Farmer")]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // Updated Details method with image logic
        [Authorize(Roles = "Employee, Farmer")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            // Set image data in ViewBag
            ViewBag.ProductImagePath = GetProductImage(product.Name, product.ProductType);
            ViewBag.CategoryIcon = GetCategoryIcon(product.ProductType);

            return View(product);
        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Description,ProductType,ProductionDate,Price,Quantity,UnitOfMeasure")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [Authorize(Roles = "Farmer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Farmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }


        // Method to get product image based on product name
        private string GetProductImage(string productName, ProductCategories productType)
        {
            if (string.IsNullOrEmpty(productName))
                return null;

            string NameofProduct = productName.Trim().ToLower().Replace(" ", "");

            var productImages = new Dictionary<string, string>
            {
                // Fruits
                {"apple", "/images/apple.jpeg"},
                {"apples", "/images/apple.jpeg"},
                {"orange", "/images/orange.jpeg"},
                {"oranges", "/images/orange.jpeg"},
                {"grape", "/images/grape.jpeg"},
                {"grapes", "/images/grape.jpeg"},
                {"pear", "/images/pear.jpeg"},
                {"pears", "/images/pear.jpeg"},
                {"peach", "/images/peach.jpeg"},
                {"peaches", "/images/peach.jpeg"},
                {"mango", "/images/mango.jpeg"},
                {"mangoes", "/images/mango.jpeg"},

                // Vegetables
                {"tomato", "/images/tomato.jpeg"},
                {"tomatoes", "/images/tomato.jpeg"},
                {"carrot", "/images/carrot.jpeg"},
                {"carrots", "/images/carrot.jpeg"},
                {"potato", "/images/potato.jpeg"},
                {"potatoes", "/images/potato.jpeg"},
                {"onion", "/images/onion.jpeg"},
                {"onions", "/images/onion.jpeg"},

                // Grains
                {"wheat", "/images/wheat.jpeg"},
                {"barley", "/images/barley.jpeg"},

                // Dairy
                {"milk", "/images/milk.jpeg"},
                {"cheese", "/images/cheese.jpeg"},

                // Livestock
                {"beef", "/images/beef.jpeg"},
                {"pork", "/images/pork.jpeg"},
                {"lamb", "/images/lamb.jpeg"},

                // Poultry
                {"chicken", "/images/chicken.jpeg"},
                {"eggs", "/images/eggs.jpeg"},

                // Seeds
                {"sunflowerseeds", "/images/sunflowerseeds.jpeg"},
                {"pumpkinseeds", "/images/pumpkinseeds.jpeg"},
            };

            // Try to find exact match first
            if (productImages.ContainsKey(NameofProduct))
            {
                return productImages[NameofProduct];
            }

            foreach (var value in productImages)
            {
                if (NameofProduct.Contains(value.Key) || value.Key.Contains(NameofProduct))
                {
                    return value.Value;
                }
            }

            return null;
        }

        //Method to get category icon
        private string GetCategoryIcon(ProductCategories productType)
        {
            return productType switch
            {
                ProductCategories.Fruits => "fas fa-apple-alt",
                ProductCategories.Vegetables => "fas fa-carrot",
                ProductCategories.Grain => "fas fa-seedling",
                ProductCategories.Dairy => "fas fa-cheese",
                ProductCategories.LiveStock => "fa-solid fa-cow",
                ProductCategories.Poultry => "fas fa-egg",
                ProductCategories.Seeds => "fas fa-seed",
                _ => "fas fa-leaf"
            };
        }

    }
}