using System;
using System.Collections.Generic;

namespace ConsoleFibonanci
{
    class Program
    {
        static int FibonacciSeries(int n)  
        {  
            int firstnumber = 0, secondnumber = 1, result = 0;  
   
            if (n == 0) return 0;
            if (n == 1) return 1;
   
   
            for (int i = 2; i <= n; i++)  
            {  
                result = firstnumber + secondnumber;  
                firstnumber = secondnumber;  
                secondnumber = result;  
            }  
   
            return result;  
        } 

        static void Main(string[] args)
        {
            Console.Write("Enter the length of the Fibonacci Series: ");
            int length = Convert.ToInt32(Console.ReadLine());
            List<int> listNumbers = new List<int> { 0 };

            int termo1 = 0;
            int termo2 = 1; //se são dois termos, precisa de duas várias para controlar
            do
            {
                int temp = termo1 + termo2; //somando os dois últimos termos conforme o enunciado
                termo1 = termo2;  //fazendo o primeiro termo ter o valor do segundo
                termo2 = temp; //fazendo o segundo termo ter o valor somado dos últimos termos
                listNumbers.Add(termo1);
            } while (termo1 <= length);


            Console.Write("Lista: {0} ", string.Join(", ", listNumbers));

            Console.ReadKey();
/*

            Console.Write("Enter the length of the Fibonacci Series: ");  
            int length = Convert.ToInt32(Console.ReadLine());  
            int number;
            List<int> listNumbers = new List<int>();

            for (int i = 0; i < length; i++)  
            {  
                number = FibonacciSeries(i);                                
                listNumbers.Add(number);
            }  

            Console.Write("Lista: {0} ", string.Join(", ", listNumbers));

            Console.ReadKey();
*/
        }
    }
}
