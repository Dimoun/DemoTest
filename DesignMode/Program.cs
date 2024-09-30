using DesignMode.Mode.AbstractFactory;
using DesignMode.Mode.FactoryMethod;

public class Program
{
    public static void Main(string[] args)
    {
        //new FactoryMethod().Create();
        new AbstractFactory().Create();
    }
}