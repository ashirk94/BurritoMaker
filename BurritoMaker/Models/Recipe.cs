using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BurritoMaker.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string BurritoName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Tortilla { get; set; }

        public string Sauce { get; set; }

        public string Rice { get; set; }

        public string Beans { get; set; }

        public string Meat { get; set; }

        public string Cheese { get; set; }

        public string Veg1 { get; set; }

        public string Veg2 { get; set; }
    }
}
