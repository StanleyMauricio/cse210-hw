using System;

class Program
{
    static void Main(string[] args)
    {
        // Square s1 = new Square("red", 5);
        // string color = s1.Getcolor();
        // Console.WriteLine($"Color: {color}");   
        // double area = s1.GetArea();
        // Console.WriteLine($"Area: {area}");
        // Circle c1 = new Circle("blue", 3);
        // color = c1.Getcolor();  
        // Console.WriteLine($"Color: {color}");
        // area = c1.GetArea();    
        // Console.WriteLine($"Area: {area}");
        // Rectangle r1 = new Rectangle("green", 4, 6);
        // color = r1.Getcolor();
        // Console.WriteLine($"Color: {color}");
        // area = r1.GetArea();
        // Console.WriteLine($"Area: {area}");
        List<Shape> shapes = new List<Shape>();
        Square s1 = new Square("red", 5);
        shapes.Add(s1);
        Circle c1 = new Circle("blue", 3);
        shapes.Add(c1);
        Rectangle r1 = new Rectangle("green", 4, 6);
        shapes.Add(r1);
        foreach (Shape s in shapes)
        {
            string color = s.Getcolor();
            double area = s.GetArea();
           
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }

    }
}