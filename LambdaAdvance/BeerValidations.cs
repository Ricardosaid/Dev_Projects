using LambdaAdvance;

public class BeerValidations
{
    public static readonly Predicate<Beer>[] validations =
    {
        d => GlobalValidations<string>.NotNull(d.Name),
        d => GlobalValidations<string>.NotNull(d.Country),
        d => d.Name.Length >= 10,
        d => d.Country.Length >= 10
    };
}