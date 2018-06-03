using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }
        [Required]
        [Range(0, 5)]
        public int Rating {get;set;}

        public int CheeseId { get; set; }
        private static int nextId = 1;

        public Cheese()
        {
            CheeseId = nextId;
            nextId++;
        }

        public Cheese(string name, string description, CheeseType type, int rating)
        {
            Name = name;
            Description = description;
            Type = type;
            Rating = rating;
            CheeseId = nextId;
            nextId++;
        }
    }
}
