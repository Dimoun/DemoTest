using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.FactoryMethod
{
    public interface IProduct
    {
        public void info();
    }
    public class ProductA : IProduct
    {
        public void info()
        {
            Console.WriteLine("产品A的信息：");
        }
    }
    public class ProductB : IProduct
    {
        public void info()
        {
            Console.WriteLine("产品B的信息：");
        }
    }

    public interface IFactory
    {
        public IProduct CreateProduct();
    }
    public class FactoryA : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductA();
        }
    }
    public class FactoryB : IFactory
    {
        public IProduct CreateProduct()
        {
            return new ProductB();
        }
    }
    public class FactoryMethod
    {
        public void Create()
        {
            IFactory factoryA = new FactoryA();
            IProduct productA = factoryA.CreateProduct();
            productA.info();

            IFactory factoryB = new FactoryB();
            IProduct productB = factoryB.CreateProduct();
            productB.info();
        }
    }
}
