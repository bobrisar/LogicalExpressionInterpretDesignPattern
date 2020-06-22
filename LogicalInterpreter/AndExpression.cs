using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterpreter
{
    public class AndExpression : IExpression
    {
        private IExpression leftSide;
        private IExpression rightSide;

        public AndExpression(IExpression leftSide, IExpression rightSide)
        {
            this.leftSide = leftSide;
            this.rightSide = rightSide;
        }

        public bool Interpret(Context context)
        {
            return leftSide.Interpret(context) & rightSide.Interpret(context);
        }
    }
}
