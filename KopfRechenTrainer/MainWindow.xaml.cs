using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KopfRechenTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        char[] operants = new char[] { '+', '-', '*', '/' };

        int number1;
        int number2;
        char operant;

        public MainWindow()
        {
            InitializeComponent();

            Randomize();
        }

        private void Check_Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsCorrectCheck(operant))
                Is_Right_Label.Visibility = Visibility.Visible;
            else
                Is_False_Label.Visibility = Visibility.Visible;
        }

        // Randomize Numbers and Operator
        private void Randomize()
        {
            Random rndNumber1 = new Random();
            Random rndNumber2 = new Random();
            Random rndOperator = new Random();

            number1 = rndNumber1.Next(1, 101);
            number2 = rndNumber2.Next(1, 101);
            operant = operants[rndOperator.Next(0, 2)];

            First_Number_Field.Content = number1;
            Operator_Field.Content = operant;
            Second_Number_Field.Content = number2;
            Result_Box.Text = null;
        }

        private bool IsCorrectCheck(char operant)
        {
            switch (operant)
            {
                case '+':
                    if (number1 + number2 == Convert.ToInt32(Result_Box.Text))
                        return true;
                    return false;
                case '-':
                    if (number1 - number2 == Convert.ToInt32(Result_Box.Text))
                        return true;
                    return false;
                case '*':
                    if (number1 * number2 == Convert.ToInt32(Result_Box.Text))
                        return true;
                    return false;
                case '/':
                    if (number1 / number2 == Convert.ToInt32(Result_Box.Text))
                        return true;
                    return false;
                default:
                    return false;
            }
        }
    }
}
