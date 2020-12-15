using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2_15_12_2020
{
    public abstract class Employee
    {
        public string FirstName { get; set; } // first name property
        public string Surname { get; set; } // surname property
        public abstract decimal CalculateMonthlyPay(decimal MonthlyPay); // abstract class for CalculateMonthlyPay

        public override string ToString()
        {
            return string.Format($"{Surname}, {FirstName}");
        }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; } // Salary property

        public override decimal CalculateMonthlyPay(decimal MonthlyPay) // override abstract method for MonthlyPay
        {
            MonthlyPay = Salary / 12; // calc to find monthly pay of a Salary
            return MonthlyPay; // return the MonthlyPay
        }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; set; } // HourlyRate property
        public double HoursWorked { get; set; } // HoursWorked property

        public override decimal CalculateMonthlyPay(decimal MonthlyPay) // override abstract method for MonthlyPay
        {
            MonthlyPay = HourlyRate * (decimal)HoursWorked; // calc MonthlyRate by HourlyRate and HoursWorked also casted decimal to HoursWorked
            return MonthlyPay; // return MonthlyPay
        }
    }
}
