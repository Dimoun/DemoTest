using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern.Adapter
{
    internal class Adapter : Adaptee,ITarget
    {
        public void Request()
        {
            SpecificRequest();
        }
    }

    public interface ITarget
    {
        public void Request();
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {

        }

    }
}
