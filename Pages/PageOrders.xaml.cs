using CarService.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrders.xaml
    /// </summary>
    public partial class PageOrders : Page
    {
        public int idOrder;
        public PageOrders()
        {
            InitializeComponent();
            ordersListView.ItemsSource = App.DB.Order.ToList();
        }

        private void OrderListBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки позиции заказа
        {
            Order selectedOrder = (sender as Button).DataContext as Order;
            orderTitleTb.Text = selectedOrder.IdOrder.ToString(); 
            idOrder = selectedOrder.IdOrder;
            OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == selectedOrder.IdOrder).ToList();
            totalPriceTb.Text = Convert.ToString(App.DB.OrderList.Where(x => x.IdOrder == selectedOrder.IdOrder).Sum(x => x.SumPrice) + "руб.");
        }

        private void AddOrderListBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки добавления позиции заказа
        {
            if (OrderListLView.ItemsSource == null)
            {
                MessageBox.Show("Нажмите кнопку «Позиции заказа»", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            AddEditOrderPositionWindow addEditOrderPositionWindow = new AddEditOrderPositionWindow(null);
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditOrderPositionWindow.idCurrentOrder = idOrder;
            addEditOrderPositionWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == idOrder).ToList();
            totalPriceTb.Text = Convert.ToString(App.DB.OrderList.Where(x => x.IdOrder == idOrder).Sum(x => x.SumPrice) + "руб.");
        }

        private void deleteOrderListBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки удаления позиции заказа
        {
            OrderList positionForRemoving = (sender as Button).DataContext as OrderList;
            if (MessageBox.Show($"Вы действительно хотите удалить из заказа {positionForRemoving.DetailOrService.Name} в количестве {positionForRemoving.Amount}шт.?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    App.DB.OrderList.Remove(positionForRemoving);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные удалены", "Успешно!");
                    OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == idOrder).ToList();
                    totalPriceTb.Text = Convert.ToString(App.DB.OrderList.Where(x => x.IdOrder == idOrder).Sum(x => x.SumPrice) + "руб.");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void editOrderListBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки редактирования позиции заказа
        {
            AddEditOrderPositionWindow addEditOrderPositionWindow = new AddEditOrderPositionWindow((sender as Button).DataContext as OrderList);
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditOrderPositionWindow.idCurrentOrder = idOrder;
            addEditOrderPositionWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == idOrder).ToList();
            totalPriceTb.Text = Convert.ToString(App.DB.OrderList.Where(x => x.IdOrder == idOrder).Sum(x => x.SumPrice) + "руб.");
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки добавления заказа
        {
            AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow(null);
            addEditOrderWindow.Title = "Добавление заказа";
            addEditOrderWindow.TitleTb.Text = "Добавление заказа";
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditOrderWindow.ShowDialog();
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ordersListView.ItemsSource = App.DB.Order.ToList();
            App.mainWindow.Visibility = Visibility.Visible;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки редактирования заказа
        {
            AddEditOrderWindow addEditOrderWindow = new AddEditOrderWindow((sender as Button).DataContext as Order);
            addEditOrderWindow.Title = "Редактирование заказа";
            addEditOrderWindow.TitleTb.Text = "Редактирование заказа";
            App.mainWindow.Visibility = Visibility.Hidden;
            addEditOrderWindow.ShowDialog();
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            ordersListView.ItemsSource = App.DB.Order.ToList();
            App.mainWindow.Visibility = Visibility.Visible;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e) //Нажатие кнопки удаления заказа
        {
            Order orderForRemoving = (sender as Button).DataContext as Order;
            if (MessageBox.Show($"Вы точно хотите удалить заказ номер: {orderForRemoving.IdOrder} клиента: {orderForRemoving.Auto.Client.Surname} {orderForRemoving.Auto.Client.Name} {orderForRemoving.Auto.Client.Patronymic}?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (orderForRemoving.OrderList.Any() == true)
                {
                    MessageBox.Show("Имеются связанные таблицы", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    try
                    {
                        App.DB.Order.Remove(orderForRemoving);
                        App.DB.SaveChanges();
                        MessageBox.Show("Данные удалены!");
                        ordersListView.ItemsSource = App.DB.Order.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск заказа
        {
            ordersListView.ItemsSource = App.DB.Order.Where(x => x.Employee.Surname.StartsWith(searchTxt.Text) || x.Employee1.Surname.StartsWith(searchTxt.Text) || 
            x.Auto.GosNumber.StartsWith(searchTxt.Text) || x.Auto.Client.Surname.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e) //Кнопка сброса поиска заказа
        {
            ordersListView.ItemsSource = App.DB.Order.ToList();
            OrderListLView.ItemsSource = null;
            orderTitleTb.Text = "";
            searchListTxt.Text = "";
            searchTxt.Text = "";
        }

        private void searchListTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск позиции заказа по названию детали или услуги
        {
            OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == idOrder && x.DetailOrService.Name.StartsWith(searchListTxt.Text)).ToList();
        }

        private void resetListBtn_Click(object sender, RoutedEventArgs e) //Кнопка сброса поиска позиции заказа
        {
            OrderListLView.ItemsSource = App.DB.OrderList.Where(x => x.IdOrder == idOrder).ToList();
            searchListTxt.Text = "";
        }

        private void printBtn_Click(object sender, RoutedEventArgs e) //Кнопка распечатывания
        {
            OrderReceipt orderReceipt = new OrderReceipt(idOrder);
            orderReceipt.ShowDialog();
        }
    }
}
