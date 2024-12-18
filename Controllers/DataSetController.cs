using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASPInventory.Data;
using ASPInventory.Models;

namespace ASPInventory.Controllers
{
    public class DataSetController : Controller
    {
        /// <summary>
        /// Application DB Context Object
        /// </summary>
        /// <returns></returns>

        private readonly ApplicationDbContext _db;

        /// <summary>
        /// Constructor to implement ApplicationDbContext
        /// </summary>
        /// <returns></returns>

        public DataSetController(ApplicationDbContext db)
        {
            _db = db; //Getting the ApplicationDbContext that has already been registered in application
        }

        public IActionResult Index(string searchString)
        {
            // Заполнение ViewBag.From_TO
            var toList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Саяногорск" },
                new SelectListItem { Value = "2", Text = "Копьево" },
                new SelectListItem { Value = "3", Text = "Аскиз" },
                new SelectListItem { Value = "4", Text = "Бея" },
                new SelectListItem { Value = "5", Text = "Абакан" },
                new SelectListItem { Value = "6", Text = "Таштып" },
                new SelectListItem { Value = "7", Text = "Сорск" },
                new SelectListItem { Value = "8", Text = "Абаза" },
                new SelectListItem { Value = "9", Text = "Черногорск" },
                new SelectListItem { Value = "10", Text = "Белый Яр" },
                new SelectListItem { Value = "11", Text = "Боград" },
                new SelectListItem { Value = "12", Text = "Шира" },
                new SelectListItem { Value = "13", Text = "Усть-Абакан" }
            };

            ViewBag.From_TO = toList;

            // Заполнение ViewBag.Id_StorageLocation
            var placelist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Склад - 1 этаж" },
                new SelectListItem { Value = "2", Text = "Заправочная" },
                new SelectListItem { Value = "3", Text = "Склад - серверная" },
                new SelectListItem { Value = "4", Text = "В сервисе" }
            };

            ViewBag.Id_StorageLocation = placelist;

            var statuslist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Неизвестно" },
                new SelectListItem { Value = "2", Text = "Списание" },
                new SelectListItem { Value = "3", Text = "Рабочий" },
                new SelectListItem { Value = "4", Text = "рабочий (старый)" },
                new SelectListItem { Value = "5", Text = "В сервисе" },
                new SelectListItem { Value = "6", Text = "Отдан" }
            };

            ViewBag.Id_Condition = statuslist;

            // Получите все категории из базы данных
            var categories = _db.Categories.AsQueryable();

            // Если есть строка поиска, отфильтруйте категории
            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(c => c.IN.ToString().Contains(searchString)); // Предполагается, что IN - это строка
            }

            // Преобразуйте в список и передайте в представление
            var objCategoryList = categories.ToList(); // Примените фильтрацию и преобразуйте в список

            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {
            // Заполнение ViewBag.From_TO
            var toList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Саяногорск" },
                new SelectListItem { Value = "2", Text = "Копьево" },
                new SelectListItem { Value = "3", Text = "Аскиз" },
                new SelectListItem { Value = "4", Text = "Бея" },
                new SelectListItem { Value = "5", Text = "Абакан" },
                new SelectListItem { Value = "6", Text = "Таштып" },
                new SelectListItem { Value = "7", Text = "Сорск" },
                new SelectListItem { Value = "8", Text = "Абаза" },
                new SelectListItem { Value = "9", Text = "Черногорск" },
                new SelectListItem { Value = "10", Text = "Белый Яр" },
                new SelectListItem { Value = "11", Text = "Боград" },
                new SelectListItem { Value = "12", Text = "Шира" },
                new SelectListItem { Value = "13", Text = "Усть-Абакан" }
            };

            ViewBag.From_TO = toList;

            // Заполнение ViewBag.From_TO
            var placelist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Склад - 1 этаж" },
                new SelectListItem { Value = "2", Text = "Заправочная" },
                new SelectListItem { Value = "3", Text = "Склад - серверная" },
                new SelectListItem { Value = "4", Text = "В сервисе" }
            };

            ViewBag.Id_StorageLocation = placelist;

            var statuslist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Неизвестно" },
                new SelectListItem { Value = "2", Text = "Списание" },
                new SelectListItem { Value = "3", Text = "Рабочий" },
                new SelectListItem { Value = "4", Text = "рабочий (старый)" },
                new SelectListItem { Value = "5", Text = "В сервисе" },
                new SelectListItem { Value = "6", Text = "Отдан" }
            };

            ViewBag.Id_Condition = statuslist;

            return View();
        }

        //Post
        // Called when we post the create category form
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult Create(DataSet obj)
        {
            //Custom Validations
            if (obj.IN == obj.Id)
            {
                ModelState.AddModelError("Name", "The Name and Displayorder cannot be same");
            }

            //Validate the object received
            if (ModelState.IsValid)
            {

                //Add the category object to database
                _db.Categories.Add(obj);
                _db.SaveChanges(); // Saved to database

                //Using TempData for alerts
                TempData["success"] = "Category Created Successfully!";
                //After saving data redirect to index action of category
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }



        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Find the category in table with the specified id
            var categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            // Заполнение ViewBag.From_TO
            var toList = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Саяногорск" },
                new SelectListItem { Value = "2", Text = "Копьево" },
                new SelectListItem { Value = "3", Text = "Аскиз" },
                new SelectListItem { Value = "4", Text = "Бея" },
                new SelectListItem { Value = "5", Text = "Абакан" },
                new SelectListItem { Value = "6", Text = "Таштып" },
                new SelectListItem { Value = "7", Text = "Сорск" },
                new SelectListItem { Value = "8", Text = "Абаза" },
                new SelectListItem { Value = "9", Text = "Черногорск" },
                new SelectListItem { Value = "10", Text = "Белый Яр" },
                new SelectListItem { Value = "11", Text = "Боград" },
                new SelectListItem { Value = "12", Text = "Шира" },
                new SelectListItem { Value = "13", Text = "Усть-Абакан" }
            };

            ViewBag.From_TO = toList;

            // Заполнение ViewBag.Id_StorageLocation
            var placelist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Склад - 1 этаж" },
                new SelectListItem { Value = "2", Text = "Заправочная" },
                new SelectListItem { Value = "3", Text = "Склад - серверная" },
                new SelectListItem { Value = "4", Text = "В сервисе" }
            };

            ViewBag.Id_StorageLocation = placelist;

            var statuslist = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Неизвестно" },
                new SelectListItem { Value = "2", Text = "Списание" },
                new SelectListItem { Value = "3", Text = "Рабочий" },
                new SelectListItem { Value = "4", Text = "рабочий (старый)" },
                new SelectListItem { Value = "5", Text = "В сервисе" },
                new SelectListItem { Value = "6", Text = "Отдан" }
            };

            ViewBag.Id_Condition = statuslist;

            return View(categoryFromDB);
        }

        //Post
        // Called when we post the edit category form
        [HttpPost]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult Edit(DataSet obj)
        {
            //Custom Validations
            if (obj.IN == obj.Id)
            {
                ModelState.AddModelError("Name", "The Name and Displayorder cannot be same");
            }

            //Validate the object received
            if (ModelState.IsValid)
            {

                //Update the category object 
                _db.Categories.Update(obj);
                _db.SaveChanges(); // Saved to database
                                   //Using TempData for alerts
                TempData["success"] = "Category Edited Successfully!";
                //After saving data redirect to index action of category
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Find the category in table with the specified id
            //var categoryFromDB = _db.Categories.SingleOrDefault(c => c.Id == id);
            var categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //Post

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Helps in preventing cross site request forgery attacks
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }


            //Update the category object 
            _db.Categories.Remove(obj);
            _db.SaveChanges(); // Saved to database
                               //Using TempData for alerts
            TempData["success"] = "Category Deleted Successfully!";

            //After saving data redirect to index action of category
            return RedirectToAction("Index");

        }

    }
}