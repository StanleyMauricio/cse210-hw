using System;
using System.Dynamic;


public class Fraction
{
    private int _top;
    private int _bottom;
    public Fraction()
    {
        _top = 1;
        _bottom = 1;

    }
    public Fraction(int wholenumber)
    {
        _top = wholenumber;
        _bottom = 1;
    }
    public Fraction(int numerator,int denominator)
    {
        _top = numerator;
        _bottom = denominator;
    }
    public int GetTop()
    {
        return _top;
    }
    
    public string GetFraction()
    {
        string text=$"{_top}/{_bottom}";
        return text;
    }
    public double GetDecimal()
    {
        double decimalValue = (double)_top / _bottom;
        return decimalValue;
    }
    
}