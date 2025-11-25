using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct13
{
    class Operation
    {
        private string operation;
        private int priority;

        public string GetOperation {  get { return operation; } }
        public int GetPriority { get { return priority; } }

        public Operation(string operation)
        {
            this.operation = operation;
            switch (operation)
            {
                case "+":
                    priority = 3;
                    break;
                case "-":
                    priority = 3;
                    break;
                case "*":
                    priority = 2;
                    break;
                case "/":
                    priority = 2;
                    break;
                case "//":
                    priority = 2;
                    break;
                case "%":
                    priority = 2;
                    break;
                case "^":
                    priority = 1;
                    break;
                case "sqrt":
                    priority = 1;
                    break;
                case "abs":
                    priority = 1;
                    break;
                case "sign":
                    priority = 1;
                    break;
                case "sin":
                    priority = 1;
                    break;
                case "cos":
                    priority = 1;
                    break;
                case "tg":
                    priority = 1;
                    break;
                case "ln":
                    priority = 1;
                    break;
                case "lg":
                    priority = 1;
                    break;
                case "min":
                    priority = 1;
                    break;
                case "max":
                    priority = 1;
                    break;
                case "exp":
                    priority = 1;
                    break;
                case "round":
                    priority = 1;
                    break;
                case "(":
                    priority = 4;
                    break;
                case ")":
                    priority = 4;
                    break;
            }
        }
    }
}
