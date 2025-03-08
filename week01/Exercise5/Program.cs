using System;

class Program
{
    static void Main(string[] args)
    {
        DisplaywelcomeMessage();
        string username = PromptUserName();
        int usernumber = PromptUserNumber();
        int squarenumber = SquareNumber(usernumber);
        DisplayResult(username,squarenumber);
    }
    static void DisplaywelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter you name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    
    }
    static int SquareNumber(int number)
    {
        int square = number*number;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}