﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfttf.TaskManagement.UI.Controllers
{
    public class UserTaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
