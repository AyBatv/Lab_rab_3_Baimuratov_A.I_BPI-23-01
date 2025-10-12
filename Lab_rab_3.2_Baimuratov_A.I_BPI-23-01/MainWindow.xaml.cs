using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab_rab_2_Baimuratov_A.I_BPI_23_01
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Image1 { get; set; } = "/Resource/1.png";
        public string Image2 { get; set; } = "/Resource/2.png";
        public string Image3 { get; set; } = "/Resource/3.png";
        public string Image4 { get; set; } = "/Resource/4.png";
        public string Image5 { get; set; } = "/Resource/5.png";

        public List<string> ListF1 { get; set; }
        public List<string> ListF2 { get; set; }
        public List<string> ListC { get; set; }
        public List<string> ListC1 { get; set; }
        public List<string> ListD { get; set; }
        public List<string> ListN { get; set; }
        public List<string> ListK { get; set; }

        private string _result;
        public string Result
        {
            get => _result;
            set { _result = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeListBoxes();
            DataContext = this;
        }

        private void InitializeListBoxes()
        {
            ListF1 = new List<string> { "4", "5", "6", "7", "8", "9" };
            ListF2 = new List<string> { "10", "20", "30", "40" };
            ListC = new List<string> { "0", "1", "2", "3", "4", "5" };
            ListC1 = new List<string> { "0", "1" };
            ListD = new List<string> { "-1", "0", "1" };
            ListN = new List<string> { "1", "2", "3", "4", "5" };
            ListK = new List<string> { "1", "2", "3", "4", "5" };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Calculation calculation = null;

                if (Radio1.IsChecked == true)
                {
                    double a = double.Parse(R1TextA.Text);
                    double f = double.Parse(R1ComboF.SelectedItem as string);
                    calculation = new Formula1Calculation(a, f);
                }
                else if (Radio2.IsChecked == true)
                {
                    double a = double.Parse(R2TextA.Text);
                    double b = double.Parse(R2TextB.Text);
                    double f = double.Parse(R2ComboF.SelectedItem as string);
                    calculation = new Formula2Calculation(a, b, f);
                }
                else if (Radio3.IsChecked == true)
                {
                    double a = double.Parse(R3TextA.Text);
                    double b = double.Parse(R3TextB.Text);
                    double c = double.Parse(R3ComboC.SelectedItem as string);
                    double d = double.Parse(R3ComboD.SelectedItem as string);
                    calculation = new Formula3Calculation(a, b, c, d);
                }
                else if (Radio4.IsChecked == true)
                {
                    double a = double.Parse(R4TextA.Text);
                    double c = double.Parse(R4ComboC.SelectedItem as string);
                    double d = 5; 
                    calculation = new Formula4Calculation(a, c, d);
                }
                else if (Radio5.IsChecked == true)
                {
                    double x = double.Parse(R5TextX.Text);
                    double y = double.Parse(R5TextY.Text);
                    int N = int.Parse(R5ComboN.SelectedItem as string);
                    int K = int.Parse(R5ComboK.SelectedItem as string);
                    calculation = new Formula5Calculation(x, y, N, K);
                }

                if (calculation != null)
                {
                    double result = calculation.Calculate();
                    Result = $"Результат: {result:F6}";
                    Title = Result;
                }
            }
            catch (Exception ex)
            {
                Result = $"Ошибка: {ex.Message}";
                Title = Result;
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Разрешаем только цифры, запятую и минус
            foreach (char c in e.Text)
            {
                if (!char.IsDigit(c) && c != ',' && c != '-')
                {
                    e.Handled = true; // Блокируем ввод
                    return;
                }
            }

            // Дополнительная проверка для минуса (только в начале)
            TextBox textBox = sender as TextBox;
            if (e.Text == "-" && textBox != null)
            {
                if (textBox.Text.Length > 0 && textBox.SelectionStart != 0)
                {
                    e.Handled = true; // Минус можно ставить только в начале
                }
            }

            // Дополнительная проверка для запятой (не более одной)
            if (e.Text == "," && textBox != null)
            {
                if (textBox.Text.Contains(","))
                {
                    e.Handled = true; // Запятая уже есть
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}