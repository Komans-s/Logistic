using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Logistic
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int EmployeeID { get; set; }
        public string employeeDuty { get; set; }
        public object truck { get; set; }

        public Employee(string name,string surname, int employeeID, string employeeDuty,object truck) 
        {
            this.Name = name;
            this.Surname = surname;
            this.EmployeeID = employeeID;
            this.employeeDuty = employeeDuty;
            this.truck = truck;
        }
    }
}
