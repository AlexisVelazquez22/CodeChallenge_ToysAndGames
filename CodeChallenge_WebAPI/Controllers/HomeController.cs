using DB.Models;
using DB.Context;
using DB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace CodeChallenge_WebAPI.Controllers
{
    //Las APIs deben ser autodescriptivas, en conjunto con los verbos HTTP, este controller podria ser considerado un Controlador para Homes, y estamos hablando
    // de productos, lo ideal sería renombrarlo a ProductsController, ve los demas comentarios para mayor información
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

        // esta api debe ser autodescriptiva, "show" no le dice nada al consumidor de la api, api/Home/Show, se entiende que va a msotrar una casa,
        // lo idea sería renombrar el controlador a productcontroller y no ponerle un nombre a la ruta, así de esta forma
        // quedaría como GET api/products y el consumidor de la api entendría que GET products es para obtener los productos.
        [HttpGet("Show")]
        //Renombra la firma del Action a algo mas descriptivo como Get products o solo Get, Show se utiliza más para mostrar que para obtener elementos.
        public IActionResult Show()
        {
            try
            {
                return Ok(_productService.Show());
            }
            catch (Exception ex)
            {
                //No devuelvas un badrequest a menos de que estés seguro que es culpa del consumidor de la API, 
                // en estos casos se dee utilizar un error 500 - Internal Server Error, los codigos de estado 400 se deben devolver cuando el error ha sido
                // causado en el request
                return BadRequest(ex.Message);
            }
        }

        // el hecho de que estés usando un verbo POST se entiende que es para Agregar,insertar o procesar un nuevo elemento,
        // te recomiendo quitarle el nombre al HttpPost, ya que al ejecutar la api quedaría como POST Api/Products
        [HttpPost("Add")]
        public IActionResult Add([FromBody] ProductRequest model)
        {
            try
            {
                _productService.Add(model);
                //La forma correcta de devolver la respueta en un Metodo Post que ha insertado datos, debe ser un codigo 201 Created con la entidad completa,
                //incluido su id. Deberás actualizar el método Add para que te devuelva la Entidad creada, y así poder devolverla en una respuesta 201.
                return Ok($"New product added: {model.Name}: ${model.Price}");
            }
            catch (Exception ex)
            {
                //No devuelvas un badrequest a menos de que estés seguro que es culpa del consumidor de la API, 
                // en estos casos se dee utilizar un error 500 - Internal Server Error, los codigos de estado 400 se deben devolver cuando el error ha sido
                // causado en el request
                return BadRequest(ex.Message);
            }
        }

        // el hecho de que estés usando un verbo PUT se entiende que es para actualizar un elemento existente,
        // te recomiendo quitarle el nombre al HttpPut, ya que al ejecutar la api quedaría como PUT Api/Products y se entendería que es para actualizar un
        // producto.
        // Comunmente en las APIs para actualizar datos se debe inlcuir el Id del elemento que se pretende editar, agrega el Id como Parámetro de
        // ruta y quítalo del ProductRequest. la url quedaría así PUT /api/products/{id}
        [HttpPut("Edit")]
        public IActionResult Edit([FromBody] ProductRequest model)
        {
            try
            {
                _productService.Edit(model);
                //No debes devolver un mensaje a menos que sea necesario, devuelve la entidad Actualizada
                return Ok($"Product {model.Id} modified successfully");

            }
            catch (Exception ex)
            {
                //No devuelvas un badrequest a menos de que estés seguro que es culpa del consumidor de la API, 
                // en estos casos se dee utilizar un error 500 - Internal Server Error, los codigos de estado 400 se deben devolver cuando el error ha sido
                // causado en el request
                return BadRequest(ex.Message);
            }
        }

        // el hecho de que estés usando un verbo DELETE se entiende que es para eliminar un elemento existente,
        // te recomiendo quitarle el nombre al HttpDelete, ya que al ejecutar la api quedaría como DELETE Api/Products/{id} y se entendería que es para
        // eliminar un producto.
        // Renombra el action para que se llame Delete en lugar de Eliminate, es más entendible delete que eliminate.
        [HttpDelete("Eliminate/{id}")]
        public IActionResult Eliminate([FromRoute] int id)
        {
            try
            {
                _productService.Eliminate(id);
                //No Debes devolver un mensaje, lo correctó sería deolver un 204 No content en caso de que el borrado sea exitoso
                return Ok("Deleted field!!");

            }
            catch (Exception ex)
            {
                //No devuelvas un badrequest a menos de que estés seguro que es culpa del consumidor de la API, 
                // en estos casos se dee utilizar un error 500 - Internal Server Error, los codigos de estado 400 se deben devolver cuando el error ha sido
                // causado en el request
                return BadRequest(ex.Message);
            }
        }


        //ambos metodos Get companies y Add companies deben estar en su propio controlador companies, y deben tener rutas self-descriptives y cumplir con todas las reglas que mencione en este controlador previamente

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
