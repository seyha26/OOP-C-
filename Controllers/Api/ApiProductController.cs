using System.Net;
using Microsoft.AspNetCore.Mvc;
using WebStockManagement.Dto;
using WebStockManagement.Dto.Request;
using WebStockManagement.Service;
using WebStockManagement.Exceptions;

namespace WebStockManagement.Controllers.Api;

[ApiController]
[Route("api/[controller]")]

public class ApiProductController : ControllerBase
{
    private MessageResponse _messageResponse;
    private readonly ProductService _productService;

    public ApiProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Route("list")]
    public IActionResult GetAllProducts()
    {
        try
        {
            _messageResponse = new MessageResponse();
            var productList = _productService.GetAllProducts();
            _messageResponse.GetDataSuccess(productList);
        }
        catch (Exceptions.WebException ex)
        {
            _messageResponse.SetMessageInternalServerError(ex.Message);
        }
        catch (Exception ex)
        {

            _messageResponse.SetMessageError(ex.Message);
        }
        return Ok(_productService.GetAllProducts());
    }

    [HttpGet]
    [Route("getById/{Id}")]
    public IActionResult GetProductById(int Id)
    {
        _messageResponse = new MessageResponse();
        try
        {
            var product = _productService.GetProductById(Id);
            _messageResponse.GetDataSuccess(product);
        }
        catch (Exceptions.WebException ex)
        {
            _messageResponse.SetMessageInternalServerError(ex.Message);
        }
        catch (Exception ex)
        {
            _messageResponse.SetMessageError(ex.Message);
        }
        return Ok(_messageResponse);
    }

    [HttpPost]
    [Route("create")]
    public IActionResult CreateProduct([FromBody] ProductRequest req)
    {
        _messageResponse = new MessageResponse();
        try
        {
            _productService.CreateProduct(req);
            _messageResponse.SetMessageError("Create product success");
            return Ok(_messageResponse);
        }
        catch (Exceptions.WebException ex)
        {
            _messageResponse.SetMessageError(ex.Message);
            return BadRequest(_messageResponse);
        }
        catch (Exception ex)
        {
            _messageResponse.SetMessageInternalServerError(ex.Message);
            return StatusCode(500, _messageResponse);
        }
    }


    [HttpPost]
    [Route("update")]
    public IActionResult UpdateProduct([FromBody] ProductRequest req)
    {
        _messageResponse = new MessageResponse();
        try
        {
            _productService.UpdateProduct(req);
            _messageResponse.SetMessageError("Update product success");
        }
        catch (Exceptions.WebException ex)
        {
            _messageResponse.SetMessageInternalServerError(ex.Message);
        }
        catch (Exception ex)
        {
            _messageResponse.SetMessageError(ex.Message);
        }
        return Ok(_messageResponse);
    }

    [HttpGet]
    [Route("delete/{Id}")]
    public IActionResult DeleteProduct(int Id)
    {
        _messageResponse = new MessageResponse();
        try
        {
            _productService.DeleteProduct(Id);
            _messageResponse.SetMessageError("Delete product success"); ;
        }
        catch (Exceptions.WebException ex)
        {
            _messageResponse.SetMessageInternalServerError(ex.Message);
        }
        catch (System.Exception ex)
        {
            _messageResponse.SetMessageError(ex.Message);
        }
        return Ok(_messageResponse);
    } 
}