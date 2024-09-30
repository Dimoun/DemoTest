using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.FactoryMethod
{
    public interface Product
    {
        public void info();
    }
    public class ProductA : Product
    {
        public void info()
        {
            Console.WriteLine("产品A的信息：");
        }
    }
    public class ProductB : Product
    {
        public void info()
        {
            Console.WriteLine("产品B的信息：");
        }
    }

    public interface Factory
    {
        public Product CreateProduct();
    }
    public class FactoryA : Factory
    {
        public Product CreateProduct()
        {
            return new ProductA();
        }
    }
    public class FactoryB : Factory
    {
        public Product CreateProduct()
        {
            return new ProductB();
        }
    }
    public class FactoryMethod
    {
        public void Create()
        {
            Factory factoryA = new FactoryA();
            Product productA = factoryA.CreateProduct();
            productA.info();

            Factory factoryB = new FactoryB();
            Product productB = factoryB.CreateProduct();
            productB.info();
        }
    }
}
