using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Domain.FoodDomain
{
    public record Meal
    {
        [Key]
        public int Id { get; set; }

        [Column("DateRegistered", TypeName = "DateTime"), Required]
        public DateTime DateRegistered { get; set; }

        [Column("MealType", TypeName = "nvarchar(200)"), Required]
        public string MealType { get; set; }

        [Column("UserID", TypeName = "nvarchar(200)"), Required]
        public string UserId { get; set; }

        public virtual List<Food>? Foods { get; set; } = new List<Food>();

    }

    public static class MealTypes
    {
        public static readonly string[] types = { "BREAKFAST", "LUNCH", "DINNER", "SNACK" };

        public static readonly string BREAKFAST = "BREAKFAST";

        public static readonly string LUNCH = "LUNCH";

        public static readonly string DINNER = "DINNER";

        public static readonly string SNACK = "SNACK";

    }
}
