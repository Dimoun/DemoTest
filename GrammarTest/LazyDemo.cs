using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarTest
{
    internal class LazyDemo
    {
        Lazy<MyClass> lazyInstance = new Lazy<MyClass>(() => new MyClass());
        public MyClass Instance => lazyInstance.Value;

        public void GetInstance()
        {
            MyClass instance1 = Instance; // 创建实例
            MyClass instance2 = lazyInstance.Value; // 返回同一个实例

            Console.WriteLine(instance1 == instance2); // 输出: True        }

        }
    }

    public class MyClass
    {
        public MyClass()
        {
            Console.WriteLine("MyClass instance created.");
        }
    }

}
