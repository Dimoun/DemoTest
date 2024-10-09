using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.StructuralDesignPattern
{
    internal class Proxy : ISubject
    {
        private ISubject _realSubject;
        public Proxy(ISubject realSubject)
        {
            this._realSubject = realSubject;
        }
        public void Request()
        {
            _realSubject.Request();

            //Console.WriteLine("代理处理请求之前的操作。");

            //// 延迟创建真实主题
            //if (_realSubject == null)
            //{
            //    _realSubject = new RealSubject();
            //}

            //// 调用真实主题的方法
            //_realSubject.Request();

            //// 在请求后执行一些操作
            //Console.WriteLine("代理处理请求之后的操作。");
        }

    }
    
    public interface ISubject
    {
        public void Request();
    }

    public class RealSubject : ISubject 
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling request.");
        }
    }

}
