using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Application.Requests.Meals
{
   public record DeleteMealRequest
   {
       public int Id { get; set; }
   }
}
