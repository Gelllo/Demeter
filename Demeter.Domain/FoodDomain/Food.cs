using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Domain.FoodDomain
{
    public record Food
    {
        [Key]
        public int Id { get; set; }

        [Column("Title", TypeName = "nvarchar(200)"), Required]
        public string Title { get; set; }

        [Column("Image", TypeName = "nvarchar(200)"), Required]
        public string Image { get; set; }

        [Column("FoodType", TypeName = "nvarchar(200)"), Required]
        public string FoodType { get; set; }

        [Column("Nutrients", TypeName = "nvarchar(200)"), Required]
        public List<Nutrient> Nutrients { get; set; } = new List<Nutrient>();

        [Column("NrOfPortions", TypeName = "int")]
        public int NrOfPortions{ get; set; }

        [Column("MealId", TypeName = "int")]
        public int MealID { get; set; }
        public virtual Meal Meal { get; set; }

    }

    public static class FoodTypes
    {
        public static readonly string[] types = { "RECIPE", "GROCERY PRODUCT"};

        public static readonly string RECIPE = "RECIPE";

        public static readonly string GROCERY_PRODUCT = "GROCERY PRODUCT";

    }
}
