﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAggregation.Controllers
{
    public interface IAggregationController
    {
        Task<IActionResult> GetData(string city, string query);
    }
}