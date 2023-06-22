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
    /// Логика взаимодействия для AddEditOrderPositionWindow.xaml
    /// </summary>
    public partial class AddEditOrderPositionWindow : Window
    {
        public int idCurrentOrder;
        int idDetail;
        int AmountDetail;
        string detailOrService;

        private OrderList _currentOrderList = new OrderList();
        public AddEditOrderPositionWindow(OrderList selectedOrderList)
        {
            InitializeComponent();

            if (selectedOrderList != null)
            {
                _currentOrderList = selectedOrderList;
                DetailOrService detailOrService = App.DB.DetailOrService.First(x => x.IdDetailOrService == _currentOrderList.IdDetailOrService);
                DetailOrServiceTxt.Text = detailOrService.Name;
                idDetail = detailOrService.IdDetailOrService;
                priceTxt.Text = detailOrService.Price.ToString();
                availabilityTxt.Text = detailOrService.Amount.ToString();
                AmountDetail = Convert.ToInt32(_currentOrderList.Amount);
            }

            DataContext = _currentOrderList;
        }

        private void ChooseDetailOrServiceBtn_Click(object sender, RoutedEventArgs e) //Кнопка выбора товара или услуги
        {
            ChooseProdOrServWindow chooseProdOrServWindow = new ChooseProdOrServWindow();
            chooseProdOrServWindow.ShowDialog();
            DetailOrServiceTxt.Text = chooseProdOrServWindow.retNameProd();
            priceTxt.Text = chooseProdOrServWindow.retPrice();
            availabilityTxt.Text = chooseProdOrServWindow.retAvailability();
            idDetail = chooseProdOrServWindow.retIdDetail();
            amountTxt.Text = "";
            detailOrService = chooseProdOrServWindow.retDetail();
        }

        private void amountTxt_TextChanged(object sender, TextChangedEventArgs e) //Защита от некорректного ввода
        {
            try
            {
                if (amountTxt.Text != null)
                {
                    sumTxt.Text = (Convert.ToDouble(priceTxt.Text) * Convert.ToInt32(amountTxt.Text)).ToString();
                }
            }

            catch
            {
                sumTxt.Text = "";
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e) //Кнопка сохранения
        {

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(DetailOrServiceTxt.Text))
                errors.AppendLine("Выберите товар или услугу");

            if (string.IsNullOrWhiteSpace(amountTxt.Text))
                errors.AppendLine("Введите количество товара или услуг");

            if (errors.Length > 0)                            //Проверка на пустоту всех полей
            {
                MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Convert.ToInt32(amountTxt.Text) > Convert.ToInt32(availabilityTxt.Text) && App.DB.DetailOrService.Where(x => x.IdDetailOrService == idDetail).First().TypeProduct == "Товар")
            {
                MessageBox.Show("Не хватает на складе", "Ошибка!");
                return;
            }
            if (_currentOrderList.IdOrderList == 0)
            {
                _currentOrderList.IdOrder = idCurrentOrder;
                _currentOrderList.SumPrice = Convert.ToDouble(sumTxt.Text);
                _currentOrderList.IdDetailOrService = idDetail;
                DetailOrService selectDetailOrService = App.DB.DetailOrService.First(x => x.IdDetailOrService == _currentOrderList.IdDetailOrService);
                if (selectDetailOrService.TypeProduct == "Услуга")
                {
                    App.DB.OrderList.Add(_currentOrderList);
                }

                else
                {
                    selectDetailOrService.Amount -= Convert.ToInt32(amountTxt.Text);
                    App.DB.OrderList.Add(_currentOrderList);
                }
            }

            if (_currentOrderList.IdOrderList != 0)
            {
                _currentOrderList.IdOrder = idCurrentOrder;
                _currentOrderList.SumPrice = Convert.ToDouble(sumTxt.Text);
                _currentOrderList.IdDetailOrService = idDetail;
                DetailOrService selectDetailOrService = App.DB.DetailOrService.First(x => x.IdDetailOrService == _currentOrderList.IdDetailOrService);
                if (selectDetailOrService.TypeProduct == "Услуга")
                {
                    App.DB.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    this.Close();
                    return;
                }
                if (AmountDetail < Convert.ToInt32(amountTxt.Text))
                {
                    selectDetailOrService.Amount = selectDetailOrService.Amount - (Convert.ToInt32(amountTxt.Text) - AmountDetail);
                }

                else if (AmountDetail > Convert.ToInt32(amountTxt.Text))
                {
                    selectDetailOrService.Amount = selectDetailOrService.Amount + (AmountDetail - Convert.ToInt32(amountTxt.Text));
                }

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

        private void btnClose_Click(object sender, RoutedEventArgs e) //Кнопка выхода
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
