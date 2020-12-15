using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CA2_15_12_2020
{
    /*========================================================================
    # Tristan Reilly
    # S00199625
    # 09/12/2020
    # CA2 OOP
    =======================================================================*/

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>(); // create collection for employees
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee selectedEmployee = ListBox.SelectedItem as Employee;

            if (selectedEmployee != null) // ensure selected item isnt null
            {
                TxtBoxFN.Text = selectedEmployee.FirstName;
                TxtBoxSn.Text = selectedEmployee.Surname;
                
                if (selectedEmployee is FullTimeEmployee)
                {
                    //TxtBoxSalary = selectedEmployee.Salary;
                    RBtnFT.IsChecked = true;
                    RBtnPT.IsChecked = false;
                }
                else if (selectedEmployee is PartTimeEmployee)
                {
                    //TxtBoxHR = selectedEmployee.HourlyRate;
                    //TxtBoxHW = selectedEmployee.HoursWorked;
                    RBtnPT.IsChecked = true;
                    RBtnFT.IsChecked = false;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FullTimeEmployee emp1 = new FullTimeEmployee(); // fulltime employee object
            emp1.FirstName = "Kevin";
            emp1.Surname = "McCallister";
            emp1.Salary = 45000;
            FullTimeEmployee emp2 = new FullTimeEmployee(); // fulltime employee object
            emp2.FirstName = "Alex";
            emp2.Surname = "Brennan";
            emp2.Salary = 60000;

            PartTimeEmployee emp3 = new PartTimeEmployee(); // parttime employee object
            emp3.FirstName = "Martin";
            emp3.Surname = "FitzGerald";
            emp3.HourlyRate = 12.50m;
            emp3.HoursWorked = 45;
            PartTimeEmployee emp4 = new PartTimeEmployee(); // parttime employee object
            emp4.FirstName = "Linda";
            emp4.Surname = "McGettigan";
            emp4.HourlyRate = 14.50m;
            emp4.HoursWorked = 48;

            employees.Add(emp1); // added employees to collecion employees
            employees.Add(emp2);
            employees.Add(emp3);
            employees.Add(emp4);

            ListBox.ItemsSource = employees;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = TxtBoxFN.Text;
            string surname = TxtBoxSn.Text;
            string salary = TxtBlockSalary.Text;
            string hoursWorked = TxtBlockHW.Text;
            string hourlyRate = TxtBlockHR.Text;

            if (RBtnFT.IsChecked == true && RBtnPT.IsChecked == false) // if statement to check if emp is part time or full time
            {
                FullTimeEmployee emp = new FullTimeEmployee(); // fulltime employee object
                emp.FirstName = firstName;
                emp.Surname = surname;
                //emp.Salary = salary;

                employees.Add(emp);
            }
            else if (RBtnFT.IsChecked == false && RBtnPT.IsChecked == true)
            {
                PartTimeEmployee emp = new PartTimeEmployee(); // parttime employee object
                emp.FirstName = firstName;
                emp.Surname = surname;
                //emp.HourlyRate = hourlyRate;
                //emp.HoursWorked = hoursWorked; 

                employees.Add(emp);
            }
        }
    }
}
