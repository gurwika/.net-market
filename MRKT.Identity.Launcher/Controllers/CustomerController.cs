using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MRKT.Identity.Application.Addresses.Queries.GetCustomerAddressList;

namespace MRKT.Identity.Launcher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GetCustomerAddressListVM>> Get()
        {
            return Ok(await Mediator.Send(new GetCustomerAddressListQuery()));
        }
    }
}