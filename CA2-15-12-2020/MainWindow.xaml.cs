using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System;

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
        ObservableCollection<Employee> filteredEmployees = new ObservableCollection<Employee>(); // created for filter
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtBoxFN.Clear(); // clear the First Name Text Box
            TxtBoxSn.Clear(); // clear the Surname Text Box
            TxtBoxHR.Clear(); // clear the Hourly Rate Text Box
            TxtBoxHW.Clear(); // clear the Hours Worked Text Box
            TxtBoxSalary.Clear(); // clear the Salary Text Box
            TxtBlockMP2.Text = "$0"; // clear monhtlypay text block
            RBtnFT.IsChecked = false; // clear the Full Time radial button
            RBtnPT.IsChecked = false; // clear the Part Time radial button

            Employee selectedEmployee = ListBox.SelectedItem as Employee;

            if (selectedEmployee != null) // ensure selected item isnt null
            {
                TxtBoxFN.Text = selectedEmployee.FirstName;
                TxtBoxSn.Text = selectedEmployee.Surname;

                if (selectedEmployee is FullTimeEmployee)
                {
                    FullTimeEmployee emp = selectedEmployee as FullTimeEmployee;
                    TxtBoxSalary.Text = emp.Salary.ToString();
                    TxtBlockMP2.Text = "$" + emp.CalculateMonthlyPay().ToString();
                    RBtnFT.IsChecked = true;
                    RBtnPT.IsChecked = false;
                }
                else if (selectedEmployee is PartTimeEmployee)
                {
                    PartTimeEmployee emp = selectedEmployee as PartTimeEmployee;
                    TxtBoxHR.Text = emp.HourlyRate.ToString();
                    TxtBoxHW.Text = emp.HoursWorked.ToString();
                    TxtBlockMP2.Text = "$" + emp.CalculateMonthlyPay().ToString();
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

            if (RBtnFT.IsChecked == true && RBtnPT.IsChecked == false) // if statement to check if emp is part time or full time
            {
                decimal salary = Convert.ToDecimal(TxtBoxSalary.Text); // converts int to decimal for salary

                FullTimeEmployee emp = new FullTimeEmployee(); // fulltime employee object
                emp.FirstName = firstName;
                emp.Surname = surname;
                emp.Salary = salary;

                employees.Add(emp);
            }
            else if (RBtnFT.IsChecked == false && RBtnPT.IsChecked == true)
            {
                double hoursWorked = Convert.ToDouble(TxtBoxHW.Text); // converts int to double for hoursWorked
                decimal hourlyRate = Convert.ToDecimal(TxtBoxHR.Text); // converts int to decimal for hourlyRate

                PartTimeEmployee emp = new PartTimeEmployee(); // parttime employee object
                emp.FirstName = firstName;
                emp.Surname = surname;
                emp.HourlyRate = hourlyRate;
                emp.HoursWorked = hoursWorked;

                employees.Add(emp);
            }

            TxtBoxFN.Clear(); // clear the First Name Text Box
            TxtBoxSn.Clear(); // clear the Surname Text Box
            TxtBoxHR.Clear(); // clear the Hourly Rate Text Box
            TxtBoxHW.Clear(); // clear the Hours Worked Text Box
            TxtBoxSalary.Clear(); // clear the Salary Text Box
            TxtBlockMP2.Text = "$0"; // clear monhtlypay text block
            RBtnFT.IsChecked = false; // clear the Full Time radial button
            RBtnPT.IsChecked = false; // clear the Part Time radial button
        }

        private void CBoxFT_Checked(object sender, RoutedEventArgs e)
        {
            filteredEmployees.Clear(); // clear list
            ListBox.ItemsSource = null; // set the List box to display nothing

            if (CBoxFT.IsChecked == true && CBoxPT.IsChecked == false) // if FT checked and PT not checked
            {
                foreach (Employee employee in employees) // each full time employee is added to filtered list
                {
                    if (employee is FullTimeEmployee)
                        filteredEmployees.Add(employee);
                }

                ListBox.ItemsSource = filteredEmployees; // get list box to display filtered list
            }
            else if (CBoxFT.IsChecked == true && CBoxPT.IsChecked == true) // if both boxes checked
            {
                ListBox.ItemsSource = employees; // get list box to display filtered list
            }
        }

        private void ClrBtn_Click(object sender, RoutedEventArgs e) // event to clear text boxes
        {
            TxtBoxFN.Clear(); // clear the First Name Text Box
            TxtBoxSn.Clear(); // clear the Surname Text Box
            TxtBoxHR.Clear(); // clear the Hourly Rate Text Box
            TxtBoxHW.Clear(); // clear the Hours Worked Text Box
            TxtBoxSalary.Clear(); // clear the Salary Text Box
            TxtBlockMP2.Text = "$0"; // clear monhtlypay text block
            RBtnFT.IsChecked = false; // clear the Full Time radial button
            RBtnPT.IsChecked = false; // clear the Part Time radial button
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = ListBox.SelectedItem as Employee;

            if (selectedEmployee != null) // ensure selected item isnt null
            {
                employees.Remove(selectedEmployee); // remove selected employee

                if (RBtnFT.IsChecked == true && RBtnPT.IsChecked == false) // add employee fulltime 
                {
                    string firstName = TxtBoxFN.Text;
                    string surname = TxtBoxSn.Text;
                    decimal salary = Convert.ToDecimal(TxtBoxSalary.Text);

                    FullTimeEmployee emp = new FullTimeEmployee(); // fulltime employee object
                    emp.FirstName = firstName;
                    emp.Surname = surname;
                    emp.Salary = salary;

                    employees.Add(emp);
                }
                else if (RBtnPT.IsChecked == true && RBtnFT.IsChecked == false) // add part time employee
                {
                    string firstName = TxtBoxFN.Text;
                    string surname = TxtBoxSn.Text;
                    decimal hourlyRate = Convert.ToDecimal(TxtBoxSalary.Text);
                    double hoursWorked = Convert.ToDouble(TxtBoxHW.Text);


                    PartTimeEmployee emp = new PartTimeEmployee(); // part time employee object
                    emp.FirstName = firstName;
                    emp.Surname = surname;
                    emp.HourlyRate = hourlyRate;
                    emp.HoursWorked = hoursWorked;

                    employees.Add(emp);
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = ListBox.SelectedItem as Employee;

            if (selectedEmployee != null) // ensure selected item isnt null
            {
                employees.Remove(selectedEmployee); // remove selected employee
            }

            TxtBoxFN.Clear(); // clear the First Name Text Box
            TxtBoxSn.Clear(); // clear the Surname Text Box
            TxtBoxHR.Clear(); // clear the Hourly Rate Text Box
            TxtBoxHW.Clear(); // clear the Hours Worked Text Box
            TxtBoxSalary.Clear(); // clear the Salary Text Box
            TxtBlockMP2.Text = "$0"; // clear monhtlypay text block
            RBtnFT.IsChecked = false; // clear the Full Time radial button
            RBtnPT.IsChecked = false; // clear the Part Time radial button
        }

        private void CBoxPT_Checked(object sender, RoutedEventArgs e)
        {
            filteredEmployees.Clear(); // clear list
            ListBox.ItemsSource = null; // set the List box to display nothing

            if (CBoxFT.IsChecked == false && CBoxPT.IsChecked == true) // if PT checked and FT not checked
            {
                foreach (Employee employee in employees) // each part time employee is added to filtered list
                {
                    if (employee is PartTimeEmployee)
                        filteredEmployees.Add(employee);
                }

                ListBox.ItemsSource = filteredEmployees; // get list box to display filtered list
            }
            else if (CBoxFT.IsChecked == true && CBoxPT.IsChecked == true) // if both boxes checked
            {
                ListBox.ItemsSource = employees; // get list box to display filtered list
            }
            
        }
    }
}

