using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.CreativeDesignPattern.Singleton
{
    internal class Singleton
    {
        private static Singleton instance = null;

        public static Singleton GetInstance()
        {
            instance = instance ?? (instance = new Singleton());
            return instance;
        }
    }
}
