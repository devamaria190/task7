using System;

class Quaternion
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public double W { get; set; }

    public Quaternion(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z, q1.W + q2.W);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z, q1.W - q2.W);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;

        return new Quaternion(x, y, z, w);
    }

    public double Norm()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(-X, -Y, -Z, W);
    }

    public Quaternion Inverse()
    {
        double normSquared = X * X + Y * Y + Z * Z + W * W;
        double scale = 1.0 / normSquared;
        return new Quaternion(-X * scale, -Y * scale, -Z * scale, W * scale);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z && q1.W == q2.W;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    public Matrix3x3 ToRotationMatrix()
    {
        double xx = X * X;
        double xy = X * Y;
        double xz = X * Z;
        double xw = X * W;

        double yy = Y * Y;
        double yz = Y * Z;
        double yw = Y * W;

        double zz = Z * Z;
        double zw = Z * W;

        return new Matrix3x3(
            1 - 2 * (yy + zz), 2 * (xy - zw), 2 * (xz + yw),
            2 * (xy + zw), 1 - 2 * (xx + zz), 2 * (yz - xw),
            2 * (xz - yw), 2 * (yz + xw), 1 - 2 * (xx + yy)
        );
    }
}

class Matrix3x3
{

}

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        Quaternion sum = q1 + q2;
        Console.WriteLine($"Sum: {sum.X}, {sum.Y}, {sum.Z}, {sum.W}");

        Quaternion product = q1 * q2;
        Console.WriteLine($"Product: {product.X}, {product.Y}, {product.Z}, {product.W}");

        Console.WriteLine($"Norm of q1: {q1.Norm()}");
        Console.WriteLine($"Conjugate of q1: {q1.Conjugate().X}, {q1.Conjugate().Y}, {q1.Conjugate().Z}, {q1.Conjugate().W}");

        Console.WriteLine($"Inverse of q1: {q1.Inverse().X}, {q1.Inverse().Y}, {q1.Inverse().Z}, {q1.Inverse().W}");

        bool areEqual = q1 == q2;
        Console.WriteLine($"Are q1 and q2 equal? {areEqual}");

        Matrix3x3 rotationMatrix = q1.ToRotationMatrix();
    }
}
