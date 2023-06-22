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
    /// Логика взаимодействия для AddEditOrderWindow.xaml
    /// </summary>
    public partial class AddEditOrderWindow : Window
    {
        int idClient;
        private Order _currentOrder = new Order();
        public AddEditOrderWindow(Order selectedOrder)
        {
            InitializeComponent();
            ManagerCmb.ItemsSource = App.DB.Employee.Where(x => x.idRole == 2).OrderBy(x => x.Surname).ToList();
            AutoMechanicCmb.ItemsSource = App.DB.Employee.Where(x => x.idRole == 3).OrderBy(x => x.Surname).ToList();

            if (selectedOrder != null)
            {
                _currentOrder = selectedOrder;
                ClientTxt.Text = selectedOrder.Auto.Client.Surname + " " + selectedOrder.Auto.Client.Name + " " + selectedOrder.Auto.Client.Patronymic;
                AutoCmb.ItemsSource = App.DB.Auto.Where(x => x.IdClient == selectedOrder.Auto.IdClient).ToList();
            }

            DataContext = _currentOrder;
        }

        private void ChooseClientBtn_Click(object sender, RoutedEventArgs e) //Открытие окна выбора клиента
        {
            ChooseClientWindow chooseClientWindow = new ChooseClientWindow();
            chooseClientWindow.ShowDialog();
            ClientTxt.Text = chooseClientWindow.retFIOClient();
            idClient = chooseClientWindow.retIdClient();
            AutoCmb.ItemsSource = App.DB.Auto.Where(x => x.IdClient == idClient).ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(ClientTxt.Text))
                errors.AppendLine("Выберите клиента");

            if (_currentOrder.Auto == null)
                errors.AppendLine("Выберите авто клиента");

            if (_currentOrder.Employee1 == null)
                errors.AppendLine("Выберите менеджера оформляющий заказ");

            if (_currentOrder.Employee == null)
                errors.AppendLine("Выберите автомеханика исполнящий заказ");

            if (_currentOrder.DateOfRegistration == null)
                errors.AppendLine("Выберите дату регистрации заказа");

            if (_currentOrder.DateOfDelivery == null)
                errors.AppendLine("Выберите выдачи заказа заказа");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_currentOrder.IdOrder == 0)
            {

                App.DB.Order.Add(_currentOrder);
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

        private void CancelBtn_Click(object sender, RoutedEventArgs e) //Кнопка отмены
        {
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия окна
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            this.WindowState = WindowState.Minimized;
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
