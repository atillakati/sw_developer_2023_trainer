namespace Taschenrechner.ControllerTypes
{
    public interface IController
    {
        double Number { get; }

        void ResetAll();

        void AddNumericChar(string value);

        void SetOperator(string operatorChar);

        void Calculate();
    
        void RemoveLastChar();        
    }
}
