using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterpreter
{
    public class VariableTerminalExpression : IExpression
    {
        private readonly string name;
        public VariableTerminalExpression(string name)
        {
            this.name = name;
        }
        public bool Interpret(Context context)
        {
            return context.GetValue(name);
        }
    }
}
