using System;
using System.Globalization;
using System.Windows.Forms;
using Taschenrechner.OperatorTypes;

namespace Taschenrechner
{
    public partial class MainForm : Form
    {
        private double _firstNumber;
        private OperatorHandler _latestSelectedOperator;
        private bool _outputShouldBeClearedOnce;
        private string _decimalSeparator;

        public MainForm()
        {
            InitializeComponent();            

            //setup operator assosiation with buttons
            btt_addition.Tag = new OperatorHandler( OperatorMethods.Addition);
            btt_subtract.Tag = new OperatorHandler(OperatorMethods.Substration);
            btt_multi.Tag = new OperatorHandler(OperatorMethods.Multiplication);
            btt_div.Tag = new OperatorHandler(OperatorMethods.Division);
        }
     
        private void NumericButton_Click(object sender, EventArgs e)
        {
            var clickedButton = sender as Button;
            if(clickedButton == null)
            {
                return;
            }
            
            if(lbl_output.Text == "0" || _outputShouldBeClearedOnce)
            {
                if(clickedButton.Text != _decimalSeparator)                
                {
                    lbl_output.Text = string.Empty;
                    _outputShouldBeClearedOnce = false;
                }                
            }

            if (lbl_output.Text.Length <= 9)
            {
                if (clickedButton.Text == _decimalSeparator && 
                    lbl_output.Text.Contains(_decimalSeparator))
                {
                    return;
                } 

                lbl_output.Text += clickedButton.Text;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_output.Text = "0";

            _decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            btt_decimalSeparator.Text = _decimalSeparator;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            var clickedOperatorButton = sender as Button;
            if (clickedOperatorButton == null)
            {
                return;
            }

            _firstNumber = double.Parse(lbl_output.Text);
            _latestSelectedOperator = clickedOperatorButton.Tag as OperatorHandler;
            _outputShouldBeClearedOnce = true;
        }

        private void btt_calculate_Click(object sender, EventArgs e)
        {
            if(_latestSelectedOperator == null)
            {
                return;
            }

            var secondNumber = double.Parse(lbl_output.Text);

            var erg = _latestSelectedOperator?.Invoke(_firstNumber, secondNumber);
            lbl_output.Text = erg.ToString();
            
            _latestSelectedOperator = null;
            _outputShouldBeClearedOnce = true;
        }

        private void btt_clear_Click(object sender, EventArgs e)
        {
            lbl_output.Text = "0";
            _latestSelectedOperator = null;
        }

        private void btt_delete_Click(object sender, EventArgs e)
        {
            if (lbl_output.Text.Length > 0)
            {
                lbl_output.Text = lbl_output.Text.Substring(0, lbl_output.Text.Length - 1);
                if(lbl_output.Text == string.Empty)
                {
                    lbl_output.Text = "0";
                }
            }
        }
    }
}
