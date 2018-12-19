using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Addresses")]
    public class AddressesController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        
        [HttpPost("[action]")]
        public IActionResult AddAddress([FromBody]Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _addressRepository.AddAddress(address);
            return new JsonResult(address.AddressId);
        }
    }
}