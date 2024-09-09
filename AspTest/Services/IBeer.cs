using AspTest.Models;

namespace AspTest.Services;

public interface IBeer
{
    public IEnumerable<Beer> GetBeers();
    public Beer? GetBeer(int id);
}