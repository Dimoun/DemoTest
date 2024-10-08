using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.CreativeDesignPattern.Builder
{
    public abstract class Builder
    {
        public abstract void BuildPart();
    }
    public class ConcreateBuilder : Builder
    {
        Product product = null;
        public override void BuildPart()
        {
            product = new Product();

            product.AddPart("1");
            product.AddPart("2");
            product.AddPart("3");
            product.AddPart("4");
            product.AddPart("5");
        }

        public Product GetResult()
        {

            return product;
        }
    }
    public class Product
    {
        List<string> parts = new List<string>();

        public void AddPart(string part)
        {
            parts.Add(part);
        }

        public void Show()
        {
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }

    }
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPart();
        }
    }

    //Test Code
    public class BuilderMode
    {
        public void Create()
        {
            Director director = new Director();

            ConcreateBuilder concreateBuilder = new ConcreateBuilder();
            director.Construct(concreateBuilder);
            Product product = concreateBuilder.GetResult();
            product.Show();
        }
    }
}
