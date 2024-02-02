using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic
{
    internal class Company
    {
        public List<Employee> employeeList;
        public List<Trailers> trailerList;
        public List<Trucks> truckList;

        public Company() 
        {
            employeeList= new List<Employee>();
            trailerList= new List<Trailers>();
            truckList= new List<Trucks>();
        }

        public bool AddEmployee(Employee employee) 
        {
            DataSet ds = MakeDBOperations("insert into EmployeeTable(EmployeeId,EmployeeName,EmployeeSurname,EmployeeDuty,EmployeeTruckPlate) values('" + employee.EmployeeID + "','" + employee.Name + "','" + employee.Surname + "','"+employee.employeeDuty+"','"+employee.truck+"')");
        
            if(ds!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }

        public bool AddTrailers(Trailers trailer) 
        {
            DataSet ds = MakeDBOperations("insert into TrailerTable(TrailerPlate,TrailerLoad,TrailerLocation) values('"+trailer.trailerPlate+"','"+trailer.trailerLoad+"','"+trailer.trailerLocation+"')");

            if (ds != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddTrucks(Trucks truck) 
        {
            DataSet ds = MakeDBOperations("insert into TruckTable(TruckPlate,TruckModel,TruckYear,TruckTrailer,TruckLocation) values('"+truck.truckPlate+"','"+truck.truckModel+"','"+truck.truckYear+"','"+truck.truckTrailer+"','"+truck.truckLocation+"')");
            if (ds != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteEmployee(int empid)
        {
            DataSet ds = MakeDBOperations("delete from EmployeeTable where EmployeeId = '" + empid + "'");

            if(ds!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataSet MakeDBOperations(string query)
        {
            DataSet dataSet = null;
            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\hikmet can yıldız\source\repos\Logistic\Logistic\DatabaseComp.mdf"";Integrated Security=True");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);

                connection.Open();
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Table");
                connection.Close();
            }
            catch
            {
                dataSet = null;
            }
            return dataSet;
        }
    }
}
