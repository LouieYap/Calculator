using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        String Operand = "";
        Boolean shouldSetOperand = false;
        Double FirstNumber;
        Double SecondNumber;


        private void OnCalculatorKeyClicked(object sender, EventArgs e)
        {
            var buttonSender = (Button)sender;

            if (Value.Text.Length == 1 && Value.Text.Equals("0"))
            {
                Value.Text = buttonSender.Text;
            } else
            {
                Value.Text = string.Concat(Value.Text, buttonSender.Text);
            }

            if(Operand == "")
            {
                FirstNumber = Convert.ToDouble(Value.Text);
                shouldSetOperand = true;
            } else
            {
                SecondNumber = Convert.ToDouble(Value.Text);
            }
            
        }

        private void OnCalculatorActionClicked(object sender, EventArgs e)
        {
            var buttonSender = (Button)sender;
            if (shouldSetOperand)
            {
                Value.Text = "0";
                Operand = buttonSender.Text;
            }
        
        }

        private void OnEqualsClicked(object sender, EventArgs e)
        {

            if (Operand != "")
            {
                Value.Text = Calculate();
                Clear();
                FirstNumber = Convert.ToDouble(Value.Text);
                shouldSetOperand = true;
            }
 
        }

        private void OnClear(object sender, EventArgs e)
        {
            Value.Text = "0";
            Clear();
        }

        private void Clear()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operand = "";
            shouldSetOperand = false;
        }
        
        private String Calculate()
        {
            Double result = 0;
            switch (Convert.ToChar(Operand))
            {

                case '+':
                    result = FirstNumber + SecondNumber;
                    break;
                case '-':
                    result = FirstNumber - SecondNumber;
                    break;
                case 'X':
                    result = FirstNumber * SecondNumber;
                    break;
                case '/':
                    if (FirstNumber == 0 || SecondNumber == 0)
                    {
                        Clear();
                        Value.Text = "0";
                    } else
                    {
                        result = FirstNumber / SecondNumber;
                    }
                    
                    break;          

            }

            return Convert.ToString(result);
        }




        


    }
}
