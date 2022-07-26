using DB.Models;
using DB.Context;
using DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CodeChallenge_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICompanyService _companyService;

        public HomeController(IProductService productService, ICompanyService companyService)
        {
            _productService = productService;
            _companyService = companyService;
        }


        [HttpGet("Show")]
        public IActionResult Show()
        {
            try
            {
                return Ok(_productService.Show());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProductRequest model)
        {
            try
            {
                _productService.Add(model);
                return Ok($"New product added: {model.Name}: ${model.Price}");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] ProductRequest model)
        {
            try
            {
                _productService.Edit(model);
                return Ok($"Product {model.Product_Id} modified successfully");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("Eliminate/{id}")]
        public IActionResult Eliminate([FromRoute] int id)
        {
            try
            {
                _productService.Eliminate(id);
                return Ok("Deleted field!!");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Company methods

        [HttpGet("Show-Companies")]
        public IActionResult ShowCompanies()
        {
            try
            {
                return Ok(_companyService.ShowCompanies());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-Company")]
        public IActionResult AddCompany([FromBody] CompanyRequest model)
        {
            try
            {
                _companyService.AddCompany(model);
                return Ok($"New company added: {model.Name}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
