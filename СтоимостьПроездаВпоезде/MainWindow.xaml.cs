using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace СтоимостьПроездаВпоезде
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

        private void resButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(distanceTextBox.Text) || string.IsNullOrWhiteSpace(ticketsTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {

                double x = (Convert.ToInt32(distanceTextBox.Text) * 8) * Convert.ToInt32(ticketsTextBox.Text);

                if (platzkartRadioButton.IsChecked == true)
                {
                    finalCost.Text = x.ToString();
                }
                else if (kupeRadioButton.IsChecked == true)
                {

                    finalCost.Text = (x = x + x * 0.1).ToString();
                }
                else if (polulyuksRadioButton.IsChecked == true)
                {

                    finalCost.Text = (x = x + x * 0.2).ToString();
                }
                else if (luxeRadioButton.IsChecked == true)
                {

                    finalCost.Text = (x = x + x * 0.3).ToString();
                }
                else
                {
                    MessageBox.Show("Выберите комфортабельность");
                }
            }
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, "^[0-9]+$");
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            distanceTextBox.Clear();
            ticketsTextBox.Clear();
            finalCost.Text = " ";

            // Находим все элементы с GroupName="ComfortGroup" и сбросываем выбор
            foreach (var child in comfortStackPanel.Children)
            {
                if (child is RadioButton rb)
                {
                    rb.IsChecked = false;
                }
            }
        }
    }
}
