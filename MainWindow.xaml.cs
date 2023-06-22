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

namespace CarService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Visibility = Visibility.Hidden;
            WindowAuthorization windowAuthorization = new WindowAuthorization();
            App.mainWindow = this;
            windowAuthorization.ShowDialog();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка сворачивания
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия
        {
            this.Close();
        }

        private void clientBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с клиентами
        {
            PagesNavigationFrame.Navigate(new Pages.PageClients());
        }

        private void productsBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с продуктами
        {
            PagesNavigationFrame.Navigate(new Pages.PageProducts());
        }

        private void employeeBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с сотрудниками
        {
            PagesNavigationFrame.Navigate(new Pages.PageEmployee());
        }

        private void ordersBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с заказами
        {
            PagesNavigationFrame.Navigate(new Pages.PageOrders());
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void employmentBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с занятостью
        {
            PagesNavigationFrame.Navigate(new Pages.PageEmployment());
        }

        private void reportsBtn_Click(object sender, RoutedEventArgs e) //Открытие страницы с отчетами
        {
            PagesNavigationFrame.Navigate(new Pages.PageReport());
        }

        private void singOutBtn_Click(object sender, RoutedEventArgs e) //Кнопка выхода
        {
            profileImg.ImageSource = null;
            singOutBtn.IsChecked = false;
            this.Visibility = Visibility.Hidden;
            WindowAuthorization windowAuthorization = new WindowAuthorization();
            windowAuthorization.ShowDialog();
        }
    }
}
