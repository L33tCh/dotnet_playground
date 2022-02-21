namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using Microsoft.AspNetCore.JsonPatch;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private List<Product> _products = new List<Product>
    {
        new Product { id = 1, name = "Milo" },
        new Product { id = 2, name = "Tim Tams" }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.Find(x => x.id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        _products.Add(product);
        return Ok();
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var product = _products.Find(x => x.name == name);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPatch("{id}&{patch}")]
    public IActionResult Patch(int id, JsonPatchDocument<Product> patch)
    {
        var product = _products.Find(x => x.id == id);
        if (product == null)
            return NotFound();
        
        patch.ApplyTo(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.Find(x => x.id == id);
        if (product == null) return NotFound();
        _products.Remove(product);
        return Ok();
    }
}