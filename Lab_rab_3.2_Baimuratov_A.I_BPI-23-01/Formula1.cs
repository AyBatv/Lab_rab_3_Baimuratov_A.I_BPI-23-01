using Lab_rab_2_Baimuratov_A.I_BPI_23_01;
using System;

public class Formula1Calculation : Calculation
{
    private double a;
    private double f;

    public double A { get => a; set => a = value; }
    public double F { get => f; set => f = value; }

    public Formula1Calculation(double a, double f)
    {
        A = a;
        F = f;
    }

    public override double Calculate()
    {
        Result = Math.Sin(F * A);
        return Result;
    }
}