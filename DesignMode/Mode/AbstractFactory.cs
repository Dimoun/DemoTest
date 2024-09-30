using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.AbstractFactory
{
    public interface IProduct
    {
        public void Info();
    }
    public interface IAbstractFactory
    {
        IProduct CreateProductA();
        IProduct CreateProductB();
    }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IProduct CreateProductA()
        {
            return new ConcreteProductA();
        }

        public IProduct CreateProductB()
        {
            return new ConcreteProductB();
        }
    }
    public class ConcreteFactory2 : IAbstractFactory
    {
        public IProduct CreateProductA()
        {
            return new ConcreteProductA();
        }

        public IProduct CreateProductB()
        {
            return new ConcreteProductB();
        }
    }
    public class ConcreteProductA : IProduct
    {
        public void Info()
        {
            Console.WriteLine("ConcreteProductA 信息");
        }
    }
    public class ConcreteProductB : IProduct
    {
        public void Info()
        {
            Console.WriteLine("ConcreteProductB 信息");
        }
    }

    internal class AbstractFactory
    {   
        public void Create()
        {
            IAbstractFactory factory = new ConcreteFactory1();
            IProduct product = factory.CreateProductA();
            product.Info();
        }
    }
}
