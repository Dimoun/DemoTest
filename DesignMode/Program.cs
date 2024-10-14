using DesignMode.Mode.BehavioralDesignPattern;
using DesignMode.Mode.CreativeDesignPattern.Singleton;
using DesignMode.Mode.StructuralDesignPattern;

public class Program
{
    public static void Main(string[] args)
    {
        //new FactoryMethod().Create();
        //new AbstractFactory().Create();
        //new BuilderMode().Create();
        //new PrototypeMode().Create();
        //new Composite().Create();
        //var instance = Singleton.Instance;
        //new DecoratorMode().Create();
        //new FlyweightMode().Create();
        //new ChainOfResponsibility().Create();
        //new Interpreter().Create();
        //new IteratorMode().Create();
        new MediatorMode().Create();
    }
}