using System.Globalization;
using Taschenrechner.OperatorTypes;
using Taschenrechner.ViewTypes;

namespace Taschenrechner.ControllerTypes
{
    public class CalculatorController : IController
    {
        private readonly ICalculatorView _view;
        private string _numberString;
        private double _firstNumber;
        private OperatorHandler _latestSelectedOperator;
        private bool _outputShouldBeClearedOnce;
        private Operator[] operatorList;
        private string _decimalSeparator;


        public CalculatorController(ICalculatorView view)
        {
            _decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            _numberString = "0";
            _outputShouldBeClearedOnce = false;

            //setup operator assosiation with buttons signs
            operatorList = new Operator[]
            {
                new Operator("+", new OperatorHandler(OperatorMethods.Addition)),
                new Operator("-", new OperatorHandler(OperatorMethods.Substration)),
                new Operator("x", new OperatorHandler(OperatorMethods.Multiplication)),
                new Operator("/", new OperatorHandler(OperatorMethods.Division))
            };

            _view = view;
        }

        public double Number => double.Parse(_numberString);

        public void AddNumericChar(string value)
        {
            if (_numberString == "0" || _outputShouldBeClearedOnce)
            {
                if (value != _decimalSeparator)
                {
                    _numberString = string.Empty;
                    _outputShouldBeClearedOnce = false;
                }
            }

            if (_numberString.Length <= 9)
            {
                if (value == _decimalSeparator &&
                    _numberString.Contains(_decimalSeparator))
                {
                    return;
                }

                _numberString += value;
            }

            _view.UpdateResultView(Number);
        }

        public void Calculate()
        {
            if (_latestSelectedOperator == null)
            {
                return;
            }

            var secondNumber = double.Parse(_numberString);
            var tempValue = _latestSelectedOperator.Invoke(_firstNumber, secondNumber);
            _numberString = tempValue.ToString();

            _latestSelectedOperator = null;
            _outputShouldBeClearedOnce = true;

            _view.UpdateResultView(Number);
        }

        public void RemoveLastChar()
        {
            if (_numberString.Length > 0)
            {
                _numberString = _numberString.Substring(0, _numberString.Length - 1);
                if (_numberString == string.Empty)
                {
                    _numberString = "0";
                }
            }

            _view.UpdateResultView(Number);
        }

        public void ResetAll()
        {
            _numberString = "0";
            _latestSelectedOperator = null;

            _view.UpdateResultView(Number);
        }

        public void SetOperator(string operatorChar)
        {
            if (_latestSelectedOperator != null)
            {
                Calculate();
            }

            _firstNumber = double.Parse(_numberString);

            _latestSelectedOperator = SelectOperator(operatorChar);
            _outputShouldBeClearedOnce = true;

            _view.UpdateResultView(Number);
        }

        private OperatorHandler SelectOperator(string operatorChar)
        {
            foreach (var op in operatorList)
            {
                if (operatorChar == op.Sign)
                {
                    return op.Handler;
                }
            }

            return null;
        }
    }
}
