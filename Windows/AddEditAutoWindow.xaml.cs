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
    /// Логика взаимодействия для AddEditAutoWindow.xaml
    /// </summary>
    public partial class AddEditAutoWindow : Window
    {
        private Auto _currentAuto = new Auto();
        int currentClient;
        public AddEditAutoWindow(Auto selectedAuto, Client selectedClient)
        {
            InitializeComponent();
            if (selectedAuto != null )
            {
                _currentAuto = selectedAuto;
            }

            DataContext = _currentAuto;
            currentClient = selectedClient.IdClient;
            FIOTxt.Text = selectedClient.Surname + " " + selectedClient.Name + " " + selectedClient.Patronymic;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(markTxt.Text))
                errors.AppendLine("Введите марку автомобиля");

            if (string.IsNullOrWhiteSpace(modelTxt.Text))
                errors.AppendLine("Введите модель автомобиля");

            if (string.IsNullOrWhiteSpace(yearOfReleaseTxt.Text))
                errors.AppendLine("Введите год выпуска автомобиля");

            if (string.IsNullOrWhiteSpace(gosNumberTxt.Text))
                errors.AppendLine("Введите гос.номер автомобиля");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentAuto.IdAuto == 0)
            {
                _currentAuto.IdClient = currentClient;
                App.DB.Auto.Add(_currentAuto);
            }

            try
            {
                App.DB.SaveChanges();
                MessageBox.Show("Информация сохранена!");
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмена
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            WindowState = WindowState.Minimized;
        }

        private void yearOfReleaseTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода года выпуска машины
        {
            if (!char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
