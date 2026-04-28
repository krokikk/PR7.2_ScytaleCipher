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

namespace PR7._2_ScytaleCipher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            ProcessCipher(true);
        }

        private void Decrypt_Click(object sender, RoutedEventArgs e)
        {
            ProcessCipher(false);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            ResultTextBox.Clear();
            DiameterTextBox.Clear();
            ErrorTextBlock.Text = "";
        }

        private void ProcessCipher(bool encrypt)
        {
            try
            {
                ErrorTextBlock.Text = "";

                string text = InputTextBox.Text;

                if (!int.TryParse(DiameterTextBox.Text, out int diameter))
                {
                    ErrorTextBlock.Text = "Диаметр должен быть числом";
                    return;
                }

                if (string.IsNullOrWhiteSpace(text))
                {
                    ErrorTextBlock.Text = "Введите текст";
                    return;
                }

                string result = encrypt
                    ? ScytaleCipher.Encrypt(text, diameter)
                    : ScytaleCipher.Decrypt(text, diameter);

                ResultTextBox.Text = result;
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = ex.Message;
            }
        }
    }
}
