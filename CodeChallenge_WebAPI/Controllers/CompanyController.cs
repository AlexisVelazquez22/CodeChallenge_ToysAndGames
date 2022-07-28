using DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CodeChallenge_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                return Ok(_companyService.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] CompanyRequest model)
        {
            try
            {
                var company = await _companyService.Add(model);
                return StatusCode(StatusCodes.Status201Created, company);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
