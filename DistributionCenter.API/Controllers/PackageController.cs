using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Domain.Models;
using DistributionCenter.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DistributionCenter.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;

        public PackageController(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Package package)
        {
            if (package == null)
            {
                return BadRequest("Package is null.");
            }

            var result = await _packageRepository.CreatePackageAsync(package);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id, string type)
        {
            var package = await _packageRepository.GetPackageAsync(id, type);
            if (package == null)
                return NotFound();

            return Ok(package);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _packageRepository.GetPackagesAsync();
            return Ok(packages);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Package package)
        {
            // You can implement an update method here.
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, string type)
        {
            var result = await _packageRepository.DeletePackageAsync(id, type);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }

}
