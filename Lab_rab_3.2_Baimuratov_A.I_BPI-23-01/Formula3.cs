using Lab_rab_2_Baimuratov_A.I_BPI_23_01;
using System;

public class Formula3Calculation : Calculation
{
    private double a;
    private double b;
    private double c;
    private double d;

    public double A { get => a; set => a = value; }
    public double B { get => b; set => b = value; }
    public double C { get => c; set => c = value; }
    public double D { get => d; set => d = value; }

    public Formula3Calculation(double a, double b, double c, double d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public override double Calculate()
    {
        Result = C * Math.Pow(A, 2) + D * Math.Pow(B, 2);
        return Result;
    }
}