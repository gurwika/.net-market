using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MRKT.Product.Launcher.Controllers
{
    public class ProductController : BaseController
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