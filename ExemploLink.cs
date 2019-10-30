using System;
using System.Linq;
using  System.Linq.Expressions;
                    
public class Program
{
    public static void Main()
    {
        int[] lista = new []{1,2,3};
        
        var linqToSql = from item in lista
                        where item > 2
                        select item;
        
        Console.WriteLine("Linq to SQL");
        
        foreach(var item in linqToSql)
            Console.WriteLine(item.ToString());
                    
        var linqToEntities = lista.Where(item=> item > 2);
        
        Console.WriteLine("Linq to SQL");
        
        foreach(var item in linqToSql)
            Console.WriteLine(item.ToString());
        
     
        Console.WriteLine("Linq to Entities");
        
        foreach(var item in linqToEntities)
            Console.WriteLine(item.ToString());     
        
        Func<int, bool> expression = (item) => item > 2;
        
        var linqToEntitiesWithExpression = lista.Where(expression);
        
        Console.WriteLine("Linq to Entities with expression");
        
        foreach(var item in linqToEntitiesWithExpression)
            Console.WriteLine(item.ToString());        
    }
}
