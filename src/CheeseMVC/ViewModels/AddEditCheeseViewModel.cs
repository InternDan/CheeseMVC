using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel
    {
        public int cheeseId;

        public AddEditCheeseViewModel(Cheese cheese)
        {
            Name = cheese.Name;
            Description = cheese.Description;
            Type = cheese.Type;
            Rating = cheese.Rating;

            cheeseId = cheese.CheeseId;
        }
    }
}
