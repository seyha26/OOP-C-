using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebStockManagement.Dto;
using WebStockManagement.Service;

namespace WebStockManagement.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ApiCategoryController : ControllerBase
{
    private readonly CategoryService _service;
    public ApiCategoryController(CategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    [Route("list")]
    public IActionResult GetCategories()
    {
        var list = _service.GetCategoriesAll();
        return Ok(new MessageResponse(list, "Get data category success", "200", isSuccess: true));
    }

    [HttpGet]
    [Route("getById/{id}")]
    public IActionResult GetCategory(int Id)
    {
        try
        {
            var category = _service.GetCategoryById(Id);
            return Ok(new MessageResponse(category, "Get data category success.", "200", isSuccess: true));
        }
        catch (Exceptions.WebException ex)
        {
            return Ok(new MessageResponse(null, ex.Message, ex.ErrorCode, isSuccess: false));
        }
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreateCategory([FromBody] Category category)
    {
        try
        {
            _service.CreateCategory(category);
            return Ok(new MessageResponse(category, "Create category success", "200", isSuccess: true));
        }
        catch (Exceptions.WebException ex)
        {
            return Ok(new MessageResponse(null, ex.Message, ex.ErrorCode, isSuccess: false));
        }
    }

    [HttpPost]
    [Route("update")]
    public IActionResult UpdateCategory([FromBody] Category category)
    {
        try
        {
            _service.UpdateCategroy(category);
            return Ok(new MessageResponse(category, "Update category success", "200", isSuccess: true));
        }
        catch (Exceptions.WebException ex)
        {

            return Ok(new MessageResponse(null, ex.Message, ex.ErrorCode, isSuccess: false));
        }
    }

    [HttpPost]
    [Route("delete/{id}")]
    public IActionResult DeleteCategory(Category category)
    {
        try
        {
            _service.DeleteCategory(category);
            return Ok(new MessageResponse(category, "Delete category succes", "200", isSuccess: true));
        }
        catch (Exceptions.WebException ex)
        {
            return Ok(new MessageResponse(null, ex.Message, ex.ErrorCode, isSuccess: false));
        }
    }
}