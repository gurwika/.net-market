﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MRKT.Identity.Launcher.Controllers
{
    public class AddressController : BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] {
                "Freezing", "Bracing"
            };
        }
    }
}