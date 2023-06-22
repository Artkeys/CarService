using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace CarService
{
    /// <summary>
    /// Логика взаимодействия для WindowAuthorization.xaml
    /// </summary>
    public partial class WindowAuthorization : Window
    {
        public WindowAuthorization()
        {
            InitializeComponent();
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e) //Ввод логина
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e) //Скрытие подсказки для логина
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && txtLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }

            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e) //Ввод пароля
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) //Скрытие подсказки для пароля
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }

            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) //Передвижение окна с помощью левой кнопки мыши
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e) //Кнопка закрытия
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка закрытия
        {
            this.Close();
            System.Windows.Application.Current.Shutdown();
        }

        private void JoinBtn_Click(object sender, RoutedEventArgs e) //Кнопка входа
        {
          try
            {
                App.employee = App.DB.Employee.First(x => x.login == txtLogin.Text);
                if (App.employee.password == txtPassword.Password)
                {
                    App.mainWindow.Visibility = Visibility.Visible;
                    App.mainWindow.FIOLbl.Content = App.employee.Surname + " " + App.employee.Name + " ";
                    App.mainWindow.RolesLbl.Content = App.employee.Roles.Name;
                    try
                    {
                        if (App.employee.img == null || string.IsNullOrWhiteSpace(App.employee.img))
                        {
                            string currdir = Directory.GetCurrentDirectory();
                            int pos = currdir.LastIndexOf("bin");
                            string curr = currdir.Substring(0, pos);
                            App.mainWindow.profileImg.ImageSource = new BitmapImage(new Uri($"{curr}\\resources\\question.png", UriKind.Absolute));
                        }    

                        else
                        {
                            App.mainWindow.profileImg.ImageSource = new ImageSourceConverter().ConvertFromString(App.employee.pathImage) as ImageSource;
                        }    
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    

                    this.Close();
                }

                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
           }

            catch
            {
                MessageBox.Show("Пользователь не найден!", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void registrationBtn_Click(object sender, RoutedEventArgs e) //Открытия окна регистрации
        {
            this.Visibility = Visibility.Hidden;
            WindowRegistration windowRegistration = new WindowRegistration();
            windowRegistration.ShowDialog();
            this.Visibility = Visibility.Visible;
        }
    }
}
