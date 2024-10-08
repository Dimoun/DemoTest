using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.CreativeDesignPattern.Prototype
{
    public interface IPrototype
    {
        public IPrototype Clone();
    }

    public class ConccretePrototype : IPrototype
    {
        public string Option { get; set; }
        public IPrototype Clone()
        {
            ConccretePrototype conccretePrototype = new ConccretePrototype() { Option = Option };
            return conccretePrototype;
        }
    }

    public class PrototypeMode
    {
        public void Create()
        {
            IPrototype prototype = new ConccretePrototype() { Option = "new ConccretePrototype" };

            IPrototype prototype2 = prototype.Clone();
        }
    }
}
