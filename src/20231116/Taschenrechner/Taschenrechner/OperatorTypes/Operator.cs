namespace Taschenrechner.OperatorTypes
{
    public class Operator
    {
        private readonly string _operatorSign;
        private readonly OperatorHandler _handler;

        public Operator(string sign, OperatorHandler handler)
        {
            _handler = handler;
            _operatorSign = sign;
        }

        public OperatorHandler Handler
        {
            get { return _handler; }        
        }

        public string Sign
        {
            get { return _operatorSign; }        
        }        
    }
}
