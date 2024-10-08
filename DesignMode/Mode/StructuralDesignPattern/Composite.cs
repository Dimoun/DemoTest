using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DesignMode.Mode.StructuralDesignPattern
{
    internal class Composite
    {
        public void Create()
        {
            CompositeGraphic compositeGraphic = new CompositeGraphic();
            compositeGraphic.Add(new Dot(2, 3));
            compositeGraphic.Add(new Circle(5));
            compositeGraphic.Draw();
        }

    }

    public abstract class Graphic
    {
        public abstract void Draw();
    }

    public class Dot : Graphic
    {
        private int x, y;

        public Dot(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing dot at (" + x + ", " + y + ")");
        }
    }

    public class Circle : Graphic
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing circle with radius " + radius);
        }
    }

    public class CompositeGraphic : Graphic
    {
        private List<Graphic> childGraphics = new List<Graphic>();

        public void Add(Graphic graphic)
        {
            childGraphics.Add(graphic);
        }

        public void Remove(Graphic graphic)
        {
            childGraphics.Remove(graphic);
        }

        public override void Draw()
        {
            foreach (Graphic graphic in childGraphics)
            {
                graphic.Draw();
            }
        }
    }
}

