using System;
using System.Collections.Generic;

abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
}

class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Circle at ({X}, {Y}) with Radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}

class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Rectangle at ({X}, {Y}) with Width {Width} and Height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}

class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing Triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}

class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> primitives;

    public Group()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing Group at ({X}, {Y})");

        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;

        foreach (var primitive in primitives)
        {
            primitive.Move(x, y);
        }
    }
}

class GraphicsEditor
{
    private List<GraphicPrimitive> primitives;

    public GraphicsEditor()
    {
        primitives = new List<GraphicPrimitive>();
    }

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAllPrimitives()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void ScalePrimitive(GraphicPrimitive primitive, float factor)
    {
        Console.WriteLine($"Scaling {primitive.GetType().Name} by a factor of {factor}");
    }
}

class Program
{
    static void Main()
    {
        Circle circle = new Circle { X = 10, Y = 20, Radius = 5 };
        Rectangle rectangle = new Rectangle { X = 30, Y = 40, Width = 8, Height = 12 };
        Triangle triangle = new Triangle { X = 50, Y = 60 };

        Group group = new Group();
        group.AddPrimitive(circle);
        group.AddPrimitive(rectangle);

        GraphicsEditor editor = new GraphicsEditor();
        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        editor.DrawAllPrimitives();

        editor.ScalePrimitive(circle, 2.0f);
    }
}
