namespace LambdaAdvance;

public class ValidationHandler
{
    public static bool Validate<T>(T data, params Predicate<T>[] validations) =>
        validations.ToList().Where(val =>
        {
            return !val(data);
        }).Count() == 0;
}


public class GlobalValidations<T>
{
    public static readonly Predicate<T> NotNull = d => d != null;
}