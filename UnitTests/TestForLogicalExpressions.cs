using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicalInterpreter
{
    [TestClass]
    public class TestForLogicalExpressions
    {
        [TestMethod]
        public void NotExpressionReturnsOppositeValueForConstantValue()
        {
            {
                // !false => true
                IExpression ne = new NotExpression(new ConstantTerminalExpression(false));
                Assert.AreEqual(true, ne.Interpret(new Context()));
            }
            {
                // !true => false
                IExpression ne = new NotExpression(new ConstantTerminalExpression(true));
                Assert.AreEqual(false, ne.Interpret(new Context()));
            }
        }

        [TestMethod]
        public void NotExpressionReturnsOppositeValueForVariable()
        {
            {
                // !a => true for a = false
                IExpression ne = new NotExpression(new VariableTerminalExpression("a"));
                Assert.AreEqual(true, ne.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
            {
                // !b => false for b = true
                IExpression ne = new NotExpression(new VariableTerminalExpression("b"));
                Assert.AreEqual(false, ne.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
        }

        [TestMethod]
        public void OrExpressionReturnsTrueWhenAnyOperandIsTrue()
        {
            {
                // true || false => true
                IExpression left = new ConstantTerminalExpression(true);
                IExpression right = new ConstantTerminalExpression(false);
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context()));
            }
            {
                // true || false => true
                IExpression left = new ConstantTerminalExpression(false);
                IExpression right = new ConstantTerminalExpression(true);
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context()));
            }
            {
                // true || true => true
                IExpression left = new ConstantTerminalExpression(true);
                IExpression right = new ConstantTerminalExpression(true);
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context()));
            }

            {
                // a || b => true for a = false and b = true
                IExpression left = new VariableTerminalExpression("a");
                IExpression right = new VariableTerminalExpression("b");
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
            {
                // a || b => true for a = true and b = false
                IExpression left = new VariableTerminalExpression("a");
                IExpression right = new VariableTerminalExpression("b");
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", true }, { "b", false } })));
            }
            {
                // false || b => true for b = true
                IExpression left = new ConstantTerminalExpression(false);
                IExpression right = new VariableTerminalExpression("b");
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
            {
                // a || true => true for a = false
                IExpression left = new VariableTerminalExpression("a");
                IExpression right = new ConstantTerminalExpression(true);
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(true, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
        }

        [TestMethod]
        public void OrExpressionReturnsFalseWhenBothOperandAreFalse()
        {
            {
                IExpression left = new ConstantTerminalExpression(false);
                IExpression right = new ConstantTerminalExpression(false);
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(false, or.Interpret(new Context()));
            }
            {
                IExpression left = new VariableTerminalExpression("a");
                IExpression right = new VariableTerminalExpression("b");
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(false, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", false } })));
            }
            {
                // false || a => false for a = false
                IExpression left = new ConstantTerminalExpression(false);
                IExpression right = new VariableTerminalExpression("a");
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(false, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
            {
                // a || !b => false for a = false and b = true
                IExpression left = new VariableTerminalExpression("a");
                IExpression right = new NotExpression(new VariableTerminalExpression("b"));
                IExpression or = new OrExpression(left, right);
                Assert.AreEqual(false, or.Interpret(new Context(new Dictionary<string, bool>() { { "a", false }, { "b", true } })));
            }
        }
    }
}
