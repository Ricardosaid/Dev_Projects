using AspTest.Models;

namespace AspTest.Services;

public class BeerServices : IBeer
{
    private List<Beer> _beers =
    [
        new Beer
        {
            Id = 1,
            Name = "Budweiser",
            Brand = "Anheuser-Busch",
        },

        new Beer
        {
            Id = 2,
            Name = "Coors Light",
            Brand = "Coors Brewing Company",
        }
    ];

    // private List<Beer> _beers = new()
    // {
    //     new Beer
    //     {
    //         Name = "Budweiser",
    //         Brand = "Anheuser-Busch",
    //     },
    //     new Beer
    //     {
    //         Name = "Coors Light",
    //         Brand = "Coors Brewing Company",
    //     }
    // };
    public IEnumerable<Beer> GetBeers() => _beers;
    // public IEnumerable<Beer> GetBeers()
    // {
    //     return _beers;
    // }

    public Beer? GetBeer(int id) => _beers.FirstOrDefault(b => b.Id == id);
}