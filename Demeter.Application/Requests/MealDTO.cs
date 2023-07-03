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
    public record MealDTO
    {
        public int Id { get; set; }
        public string? DateRegistered { get; set; }
        public string MealType { get; set; }
        public string UserId { get; set; }
        public virtual List<FoodDTO>? Foods { get; set; }
    }
}
