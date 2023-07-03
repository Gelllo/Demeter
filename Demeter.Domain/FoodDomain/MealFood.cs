using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Domain.FoodDomain
{
    [Table("MealFoods")]
    public record MealFood
    {
        [Key]
        public int Id { get; set; }

        [Column("Meal", TypeName = "int"), Required]
        public int MealID { get; set; }

        public virtual Meal? Meal { get; set; }

        [Column("Food", TypeName = "int"), Required]
        public int FoodID { get; set; }

        public virtual Food? Food { get; set; }

        [Column("NrOfPortions", TypeName = "int"), Required]
        public int NrOfPortions { get; set; }
    }
}
