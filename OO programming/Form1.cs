using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace OO_programming
{
    public partial class Form1 : Form
    {
        //create a list of employee data object
        private List<Employee> employeeList = new List<Employee>();
        PaySlip sEmpPay = new PaySlip();


        public Form1()
        {
            InitializeComponent();

            // Add code below to complete the implementation to populate the listBox
            // by reading the employee.csv file into a List of PaySlip objects, then binding this to the ListBox.
            // CSV file format: <employee ID>, <first name>, <last name>, <hourly rate>,<taxthreshold>
            ReadCSV.ReadEmployeeData();
            for (int i = 0; i < ReadCSV._employeeId.Length; i++)
            {
                Employee e = new Employee();
                e.Id = ReadCSV._employeeId[i];
                e.firstName = ReadCSV._fName[i];
                e.lastName = ReadCSV._lName[i];
                e.HourRate = ReadCSV._hourRate[i];
                e.TaxThreshold = ReadCSV._taxThreshold[i];
                employeeList.Add(e);
            }
            listBox1.DataSource = employeeList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation to populate the
            // payment summary (textBox2) using the PaySlip and PayCalculatorNoThreshold
            // and PayCalculatorWithThresholds classes object and methods.
            sEmpPay.SEmployee = (Employee)listBox1.SelectedItem;//lstStudent.SelectedItem as StudentUnit  is ok;

            int weekHours = int.Parse(textBox1.Text);
            if (weekHours == 0 )
            {
                MessageBox.Show("You must enter the week hours");
                return;
            }
            else if (weekHours < 0)
            {
                MessageBox.Show("You must enter a valid week hours");
                return;
            }
            else
            {
                sEmpPay.weekHours = weekHours;
            }
            sEmpPay.grossPay = PayCalculator.GetGrossPay(sEmpPay.SEmployee.HourRate, sEmpPay.weekHours);
            sEmpPay.taxAmount = PayCalculator.GetTaxAmount(sEmpPay.SEmployee.TaxThreshold, sEmpPay.grossPay);
            sEmpPay.netPay = PayCalculator.GetNetPay(sEmpPay.taxAmount, sEmpPay.grossPay);
            sEmpPay.superAmount = PayCalculator.GetSuperAmount(sEmpPay.grossPay);

            textBox2.Text = sEmpPay.CreatePaySlip();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Add code below to complete the implementation for saving the
            // calculated payment data into a csv file.
            // File naming convention: Pay_<full name>_<datetimenow>.csv
            // Data fields expected - EmployeeId, Full Name, Hours Worked, Hourly Rate, Tax Threshold, Gross Pay, Tax, Net Pay, Superannuation
            DateTime now = DateTime.Now;
            string fileName = sEmpPay.SEmployee.firstName+"_"+sEmpPay.SEmployee.lastName;
            using (var writer = new StreamWriter($"../../../{fileName}_{now.Ticks}.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(sEmpPay);
            }
            textBox2.Text = "CSV File Exported Sucessfully!";
        }
    }
}
