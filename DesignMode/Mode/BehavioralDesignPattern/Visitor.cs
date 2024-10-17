using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public interface IVisitor
    {
        void VisitConcreteElementA(ConcreteElementA concreteElementA);
        void VisitConcreteElementB(ConcreteElementB concreteElementA);

    }
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
        public string OperationA()
        {
            return "ConcreteElementA";
        }
    }
    public class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
        public string OperationB()
        {
            return "ConcreteElementB";
        }
    }
    public class ConcreteVisitor : IVisitor
    {
        public void VisitConcreteElementA(ConcreteElementA concreteClassA)
        {
            Console.WriteLine($"Visiting {concreteClassA.OperationA()}");
        }
        public void VisitConcreteElementB(ConcreteElementB concreteClassB)
        {
            Console.WriteLine($"Visiting {concreteClassB.OperationB()}");
        }
    }
    public class VisitorMode
    {
        public void Create()
        {
            IElement elementA = new ConcreteElementA();
            IElement elementB = new ConcreteElementB();

            IVisitor visitor = new ConcreteVisitor();

            elementA.Accept(visitor);
            elementB.Accept(visitor);
        }
    }
}
