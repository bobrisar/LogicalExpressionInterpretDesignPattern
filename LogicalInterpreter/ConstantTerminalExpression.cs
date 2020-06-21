using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterpreter
{
    public class ConstantTerminalExpression : IExpression
    {
        private readonly bool value;
        public ConstantTerminalExpression(bool value)
        {
            this.value = value;
        }

        public bool Interpret(Context context)
        {
            return value;
        }
    }
}
