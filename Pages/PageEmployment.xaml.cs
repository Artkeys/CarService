using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using nGantt.GanttChart;
using nGantt.PeriodSplitter;

namespace CarService.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEmployment.xaml
    /// </summary>
    public partial class PageEmployment : Page
    {
        private int GantLenght { get; set; }
        private ObservableCollection<ContextMenuItem> ganttTaskContextMenuItems = new ObservableCollection<ContextMenuItem>();
        private ObservableCollection<SelectionContextMenuItem> selectionContextMenuItems = new ObservableCollection<SelectionContextMenuItem>();
        DateTime minDate = DateTime.Parse("2022-12-01");
        DateTime maxDate = DateTime.Parse("2023-01-01");
        DateTime MinDate = DateTime.Parse("2022-12-01");
        DateTime MaxDate = DateTime.Parse("2023-01-01");
        public PageEmployment()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) //Загрузка окна
        {
            //nGanttChart = new nGantt.GanttControl();
            GantLenght = 20;

            
            // Set selection -mode
            nGanttChart.TaskSelectionMode = nGantt.GanttControl.SelectionMode.Single;
            // Enable GanttTasks to be selected
            nGanttChart.AllowUserSelection = true;

            // listen to the GanttRowAreaSelected event
            nGanttChart.GanttRowAreaSelected += new EventHandler<PeriodEventArgs>(ganttControl1_GanttRowAreaSelected);
            nGanttChart.GanttTaskContextMenuItems = ganttTaskContextMenuItems;



            nGanttChart.ClearGantt();
            this.CreateData(MinDate, MaxDate);


        }


        private System.Windows.Media.Brush DetermineBackground(TimeLineItem timeLineItem) //Перекрашивание выходных
        {
            if (timeLineItem.End.Date.DayOfWeek == DayOfWeek.Saturday || timeLineItem.End.Date.DayOfWeek == DayOfWeek.Sunday)
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightBlue);
            else
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Transparent);
        }

        void ganttControl1_GanttRowAreaSelected(object sender, PeriodEventArgs e)
        {
            MessageBox.Show(e.SelectionStart.ToString() + " -> " + e.SelectionEnd.ToString());
        }



        private void CreateData(DateTime minDate, DateTime maxDate) //Создание диаграммы ганта
        {
            // Set max and min dates
            nGanttChart.Initialize(minDate, maxDate);

            // Create timelines and define how they should be presented
            nGanttChart.CreateTimeLine(new PeriodYearSplitter(minDate, maxDate), FormatYear);
            nGanttChart.CreateTimeLine(new PeriodMonthSplitter(minDate, maxDate), FormatMonth);
            var gridLineTimeLine = nGanttChart.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDay);
            nGanttChart.CreateTimeLine(new PeriodDaySplitter(minDate, maxDate), FormatDayName);

            // Set the timeline to atatch gridlines to
            nGanttChart.SetGridLinesTimeline(gridLineTimeLine, DetermineBackground);
            // Create and data
            var rowgroup1 = nGanttChart.CreateGanttRowGroup("Автомеханики");
            foreach (Employee employee in App.DB.Employee.Where(x => x.Roles.Name == "Автомеханик"))
            {
                var row = nGanttChart.CreateGanttRow(rowgroup1, employee.Surname + " " + employee.Name);
                
                foreach (Order order in App.DB.Order.Where(x => x.IdAutoMechanic == employee.IdEmployee))
                {
                    nGanttChart.AddGanttTask(row, new GanttTask() { Start = order.DateOfRegistration.Value, End = order.DateOfDelivery.Value, Name = order.Auto.GosNumber, TaskProgressVisibility = System.Windows.Visibility.Hidden}) ;
                }
            }


        }



        private string FormatYear(Period period) //Установление формата года
        {
            return period.Start.Year.ToString();
        }

        private string FormatMonth(Period period) //Установление формата месяца
        {
            return period.Start.ToString("MMMM");
        }

        private string FormatDay(Period period) //Установление формата дня
        {
            return period.Start.Day.ToString();
        }

        private string FormatDayName(Period period) //Установление формата дня недели
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(period.Start.DayOfWeek);
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e) //Кнопка для формирования диаграммы ганта
        {
                if (dateofDeleviry.SelectedDate == null || dateofRegistration.SelectedDate == null || dateofDeleviry.SelectedDate.Value <= dateofRegistration.SelectedDate.Value)
            {
                MessageBox.Show("Введите корректную дату", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            else
            {
                DateTime minDate = dateofRegistration.SelectedDate.Value;
                DateTime maxDate = dateofDeleviry.SelectedDate.Value;
                DateTime MinDate = dateofRegistration.SelectedDate.Value;
                DateTime MaxDate = dateofDeleviry.SelectedDate.Value;
                nGanttChart.ClearGantt();
                CreateData(MinDate, MaxDate);
            }       
        }
    }
}
