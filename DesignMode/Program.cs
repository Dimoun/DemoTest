using DesignMode.Mode.AbstractFactory;
using DesignMode.Mode.Builder;
using DesignMode.Mode.FactoryMethod;
using DesignMode.Mode.Prototype;

public class Program
{
    public static void Main(string[] args)
    {
        //new FactoryMethod().Create();
        //new AbstractFactory().Create();
        //new BuilderMode().Create();
        new PrototypeMode().Create();
    }
}