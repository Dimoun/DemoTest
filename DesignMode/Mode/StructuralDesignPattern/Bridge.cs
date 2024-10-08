using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern
{
    internal class Bridge
    {
        public void Create()
        {
            Abstraction abstraction = new Abstraction(new ConcreteImplementor());
            abstraction.Operation();
           
        }
    }
    public interface Implementor
    {
        public void OperationImp();
    }

    public class ConcreteImplementor : Implementor
    {
        public void OperationImp()
        {

        }
    }

    public class Abstraction
    {
        private Implementor implementor;
        
        public Abstraction(Implementor implementor)
        {
            this.implementor = implementor;
        }
        public void Operation()
        {
            implementor.OperationImp();
        }
    }
}
