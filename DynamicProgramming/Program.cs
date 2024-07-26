using System.Dynamic;

dynamic modelBase = 12;
modelBase = "Hello World";
Console.WriteLine(modelBase); 


dynamic beer = new ExpandoObject();
beer.Name = "Heineken";
beer.Price = 10.99;
Console.WriteLine(beer.Name);


dynamic func = new Func<int,int,int>((a,b) => a+b);
Console.WriteLine(func(1,2));
func = new Func<int,int,int>((a,b) => a*b);
Console.WriteLine(func(1,2));