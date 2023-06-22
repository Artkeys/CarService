using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для ChooseClientWindow.xaml
    /// </summary>
    public partial class ChooseClientWindow : Window
    {
        int idClient;
        string fioClient;
        bool sorting = false;
        public ChooseClientWindow()
        {
            InitializeComponent();
            clientsListView.ItemsSource = App.DB.Client.ToList();
        }

        public int retIdClient() //Возврат id
        {
            return idClient;
        }

        public string retFIOClient() //Возврат ФИО
        {
            return fioClient;
        }

        private void chooseBtn_Click(object sender, RoutedEventArgs e) //Кнопка выбора
        {
            Client chooseClient = (sender as Button).DataContext as Client;
            idClient = chooseClient.IdClient;
            fioClient = chooseClient.Surname + " " + chooseClient.Name + " " + chooseClient.Patronymic;

            this.Close();
        }

        private void FIOTb_PreviewMouseDown(object sender, MouseButtonEventArgs e)  //Сортировка по ФИО
        {
            if (sorting == false)
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderBy(x => x.Surname).ToList();
                sorting = true;
            }

            else
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderByDescending(x => x.Surname).ToList();
                sorting = false;
            }
        }

        private void dateTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по Дате рождения
        {
            if (sorting == false)
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderBy(x => x.DateOfBirth).ToList();
                sorting = true;
            }

            else
            {
                clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).OrderByDescending(x => x.DateOfBirth).ToList();
                sorting = false;
            }
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск по фамилии или телефону
        {
            clientsListView.ItemsSource = App.DB.Client.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Telephone.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Кнопка сброса
        {
            clientsListView.ItemsSource = App.DB.Client.ToList();
            searchTxt.Text = "";
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
