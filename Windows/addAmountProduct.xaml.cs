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

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для addAmountProduct.xaml
    /// </summary>
    public partial class addAmountProduct : Window
    {
        private DetailOrService _currentDetailOrService = new DetailOrService();
        public addAmountProduct(DetailOrService selectedDetailOrService)
        {
            InitializeComponent();
            _currentDetailOrService = selectedDetailOrService;
            DataContext = _currentDetailOrService;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {
            if (string.IsNullOrWhiteSpace(amountTxt.Text))
            {
                MessageBox.Show("Введите количество прибывших товаров", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                _currentDetailOrService.Amount += Convert.ToInt32(amountTxt.Text);
                App.DB.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмены
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка выхода
        {
            this.Close();
        }

        private void amountTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита для ввода только чисел
        {
            if(!char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
