using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    internal class Interpreter
    {
        public void Create()
        {
            IExpression expression5 = new NumberExpression(5);
            IExpression expression10 = new NumberExpression(10);
            IExpression expression15 = new NumberExpression(15);

            int add = new AddExpression(expression5, expression10).Interpret();
            int sub = new SubtractExpression(expression5, expression10).Interpret();

        }
    }
    public interface IExpression
    {
        public int Interpret();
    }
    public class NumberExpression : IExpression
    {
        private int _number;
        public NumberExpression(int number)
        {
            _number = number;
        }
        public int Interpret()
        {
            return _number; 
        }
    }
    public class AddExpression : IExpression
    {
        private IExpression left;
        private IExpression right;

        public AddExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public int Interpret()
        {
            return left.Interpret() + right.Interpret();    
        }
    }
    public class SubtractExpression : IExpression
    {
        private readonly IExpression _leftExpression;
        private readonly IExpression _rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public int Interpret()
        {
            return _leftExpression.Interpret() - _rightExpression.Interpret();
        }
    }

}
