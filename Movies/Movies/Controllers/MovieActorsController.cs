using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class MovieActorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
