using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorChallenge
{
    public class Calculator
    {
        public decimal Add(List<decimal> numbers)
        {
            decimal total = 0;
           foreach(var num in numbers)
            {
                total+=num;
                
            }
            Console.WriteLine(total);
            return total;
        }
        public decimal Subract(decimal num1,decimal num2)
        {
            var result = num1 - num2;
            return result;
        }
        public decimal Multiply(List<decimal> numbers)
        {
            decimal total = 1;
            foreach (var num in numbers)
            {
                total *= num;

            }
            Console.WriteLine(total);
            return total;
        }
        public decimal Divide(decimal num1,decimal num2)
        {
            string quotient ;
            var result = num1 / num2;
            var quot = num1 % num2;
            Console.WriteLine(result);
            string stringresult = result.ToString();
            char firchr = stringresult[0];
            if (quot == 0)
            {
                quotient = "1";
                Console.WriteLine(firchr + "/ " + quotient );
            }
            else
            {
                quotient = quot.ToString();
                Console.WriteLine(firchr + " " + quotient + "/" + num2);
            }
            
            
            return result;
           
        }

       
        public decimal Average(List<decimal> numbers)
        {
            Console.WriteLine(Math.Round(Add(numbers) / numbers.Count));
           return  Add(numbers) / numbers.Count;
            
        }
    }
}
