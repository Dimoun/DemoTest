using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.CreativeDesignPattern.SimpleFactory
{

    public abstract class Product
    {

        public abstract void Info();
    }

    public class ProductA : Product
    {
        public override void Info()
        {
            Console.WriteLine("产品A信息：");
        }
    }
    public class ProductB : Product
    {
        public override void Info()
        {
            Console.WriteLine("产品B信息：");
        }
    }
    internal class SimpleFactory
    {
        class Factory
        {
            public static Product CreateProduct(string type)
            {
                Product product = null;
                switch (type)
                {
                    case "A": product = new ProductA(); break;
                    case "B": product = new ProductB(); break;
                    default:
                        Console.WriteLine($"没有{type}类型的产品");
                        return null;
                }
                return product;
            }
        }

        public void Create()
        {
            Product productA = Factory.CreateProduct("A");
            productA.Info();

            Product productB = Factory.CreateProduct("B");
            productB.Info();
        }
    }

}
