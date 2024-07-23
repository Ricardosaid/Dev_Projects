
using LambdaAdvance;

var data = new Beer
{
    Name = "Corona",
    Country = "Mexico"
};

var func = ValidationHandler.Validate(data,BeerValidations.validations) ? (Action)Success : (Action)Fail;
func();

static void Success() => Console.WriteLine("Validation success.");
static void Fail() => Console.WriteLine("Validation failed.");

// // Existen 3 delegados en c#
// // Action: No retorna valor, acepta cero o más argumentos
// // Func: Retorna un valor, acepta cero o más argumentos
// // Predicate: Retorna un valor booleano, acepta un argumento
// // MultiCast: Permite encadenar varios métodos
//





 