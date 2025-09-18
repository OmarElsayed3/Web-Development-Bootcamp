using CleanArch.Application.Features.Products.Commands.Add;
using CleanArch.Application.Features.Products.Commands.Delete;
using CleanArch.Application.Features.Products.Commands.Update;
using CleanArch.Application.Features.Products.Queries.GetAll;
using CleanArch.Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Domain.Routes.BaseRouter;

namespace CleanArch.Presentation.Controllers;

public class ProductController : BaseController
{
    [HttpPost(Router.ProductRouter.Add)]
    public async Task<IActionResult> Create(AddProductCommand productCommand)
    {
        var result = await mediator.Send(productCommand);
        return Result(result);
    }
    
    [HttpDelete(Router.ProductRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteProductCommand(id));
        return Result(result);
    }

    [HttpGet(Router.ProductRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery]GetAllProductsQuery request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }
    
    [HttpPut(Router.ProductRouter.Update)]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateProductCommand productCommand)
    {
        var result = await mediator.Send(productCommand);
        return Result(result);
    }
    
    [HttpGet(Router.ProductRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetProductByIdQuery(id));
        return Result(result);
    }
}