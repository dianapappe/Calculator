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
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        string strOperator = "";
        Double dblNumber1 = 0.0;
        Double dblNumber2 = 0.0;
        Double dblTotal = 0.0;
        bool blnStart = true;

        Double dblStoreNumber = 0.0;


        public Calculator()
        {
            InitializeComponent();
        }


        private void Selection(string Tag)
        {
            switch (Tag)
            {
                case "f":
                    this.txtPrevious.Text = "";
                    this.txtNumberPanel.Text = "0";
                    break;

                case "Back":
                    {
                        this.txtNumberPanel.Text = this.txtNumberPanel.Text.Substring(0, this.txtNumberPanel.Text.Length - 1);

                        if (this.txtNumberPanel.Text.Length == 0 || this.txtNumberPanel.Text == "-" || this.txtNumberPanel.Text == "-0")
                        {
                            this.txtNumberPanel.Text = "0";
                        }

                        break;
                    }

                case "Simbol":
                    {
                        if (this.txtNumberPanel.Text.StartsWith("-"))
                        {
                            this.txtNumberPanel.Text = this.txtNumberPanel.Text.Substring(1);
                        }
                        else
                        {
                            if (this.txtNumberPanel.Text.Length > 0)
                            {
                                if (Convert.ToDouble(this.txtNumberPanel.Text) != 0)
                                {
                                    this.txtNumberPanel.Text = "-" + this.txtNumberPanel.Text;
                                }
                            }
                        }

                        break;
                    }

                case "MC":
                    {
                        this.txtMemory.Text = "";
                        dblStoreNumber = 0.0;
                        break;
                    }

                case "MR":
                    {
                        this.txtNumberPanel.Text = dblStoreNumber.ToString();
                        break;
                    }

                case "MS":
                    {
                        this.txtMemory.Text = "M";
                        dblStoreNumber = Convert.ToDouble(this.txtNumberPanel.Text);
                        break;
                    }

                case "+":
                case "-":
                case "*":
                case "/":
                case "=":
                    Operations(Tag);
                    break;

                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ".":
                    AddNumber(Tag);
                    break;



                case "Close":
                    this.Close();
                    break;
            }
        }

        private void AddNumber(string strTag)
        {
            if (blnStart)
            {
                blnStart = false;
                this.txtNumberPanel.Text = "0";
            }


            if (strTag == ".")
            {
                int intFound = this.txtNumberPanel.Text.IndexOf(".");

                if (intFound < 0)
                {
                    this.txtNumberPanel.Text += strTag;
                }
            }
            else
            {
                if (this.txtNumberPanel.Text.Length > 0)
                {
                    if (this.txtNumberPanel.Text.Substring(0, 1) == "0" && this.txtNumberPanel.Text.Length == 1)
                    {
                        this.txtNumberPanel.Text = this.txtNumberPanel.Text.Remove(0, 1);
                    }
                }
                this.txtNumberPanel.Text += strTag;
            }

        }


        private void Operations(string strOp)
        {

            if (strOp == "=")
            {
                dblTotal = 0.0;

                this.txtPrevious.Text += this.txtNumberPanel.Text;
                dblNumber2 = Convert.ToDouble(this.txtNumberPanel.Text);

                switch (strOperator)
                {
                    case "+":
                        dblTotal = dblNumber1 + dblNumber2;
                        break;
                    case "-":
                        dblTotal = dblNumber1 - dblNumber2;
                        break;
                    case "*":
                        dblTotal = dblNumber1 * dblNumber2;
                        break;
                    case "/":
                        if (dblNumber2 != 0)
                        {
                            dblTotal = dblNumber1 / dblNumber2;
                        }
                        break;

                }


                this.txtNumberPanel.Text = dblTotal.ToString();

                blnStart = true;
                dblNumber1 = 0.0;
                dblNumber2 = 0.0;
                dblTotal = 0.0;

            }
            else
            {
                dblNumber1 = Convert.ToDouble(this.txtNumberPanel.Text);
                strOperator = strOp;
                this.txtPrevious.Text = this.txtNumberPanel.Text + strOp;
                this.txtNumberPanel.Text = "0";
            }

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;

            Selection(button.Tag.ToString());
        }

    }
}
