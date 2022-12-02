using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    /// <summary>
    /// read employee's data from employee.csv file
    /// </summary>
    public class ReadCSV
    {
        //list employee attributes
        public static int[] _employeeId;
        public static string[] _fName;
        public static string[] _lName;
        public static double[] _hourRate;
        public static string[] _taxThreshold;

        public static void ReadEmployeeData()
        {
            //read csv data and store the data into the arrays
            List<int> employeeId = new List<int>();
            List<string> fName = new List<string>();
            List<string> lName = new List<string>();
            List<double> hourRate = new List<double>();
            List<string> taxThreshold = new List<string>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader("../../../employee.csv"))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    while (csv.Read())
                    {
                        employeeId.Add(csv.GetField<int>(0));
                        fName.Add(csv.GetField<string>(1));
                        lName.Add(csv.GetField<string>(2));
                        hourRate.Add(csv.GetField<double>(3));
                        taxThreshold.Add(csv.GetField<string>(4));
                    }
                }
            }
            _employeeId = employeeId.ToArray();
            _fName = fName.ToArray();
            _lName = lName.ToArray();
            _hourRate = hourRate.ToArray();
            _taxThreshold = taxThreshold.ToArray();
        }        
    }
}
