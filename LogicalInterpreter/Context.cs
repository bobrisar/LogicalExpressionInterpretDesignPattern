using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LogicalInterpreter
{
    public class Context
    {
        private readonly Dictionary<string, bool> variables = new Dictionary<string, bool>();

        public Context()
        {
        }

        public Context(Dictionary<string, bool> variables)
        {
            this.variables = variables;
        }

        public bool GetValue(string variableName)
        {
            return variables[variableName];
        }
    }
}
