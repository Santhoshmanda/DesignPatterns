using System;
namespace Design_Patterns.Creational.FactoryPattern
{
    // Product interface
    interface IShape
    {
        void Draw();
    }

    // Concrete products
    class Circle : IShape
    {
        public void Draw()
        {
            // Draw circle
        }
    }

    class Rectangle : IShape
    {
        public void Draw()
        {
            // Draw rectangle
        }
    }

    class Triangle : IShape
    {
        public void Draw()
        {
            // Draw triangle
        }
    }

    // Factory interface
    interface IShapeFactory
    {
        IShape CreateShape(ShapeType type);
    }

    // Concrete factory
    class ShapeFactory : IShapeFactory
    {
        public IShape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Circle:
                    return new Circle();
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Triangle:
                    return new Triangle();
                default:
                    throw new NotSupportedException($"Shape type '{type}' is not supported.");
            }
        }
    }

    enum ShapeType
    {
        Circle,
        Rectangle,
        Triangle
    }

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IShapeFactory shapeFactory = new ShapeFactory();

    //        IShape circle = shapeFactory.CreateShape(ShapeType.Circle);
    //        circle.Draw();

    //        IShape rectangle = shapeFactory.CreateShape(ShapeType.Rectangle);
    //        rectangle.Draw();
    //    }
    //}

}

