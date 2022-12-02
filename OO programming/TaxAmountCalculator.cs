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
    /// calculat employee's tax amount according to the tax threshold that is read from the employee.csv file
    /// </summary>
    public class TaxAmountCalculator
    {
        private static int[] _minNum;
        private static int[] _maxNum;
        private static double[] _taxRateA;
        private static double[] _taxRateB; 

        public static void ReadData(string fileName)
        {
            //read csv data and store the data into the arrays
            List<int> minNum = new List<int>();
            List<int> maxNum = new List<int>();
            List<double> taxRateA = new List<double>();
            List<double> taxRateB = new List<double>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(fileName))
            {
                using (var csv = new CsvReader(reader, config))
                {
                    while (csv.Read())
                    {
                        minNum.Add(csv.GetField<int>(0));
                        maxNum.Add(csv.GetField<int>(1));
                        taxRateA.Add(csv.GetField<double>(2));
                        taxRateB.Add(csv.GetField<double>(3));
                    }
                }
            }
            _minNum = minNum.ToArray();
            _maxNum = maxNum.ToArray();
            _taxRateA = taxRateA.ToArray();
            _taxRateB = taxRateB.ToArray();
        }

        public static double CalcTaxAmount(string t, double g)
        {
            //find taxRateA & taxRateB
            if (t == "Y")
            {
                ReadData("../../../taxrate-withthreshold.csv");
            }
            else if (t == "N")
            {
                ReadData("../../../taxrate-nothreshold.csv");
            }
            //ReadData(t=="Y"?"../../../taxrate-withthreshold.csv":"../../../taxrate-nothreshold.csv");

            //return taxAmount of a given grossPay
            double a = (double)0;
            double b = (double)0;
            for (int i = 0; i < _minNum.Length; i++)
            {

                if (g >= _minNum[i] && g <= _maxNum[i])
                {
                    a = _taxRateA[i];
                    b = _taxRateB[i];
                }   
            }
            double taxAmount = Math.Round((a * (g+0.99) - b),4); 
            return taxAmount;
        }
    }
        
}
