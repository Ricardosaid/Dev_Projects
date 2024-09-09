using AspTest.Models;
using AspTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspTest.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BeerController : Controller
{
    private readonly IBeer _beerService;

    public BeerController(IBeer beerService)
    {
        _beerService = beerService;
    }
    
    //Get
    [HttpGet]
    public IActionResult Get() => Ok(_beerService.GetBeers());

    [HttpGet("{id:int}")]
    public IActionResult GetBeerById(int id)
    {
        var beer = _beerService.GetBeer(id);

        if (beer is null)
        {
            return NotFound();
        }

        return Ok(beer);

    }
    // // GET
    // public IActionResult Index()
    // {
    //     return View();
    // }
}