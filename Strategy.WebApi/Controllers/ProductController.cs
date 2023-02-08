using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Identity.WebApi.Models;
using Strategy.WebApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Strategy.WebApi.Models;

namespace Identity.WebApi.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly UserManager<AppUser> _userManager;
    public ProductController(IProductRepository productRepository, UserManager<AppUser> userManager)
    {
        _productRepository = productRepository;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        var response = _productRepository.GetAllByUserId(user.Id);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var response = _productRepository.GetById(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);
        product.UserId = user.Id;
        product.CreatedDate = DateTime.Now;

        var response = _productRepository.Save(product);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        var productToUpdated = await _productRepository.GetById(product.Id);
        productToUpdated.Name = product.Name;
        productToUpdated.Price = product.Price;
        productToUpdated.Stock = product.Stock;

        var response = _productRepository.Update(productToUpdated);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var productToDeleted = await _productRepository.GetById(id);

        var response = _productRepository.Delete(productToDeleted);
        return Ok(response);
    }
}
