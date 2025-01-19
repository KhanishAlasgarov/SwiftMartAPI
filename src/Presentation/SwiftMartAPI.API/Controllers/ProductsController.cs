using Microsoft.AspNetCore.Mvc;
using SwiftMartAPI.Application.Features.Products.Commands.CreateProduct;
using SwiftMartAPI.Application.Features.Products.Queries.GetAllProducts;

namespace SwiftMartAPI.API.Controllers;


public class ProductsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await Mediator.Send(new GetAllProductsQueryRequest());
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommandRequest request)
    {
        await Mediator.Send(request);
        return Ok();
    }
}
