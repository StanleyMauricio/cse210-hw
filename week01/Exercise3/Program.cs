using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int mnumber = randomGenerator.Next(1, 101);
        //Console.WriteLine("What is the magic number?");
        //string numberforu= Console.ReadLine();
        //int mnumber = int.Parse(numberforu);
        
        
        int gnumber = -1;
        while(gnumber != mnumber)
        {
            Console.WriteLine("What is your guess?");
            string guessforu= Console.ReadLine();
            gnumber = int.Parse(guessforu);

            if (gnumber < mnumber)
        {
            Console.WriteLine("Higher");
        }
        else if(gnumber>mnumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
        }
        

    }
}