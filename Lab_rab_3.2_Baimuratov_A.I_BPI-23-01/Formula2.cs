using Lab_rab_2_Baimuratov_A.I_BPI_23_01;
using System;

public class Formula2Calculation : Calculation
{
    private double b = 0;
    private double a;
    private double f;

    public double A { get => a; set => a = value; }
    public double B { get => b; set => b = value; }
    public double F { get => f; set => f = value; }

    public Formula2Calculation(double a, double b, double f)
    {
        A = a;
        B = b;
        F = f;
    }

    public override double Calculate()
    {
        Result = Math.Cos(F * A) + Math.Sin(F * B);
        return Result;
    }
}