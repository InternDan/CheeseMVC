using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using System.Collections.Generic;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new cheese to my existing cheeses
                Cheese newCheese = addCheeseViewModel.CreateCheese();
                CheeseData.Add(newCheese);
                return Redirect("/Cheese");
            }

            return View(addCheeseViewModel);
        }

        [HttpGet]
        [Route("/Cheese/Edit")]
        public IActionResult AddEditCheeseViewModel(int cheeseId)
        {
            Cheese cheese = CheeseData.GetById(cheeseId);
            AddEditCheeseViewModel cheeseToEdit = new AddEditCheeseViewModel(cheese);
            cheeseToEdit.cheeseId = cheeseId;
            return View(cheeseToEdit);
        }

        [HttpPost]
        [Route("/Cheese/Edit")]
        public IActionResult AddEditCheeseViewModel(AddEditCheeseViewModel model)
        {
            var cheeses = CheeseData.GetAll();
            cheeses[model.cheeseId].Name = model.Name;
            cheeses[model.cheeseId].Description = model.Description;
            cheeses[model.cheeseId].Type = model.Type;
            cheeses[model.cheeseId].Rating = model.Rating;
            return Redirect("Index");
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Cheeses";
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] cheeseIds)
        {
            foreach (int cheeseId in cheeseIds)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/");
        }
    }
}
