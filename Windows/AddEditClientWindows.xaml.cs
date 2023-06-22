using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CarService.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditClientWindows.xaml
    /// </summary>
    public partial class AddEditClientWindows : Window
    {
        private Client _currentClient = new Client();
        public AddEditClientWindows(Client selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
            {
                _currentClient = selectedClient;
            }

            DataContext = _currentClient;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(surnameTxt.Text))
                errors.AppendLine("Введите фамилию клиента");

            if (string.IsNullOrWhiteSpace(nameTxt.Text))
                errors.AppendLine("Введите имя клиента");
            
            if (string.IsNullOrWhiteSpace(patronymicTxt.Text))
                errors.AppendLine("Введите отчество клиента");

            if (_currentClient.DateOfBirth == null)
                errors.AppendLine("Выберите дату рождения клиента");

            if (string.IsNullOrWhiteSpace(telephoneTxt.Text))
                errors.AppendLine("Введите номер телефона клиента");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentClient.IdClient == 0)
            {
                App.DB.Client.Add(_currentClient);
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

        private void btnClose_Click(object sender, RoutedEventArgs e) //Закрытие окна
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Свернуть окно
        {
            WindowState = WindowState.Minimized;
        }

        private void surnameTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода фамилии
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void surnameTxt_LostFocus(object sender, RoutedEventArgs e) //Потеря фокуса для поднятия буквы в верхний регистр фамилии
        {
            if (!string.IsNullOrEmpty(surnameTxt.Text))
            {
                surnameTxt.Text = char.ToUpper(surnameTxt.Text[0]) + surnameTxt.Text.Substring(1);
            }
        }

        private void nameTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода имени
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void nameTxt_LostFocus(object sender, RoutedEventArgs e) //Потеря фокуса для поднятия буквы в верхний регистр имени
        {
            if (!string.IsNullOrEmpty(nameTxt.Text))
            {
                nameTxt.Text = char.ToUpper(nameTxt.Text[0]) + nameTxt.Text.Substring(1);
            }
        }

        private void patronymicTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода имени
        {
            if (!char.IsLetter(e.Text, 0)) e.Handled = true;
        }

        private void patronymicTxt_LostFocus(object sender, RoutedEventArgs e) //Потеря фокуса для поднятия буквы в верхний регистр имени
        {
            if (!string.IsNullOrEmpty(patronymicTxt.Text))
            {
                patronymicTxt.Text = char.ToUpper(patronymicTxt.Text[0]) + patronymicTxt.Text.Substring(1);
            }
        }

        private void telephoneTxt_PreviewTextInput(object sender, TextCompositionEventArgs e) //Защита от некорректного ввода телефона
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
