using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Step1();
            Step2();
            Step3();
        }
        public abstract void Step1();

        public abstract void Step2();
     
        public void Step3()
        {
            Console.WriteLine("Executing Step Three: Common Step");
        }
    }
    public class ConcreteClassA : AbstractClass
    {
        public override void Step1()
        {
            Console.WriteLine("ConcreteClassA: Executing Step One");
        }
        public override void Step2()
        {
            Console.WriteLine("ConcreteClassA: Executing Step Two");
        }
    }
    public class ConcreteClassB : AbstractClass
    {
        public override void Step1()
        {
            Console.WriteLine("ConcreteClassB: Executing Step One");
        }
        public override void Step2()
        {
            Console.WriteLine("ConcreteClassB: Executing Step Two");
        }
    }
    public class TemplateMethodMode
    {
        public void Create()
        {
            AbstractClass abstractClass = new ConcreteClassA();
            abstractClass.TemplateMethod();

            abstractClass = new ConcreteClassB();
            abstractClass.TemplateMethod();
        }
    }
}
