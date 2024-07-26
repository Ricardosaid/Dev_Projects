using System.Linq.Expressions;


RunExpressionTwo() ;

void RunExpression()
{
    Expression<Func<int,int,int>> addExpression = (a,b) => a+b;
    var add = addExpression.Compile();
    Console.WriteLine(addExpression);
    Console.WriteLine(add(1,2));

}

void RunExpressionTwo()
{
    var paramA = Expression.Parameter(typeof(int), "a");
    var paramB = Expression.Parameter(typeof(int),"b");
    var body = Expression.Add(paramA,paramB);
    var addExpression = Expression.Lambda<Func<int, int, int>>(body,paramA,paramB);
    
    Console.WriteLine(addExpression);
    var add = addExpression.Compile();
    Console.WriteLine(add(1,2));
}