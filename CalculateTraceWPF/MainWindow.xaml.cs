using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculateTraceWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string oneOperand = "0", twoOperand = "0";
        double result = 0;
        bool reset = false;
        bool checkedOneOperand = true;
        int numOperation;
        bool start;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(this.Height > 500)
            {
                inputText.FontSize = 35;
                this.MinWidth = 500;
            } 
            if(this.Height < 500)
            {
                inputText.FontSize = 25;
                this.MinWidth = 400;
            } 
            if (this.Height > 700)
            {
                inputText.FontSize = 45;
                this.MinWidth = 700;
            }
                
        }

        private void Btn_Num(object sender, EventArgs e)
        {
            if (reset && checkedOneOperand)
            {
                oneOperand = "0";
                reset = false;
            }
            Button btn = (Button)sender;
            if (oneOperand == "0" && checkedOneOperand)
                oneOperand = btn.Content.ToString();
            else if (oneOperand != "0" && checkedOneOperand && oneOperand.Length < 25)
                oneOperand += btn.Content.ToString();
            else if (twoOperand == "0" && !checkedOneOperand)
                twoOperand = btn.Content.ToString();
            else if (twoOperand != "0" && !checkedOneOperand && twoOperand.Length < 25)
                twoOperand += btn.Content.ToString();
            if (checkedOneOperand)
                inputText.Text = oneOperand;
            else
                inputText.Text = twoOperand;
        }

        private void Btn_point(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                if (oneOperand.LastIndexOf(",") == -1)
                {
                    oneOperand += ",";
                    inputText.Text = oneOperand;
                }
            }
            else
            {
                if (twoOperand.LastIndexOf(",") == -1)
                {
                    twoOperand += ",";
                    inputText.Text = twoOperand;
                }
            }

        }

        private void Btn_Operation(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Content)
            {
                case "+":
                    numOperation = 0;
                    checkedOneOperand = false;
                    inputText.Text = twoOperand;
                    break;
                case "-":
                    numOperation = 1;
                    checkedOneOperand = false;
                    inputText.Text = twoOperand;
                    break;
                case "х":
                    numOperation = 2;
                    checkedOneOperand = false;
                    inputText.Text = twoOperand;
                    break;
                case "÷":

                    if (oneOperand != "0")
                    {
                        checkedOneOperand = false;
                        inputText.Text = twoOperand;
                        numOperation = 3;
                    }
                    else
                        numOperation = 50;
                    break;

            }

            if (start)
            {
                start = false;
                result = Convert.ToDouble(inputText.Text);
            }

            outputText.Text = oneOperand + " " + btn.Content;

        }

        private void Btn_Result(object sender, EventArgs e)
        {
            switch (numOperation)
            {
                case 0:
                    oneOperand = Convert.ToString(Convert.ToDouble(oneOperand) + Convert.ToDouble(twoOperand));
                    break;
                case 1:
                    oneOperand = Convert.ToString(Convert.ToDouble(oneOperand) - Convert.ToDouble(twoOperand));
                    break;
                case 2:
                    oneOperand = Convert.ToString(Convert.ToDouble(oneOperand) * Convert.ToDouble(twoOperand));
                    break;
                case 3:
                    oneOperand = Convert.ToString(Convert.ToDouble(oneOperand) / Convert.ToDouble(twoOperand));
                    break;
                case 50:
                    inputText.Text = "ERROR";
                    break;
            }

            outputText.Text = "";
            inputText.Text = oneOperand;
            twoOperand = "0";
            reset = true;
            checkedOneOperand = true;
        }

        private void Btn_ClearElement(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                oneOperand = "0";
                inputText.Text = oneOperand;
            }
            else
            {
                twoOperand = "0";
                inputText.Text = twoOperand;
            }
        }
        private void Btn_Backspace(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                if (oneOperand.Length != 0 && oneOperand != "0")
                    oneOperand = oneOperand.Remove(oneOperand.Length - 1, 1);
                if (oneOperand.Length == 0)
                {
                    oneOperand = "0";
                }
                inputText.Text = oneOperand;
            }
            else
            {
                if (twoOperand.Length != 0 && twoOperand != "0")
                    twoOperand = twoOperand.Remove(twoOperand.Length - 1, 1);
                if (twoOperand.Length == 0)
                {
                    twoOperand = "0";
                }
                inputText.Text = twoOperand;
            }
        }

        private void Btn_Clear(object sender, EventArgs e)
        {
            twoOperand = oneOperand = "0";
            checkedOneOperand = true;
            inputText.Text = oneOperand;
            outputText.Text = twoOperand;
        }

        private void Btn_divOne(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                oneOperand = Convert.ToString(1 / Convert.ToDouble(oneOperand));
                inputText.Text = oneOperand;
                reset = true;
            }
            else
            {
                twoOperand = Convert.ToString(1 / Convert.ToDouble(twoOperand));
                inputText.Text = twoOperand;
                reset = true;
            }
        }

        private void Btn_Sqr(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                oneOperand = Convert.ToString(Math.Pow(Convert.ToDouble(oneOperand), 2));
                inputText.Text = oneOperand;
                reset = true;
            }
            else
            {
                twoOperand = Convert.ToString(Math.Pow(Convert.ToDouble(twoOperand), 2));
                inputText.Text = twoOperand;
                reset = true;
            }
        }

        private void Btn_Sqrt(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                oneOperand = Convert.ToString(Math.Sqrt(Convert.ToDouble(oneOperand)));
                inputText.Text = oneOperand;
                reset = true;
            }
            else
            {
                twoOperand = Convert.ToString(Math.Sqrt(Convert.ToDouble(twoOperand)));
                inputText.Text = twoOperand;
                reset = true;
            }
        }
        private void Btn_Percent(object sender, EventArgs e)
        {
            if (!checkedOneOperand && twoOperand != "" && twoOperand != "0")
            {
                twoOperand = Convert.ToString(Convert.ToDouble(oneOperand) * (Convert.ToDouble(twoOperand) / 100));
            }
            inputText.Text = twoOperand;
        }

        private void Btn_invertSimbol(object sender, EventArgs e)
        {
            if (checkedOneOperand)
            {
                if (oneOperand.LastIndexOf("-") != -1)
                    oneOperand = oneOperand.Remove(0, 1);
                else
                    oneOperand = "-" + oneOperand;
                inputText.Text = oneOperand;
            }
            else
            {
                if (twoOperand.LastIndexOf("-") != -1)
                    twoOperand = twoOperand.Remove(0, 1);
                else
                    twoOperand = "-" + twoOperand;
                inputText.Text = twoOperand;
            }
        }
    }
}
