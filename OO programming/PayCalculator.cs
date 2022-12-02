using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OO_programming
{
    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// Default class behaviour is tax calculated with tax threshold applied
    /// </summary>
    public class PayCalculator
    {
        
        public const double SUPERRATE = 0.105; //Super rate is 10.5% 

        public static double GetGrossPay(double r, int h)
        {
            
            double grossPay = r * h;
            return grossPay;
        }
        public static double GetTaxAmount(string t, double g)
        {
            double taxAmount = TaxAmountCalculator.CalcTaxAmount(t, g);
            return taxAmount;
        }

        public static double GetNetPay(double tax, double g)
        {
            double netPay = g - tax;
            return netPay;
        }
        public static double GetSuperAmount(double g)
        {
            double superAmount = g * SUPERRATE;          
            return superAmount;
        }

    }
}
