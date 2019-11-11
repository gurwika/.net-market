using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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