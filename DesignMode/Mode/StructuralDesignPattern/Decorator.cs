using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern
{
    public abstract class Decorator : IComponent
    {
        private IComponent component;

        public Decorator(IComponent component)
        {
            this.component = component;
        } 

        public virtual void Operation()
        {
            component?.Operation();
        }
    }
    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(IComponent component) : base(component)
        {

        }
        public override void Operation()
        {
            //base.Operation();
            Console.WriteLine("ConcreteDecorator.Operation()");
        }
        

    }

    public interface IComponent
    {
        public void Operation();
    }
    public class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()");
        }
    }

    public class DecoratorMode
    {
        public void Create()
        {
            IComponent component = new ConcreteComponent();

            component = new ConcreteDecorator(component);
            component.Operation();
        }
    }

}
