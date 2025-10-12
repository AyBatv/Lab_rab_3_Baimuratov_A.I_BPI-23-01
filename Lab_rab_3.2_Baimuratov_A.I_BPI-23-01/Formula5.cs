using Lab_rab_2_Baimuratov_A.I_BPI_23_01;
using System;

public class Formula5Calculation : Calculation
{
    private double x;
    private double y;
    private int n;
    private int k;

    public double X { get => x; set => x = value; }
    public double Y { get => y; set => y = value; }
    public int N { get => n; set => n = value; }
    public int K { get => k; set => k = value; }

    public Formula5Calculation(double x, double y, int n, int k)
    {
        X = x;
        Y = y;
        N = n;
        K = k;
    }

    public override double Calculate()
    {
        double sum = 0;
        for (int i = 0; i <= N; i++)
        {
            for (int j = 1; j <= K; j++)
            {
                double chislitel = Math.Sin(X) * Math.Pow(X, i) + Math.Cos(Y) * Math.Pow(Y, j);
                double znamenatel = i * j;
                if (znamenatel != 0)
                {
                    sum += chislitel / znamenatel;
                }
            }
        }
        Result = sum;
        return Result;
    }
}