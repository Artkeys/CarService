using CarService.Windows;
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

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        bool sorting = false;
        public PageEmployee()
        {
            InitializeComponent();
            employeeListView.ItemsSource = App.DB.Employee.ToList();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e) //Кнопка редактирование сотрудников
        {
            if (App.employee.Roles.Name != "Администратор")
            {
                MessageBox.Show("Войдите под аккаунтом администратора", "Нет доступа!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            editInfoEmployeeWindow editInfoEmployeeWindow = new editInfoEmployeeWindow((sender as Button).DataContext as Employee);
            App.mainWindow.Visibility = Visibility.Hidden;
            editInfoEmployeeWindow.ShowDialog();
            App.mainWindow.Visibility = Visibility.Visible;
            App.DB.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            employeeListView.ItemsSource = App.DB.Employee.ToList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e) //Кнопка удаления сотрудников
        {
            if (App.employee.Roles.Name != "Администратор")
            {
                MessageBox.Show("Войдите под аккаунтом администратора", "Нет доступа!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            Employee employeeForRemoving = (sender as Button).DataContext as Employee;
            if ((MessageBox.Show($"Вы действительно хотите удалить сотрудника: {employeeForRemoving.Surname} {employeeForRemoving.Name} {employeeForRemoving.Patronymic}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes))
            {
                try
                {
                    App.DB.Employee.Remove(employeeForRemoving);
                    App.DB.SaveChanges();
                    MessageBox.Show("Данные удалены");
                    employeeListView.ItemsSource = App.DB.Employee.ToList();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Имеются связанные таблицы", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void searchTxt_TextChanged(object sender, TextChangedEventArgs e) //Поиск по всем полям кроме даты рождения
        {
            employeeListView.ItemsSource = App.DB.Employee.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Education.StartsWith(searchTxt.Text) || x.Speciality.StartsWith(searchTxt.Text) || x.Roles.Name.StartsWith(searchTxt.Text)).ToList();
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeListView.ItemsSource = App.DB.Employee.ToList();
            searchTxt.Text = "";
        }

        private void FIOTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по фамилии
        {
            if (sorting == false)
            {
                employeeListView.ItemsSource = App.DB.Employee.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Education.StartsWith(searchTxt.Text) || x.Speciality.StartsWith(searchTxt.Text) || x.Roles.Name.StartsWith(searchTxt.Text)).OrderBy(x => x.Surname).ToList();
                sorting = true;
            }

            else
            {
                employeeListView.ItemsSource = App.DB.Employee.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Education.StartsWith(searchTxt.Text) || x.Speciality.StartsWith(searchTxt.Text) || x.Roles.Name.StartsWith(searchTxt.Text)).OrderByDescending(x => x.Surname).ToList();
                sorting = false;
            }
        }

        private void dateTb_PreviewMouseDown(object sender, MouseButtonEventArgs e) //Сортировка по дате рождения
        {
            if (sorting == false)
            {
                employeeListView.ItemsSource = App.DB.Employee.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Education.StartsWith(searchTxt.Text) || x.Speciality.StartsWith(searchTxt.Text) || x.Roles.Name.StartsWith(searchTxt.Text)).OrderBy(x => x.DateOfBirth).ToList();
                sorting = true;
            }

            else
            {
                employeeListView.ItemsSource = App.DB.Employee.Where(x => x.Surname.StartsWith(searchTxt.Text) || x.Education.StartsWith(searchTxt.Text) || x.Speciality.StartsWith(searchTxt.Text) || x.Roles.Name.StartsWith(searchTxt.Text)).OrderByDescending(x => x.DateOfBirth).ToList();
                sorting = false;
            }
        }
    }
}
