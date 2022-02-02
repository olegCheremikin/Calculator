using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class Calculators
    {
        private string result;

        public Calculators()
        {
            FirstNumber = string.Empty;
            SecondNumber = string.Empty;
            Operation = string.Empty;
            result = string.Empty;
        }
        public string FirstNumber { get; set; }
        public string SecondNumber { get; set; }
        public string Operation { get; set; }
        public string Result { get { return result; } }

        public void CalculateResult()
        {
            switch (Operation)
            {
                case "+":
                    result = (Convert.ToDouble(FirstNumber) + Convert.ToDouble(SecondNumber)).ToString();
                    break;

                case "-":
                    result = (Convert.ToDouble(FirstNumber) - Convert.ToDouble(SecondNumber)).ToString();
                    break;

                case "*":
                    result = (Convert.ToDouble(FirstNumber) * Convert.ToDouble(SecondNumber)).ToString();
                    break;

                case "÷":
                    result = (Convert.ToDouble(FirstNumber) / Convert.ToDouble(SecondNumber)).ToString();
                    break;

                case "%":
                    result = (Convert.ToDouble(FirstNumber) / 100 * Convert.ToDouble(SecondNumber)).ToString();
                    break;
            }
        }
    }
}
