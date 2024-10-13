using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Domain.Models;
using Microsoft.AspNetCore.Mvc;



namespace DistributionCenter.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Package package)
        {
            if (package == null)
            { 
                return BadRequest("Package is null.");
            }

            var createdPackageId = await _packageService.Create(package);

            return CreatedAtAction(nameof(GetById), new { id = createdPackageId }, createdPackageId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var package = await _packageService.GetByIdAsync(id);
            if (package == null)
                return NotFound();

            return Ok(package);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var package = "Hey, this is a package";

            return Ok(package);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
