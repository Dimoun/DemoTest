using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    internal class ChainOfResponsibility
    {
        public void Create()
        {
            Handler handlerA = new ConcreteHandlerA();
            Handler handlerB = new ConcreteHandlerB();
            Handler handlerC = new ConcreteHandlerC();

            handlerA.SetNextHandler(handlerB);
            handlerB.SetNextHandler(handlerC);

            for(int i = 0;i< 30;i++)
            {
                handlerA.HandleRequest(i);
            }
        }

    }
    public abstract class Handler
    {
        protected Handler _nextHandler;
        
        public void SetNextHandler(Handler handler)
        {
            _nextHandler = handler;
        }
        public abstract void HandleRequest(int request);
    }
    public class ConcreteHandlerA : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request < 10)
            {
                Console.WriteLine($"ConcreteHandlerA handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }
    public class ConcreteHandlerB : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"ConcreteHandlerB handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }
    public class ConcreteHandlerC : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"ConcreteHandlerC handled request {request}");
            }
            else if (_nextHandler != null)
            {
                _nextHandler.HandleRequest(request);
            }
        }
    }
    
}
