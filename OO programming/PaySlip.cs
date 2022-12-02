using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    
    /// <summary>
    /// Class a capture details accociated with an employee's pay slip record
    /// </summary>
    public class PaySlip
    {
        public Employee SEmployee { get; set; }
        public int weekHours { get; set; }
        public double grossPay { get; set; }
        public double taxAmount { get; set; }
        public double netPay { get; set; }
        public double superAmount { get; set; }

        public string CreatePaySlip() 
        {
            string newLine = Environment.NewLine;
            return 
                  $"ID: " + SEmployee.Id + newLine
                 + "Employee Name: " + SEmployee.firstName + " " + SEmployee.lastName + newLine
                 //+ "Week Number: " + selectedEmployee.weekNumber + newLine
                 + "Week Hours: " + weekHours + newLine
                 + "Hour Rate: " + SEmployee.HourRate + newLine
                 + "Tax Threshold: " + SEmployee.TaxThreshold + newLine
                 + "Gross Pay: " + grossPay + newLine
                 + "Net Pay: " + netPay + newLine
                 + "Superannuation: " + superAmount
                 ;
        }
    }
        
}
