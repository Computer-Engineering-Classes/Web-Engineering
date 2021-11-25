using Aula2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class PersonController : Controller
    {
        // GET: PeopleController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeopleController/Create
        [HttpPost]
        public ActionResult Create(Person newPerson)
        {
            if(ModelState.IsValid)
            {
                // process the information
                // transfers information to another action
                TempData["values"] = $"{newPerson.Name}, {newPerson.Age} anos, nascidx a {newPerson.BirthDay} Email: {newPerson.Email}";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(collection["name"]))
        //        {
        //            ModelState.AddModelError("name", "Name required");
        //        }
        //        if (string.IsNullOrEmpty(collection["age"]))
        //        {
        //            ModelState.AddModelError("age", "Age required");
        //        }
        //        else
        //        {
        //            int aux;
        //            try
        //            {
        //                aux = int.Parse(collection["age"]);
        //                if (aux < 18 || aux > 100)
        //                {
        //                    ModelState.AddModelError("age", "Age should be between 18 and 100");
        //                }
        //            }
        //            catch (FormatException)
        //            {
        //                ModelState.AddModelError("age", "Must indicate an integer value");
        //            }
        //        }
        //        if (ModelState.IsValid)
        //        {
        //            // process the information
        //            // transfers information to another action
        //            TempData["values"] = $"{collection["name"]} [{collection["age"]}]";
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            // if model has errors, it returns the form view and shows them
        //            return View();
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PeopleController/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
