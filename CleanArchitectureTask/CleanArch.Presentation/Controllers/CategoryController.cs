using CleanArch.Application.Features.Categories.Commands.Add;
using CleanArch.Application.Features.Categories.Commands.Delete;
using CleanArch.Application.Features.Categories.Commands.Update;
using CleanArch.Application.Features.Categories.Queries.GetAll;
using CleanArch.Application.Features.Categories.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Domain.Routes.BaseRouter;

namespace CleanArch.Presentation.Controllers;

public class CategoryController : BaseController
{
    [HttpPost(Router.CategoryRouter.Add)]
    public async Task<IActionResult> Create(AddCategoryCommand categoryCommand)
    {
        var result = await mediator.Send(categoryCommand);
        return Result(result);
    }
    
    [HttpDelete(Router.CategoryRouter.Delete)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteCategoryCommand(id));
        return Result(result);
    }

    [HttpGet(Router.CategoryRouter.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery]GetAllCategoriesQuery request)
    {
        var result = await mediator.Send(request);
        return Result(result);
    }
    
    [HttpPut(Router.CategoryRouter.Update)]
    public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateCategoryCommand categoryCommand)
    {
        var result = await mediator.Send(categoryCommand);
        return Result(result);
    }
    
    [HttpGet(Router.CategoryRouter.GetById)]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetCategoryByIdQuery(id));
        return Result(result);
    }
}