namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private List<string> _products = new List<string>
    {
        "Milo",
        "Tim Tams"
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products[id];
        if (product == null)
            return NotFound();

        return Ok(product);
    }
}