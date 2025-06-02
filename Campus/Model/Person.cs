using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Campus.Model
{
    public abstract class Person
    {
        public string FiscalCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string fiscalCode, string name, string surname)
        {
            FiscalCode = fiscalCode;
            Name = name;
            Surname = surname;
        }
    }
}
