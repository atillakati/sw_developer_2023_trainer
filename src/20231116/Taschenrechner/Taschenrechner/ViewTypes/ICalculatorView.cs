
using Taschenrechner.ControllerTypes;

namespace Taschenrechner.ViewTypes
{
    public interface ICalculatorView
    {
        void SetController(IController controller);
        
        void UpdateResultView(double currentValue);
    }
}
