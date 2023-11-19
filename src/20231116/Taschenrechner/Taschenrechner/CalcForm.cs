using System;
using System.Windows.Forms;
using Taschenrechner.ControllerTypes;
using Taschenrechner.ViewTypes;

namespace Taschenrechner
{
    public partial class CalcForm : Form, ICalculatorView
    {
        private IController _controller;

        public CalcForm()
        {
            InitializeComponent();
        }

        #region ICalculatorView

        public void SetController(IController controller)
        {
            _controller = controller;
        }

        public void UpdateResultView(double currentValue)
        {
            lbl_output.Text = currentValue.ToString();
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_output.Text = "0";
        }

        private void NumericButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton != null)
            {
                _controller.AddNumericChar(clickedButton.Text);                
            }
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if (clickedButton != null)
            {
                _controller.SetOperator(clickedButton.Text);                
            }
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            _controller.RemoveLastChar();
        }

        private void btt_calculate_Click(object sender, EventArgs e)
        {
            _controller.Calculate();
        }

        private void btt_clear_Click(object sender, EventArgs e)
        {
            _controller.ResetAll();
        }
    }
}
