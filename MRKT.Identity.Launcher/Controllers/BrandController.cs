using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRKT.Identity.Application.Brands.Commands.GetBrandsList;
using MRKT.Identity.Application.Customers.Commands.CreateCustomer;

namespace MRKT.Identity.Launcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetBrandsListVM>> GetAll()
        {
            return Ok(await Mediator.Send(new GetBrandsListQuery()));
        }
    }
}