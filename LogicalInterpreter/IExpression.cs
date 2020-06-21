using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterpreter
{
    public interface IExpression
    {
       bool Interpret(Context context);
    }
}
