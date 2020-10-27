using EGNValidator.Service.Validators;
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

namespace EGN_Validator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var validator = new ENGValidator();
            if (validator.Validate(txtEGNData.Text))
            {
                txtErrors.Text = "Коректно";
            }
            else
            {
                txtErrors.Text = "Некоректно.\r\n";
                foreach(var err in validator.Validation.Errors)
                {
                    txtErrors.Text += err.Message + "\r\n";
                }
            }

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtEGNData.Focus();
        }
    }
}
