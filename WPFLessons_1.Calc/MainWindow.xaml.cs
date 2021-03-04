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

namespace WPFLessons_1.Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calc _calc = new Calc();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumericButtonPressed(object sender, RoutedEventArgs e)
        {
            if (Screen.Text.Contains('=') || Screen.Text.Contains("ERROR")) Screen.Text = "";
            Screen.Text += ((Button)sender).Content;
        }

        private void OperationButtonPressed(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content)
            {
                case "+":
                    _calc.Operation = Operation.Plus;
                    break;
                case "-":
                    _calc.Operation = Operation.Minus;
                    break;
                case "*":
                    _calc.Operation = Operation.Multiply;
                    break;
                case "/":
                    _calc.Operation = Operation.Divide;
                    break;
            }

            Screen.Text += ((Button)sender).Content;
        }

        private void EqualsButtonPressed(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = double.Parse(Screen.Text.Substring(0, Screen.Text.IndexOfAny(new[] { '+', '-', '*', '/' })));
                double b = double.Parse(Screen.Text.Substring(Screen.Text.IndexOfAny(new[] { '+', '-', '*', '/' }) + 1));

                _calc.FirstValue = a;
                _calc.SecondValue = b;
                Screen.Text += $"={_calc.DoCalc()}";
            }
            catch
            {
                Screen.Text = "ERROR";
            }
            finally
            {
                _calc = new Calc();
            }
        }
    }
}
