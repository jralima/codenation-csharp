using System.Collections.Generic;

namespace Codenation.Challenge
{
    public class Math
    {
        public List<int> Fibonacci()
        {
            const int LENGTH_LIST = 350;
            List<int> listNumbers = new List<int> { 0 };

            int firstNumber = 0;
            int secondNumber = 1;
            do
            {
                int numberAux = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = numberAux;
                listNumbers.Add(firstNumber);
            } while (firstNumber <= LENGTH_LIST);

            return listNumbers;
        }

        public bool IsFibonacci(int numberToTest)
        {
            var listNumbers = Fibonacci();
            return listNumbers.Contains(numberToTest);
        }
    }
}
