﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter.Application.Requests.Meals
{
    public record GetMealsFromSpecifiedDateUntilNowRequest
    {
        public string UserID { get; set; }

        public string Date { get; set; }
    }
}
