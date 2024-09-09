using AspTest.Controllers;
using AspTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspTestXunit;

public class BeerTesting
{
    // Que recursos necesitamos?
    // Controlador y servicios
    
    private readonly BeerController _beerController;
    private readonly IBeer _beerService;


    public BeerTesting()
    {
        _beerService = new BeerServices();
        _beerController = new BeerController(_beerService);
    }
    
    [Fact]
    public void Get_Ok()
    {
        // Preparamos el escenario
        
        //Invocamos
        var result = _beerController.Get();
        
        //Verificamos
        Assert.IsType<OkObjectResult>(result);
    }
}