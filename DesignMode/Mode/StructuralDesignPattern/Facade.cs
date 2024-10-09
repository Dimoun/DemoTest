using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern
{
    internal class Facade
    {
        private SubSystemA subSystemA = new SubSystemA();
        private SubSystemB subSystemB = new SubSystemB();
        
        public void Operation()
        {
            subSystemA.Operation();
            subSystemB.Operation();
        }
    }
    
    public class SubSystemA 
    {
        public void Operation()
        {

        }
    }

    public class SubSystemB 
    {
        public void Operation()
        {

        }
    }

    public class FacadeMode
    {
       public void Create() 
       {
            Facade facade = new Facade();
            facade.Operation();
        }
    }
}
