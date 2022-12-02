using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_programming
{
    public abstract class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }

    public class Employee:Person
    {
        public int Id { get; set; }
        public double HourRate { get; set; }
        public string TaxThreshold { get; set; }

        public override string ToString()
        {
            return $"{Id} {firstName} {lastName}";
        }
    }
}
