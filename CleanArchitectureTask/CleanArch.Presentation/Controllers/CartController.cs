using CleanArch.Application.Features.Carts.Commands.Add;
using CleanArch.Application.Features.Carts.Commands.Delete;
using CleanArch.Application.Features.Carts.Commands.Update;
using CleanArch.Application.Features.Carts.Queries.GetAll;
using CleanArch.Application.Features.Carts.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Domain.Routes.BaseRouter;

namespace CleanArch.Presentation.Controllers;

public class CartController : BaseController
{
    [HttpPost(Router.CartRouter.Add)]
    public async Task<IActionResult> Create(AddCartCommand CartCommand)
    {
        var result = await mediator.Send(CartCommand);
        return Result(result);
    }
    
    [HttpDelete(Router.CartRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCartCommand(id));
        return Result(result);
    }

    [HttpGet(Router.CartRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCartsQuery request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }
    
    [HttpPut(Router.CartRouter.Update)]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateCartCommand CartCommand)
    {
        var result = await mediator.Send(CartCommand);
        return Result(result);
    }
    
    [HttpGet(Router.CartRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCartByIdQuery(id));
        return Result(result);
    }
}