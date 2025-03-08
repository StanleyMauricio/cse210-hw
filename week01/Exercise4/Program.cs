using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;
        while(number != 0)
        {
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            string usernumber = Console.ReadLine();
            number = int.Parse(usernumber);
            if (number !=0)
            {
                numbers.Add(number);
            }

        }
        int sum = 0;
        foreach(int numb in numbers)
        {
            sum = numb + sum;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        
       int max = numbers[0];
        foreach (int numb in numbers)
        {
            if (numb > max)
            {
               
                max = numb;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}