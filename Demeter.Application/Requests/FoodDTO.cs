using Demeter.Domain.FoodDomain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Application.Requests
{
    public record FoodDTO
    {
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? FoodType { get; set; }
        public int? NrOfPortions { get; set; }
        public List<Nutrient>? Nutrients { get; set; } = new List<Nutrient>();
    }
}
