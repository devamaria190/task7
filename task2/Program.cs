using System;

class MathOperations
{
    public static T Add<T>(T a, T b)
    {
        dynamic operand1 = a;
        dynamic operand2 = b;
        return operand1 + operand2;
    }

    public static T Subtract<T>(T a, T b)
    {
        dynamic operand1 = a;
        dynamic operand2 = b;
        return operand1 - operand2;
    }

    public static T Multiply<T>(T a, T b)
    {
        dynamic operand1 = a;
        dynamic operand2 = b;
        return operand1 * operand2;
    }

}

class Program
{
    static void Main()
    {
        int result1 = MathOperations.Add(5, 10);
        Console.WriteLine($"Addition result: {result1}");

        double result2 = MathOperations.Subtract(15.5, 7.3);
        Console.WriteLine($"Subtraction result: {result2}");

        float result3 = MathOperations.Multiply(3.5f, 2.0f);
        Console.WriteLine($"Multiplication result: {result3}");
    }
}
