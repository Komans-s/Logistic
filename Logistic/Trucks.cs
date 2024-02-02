using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logistic
{
    internal class Trucks
    {
        public string truckModel { get; set; }
        public string truckPlate { get; set; }
        public int truckYear { get; set; }
        public object truckTrailer { get; set; }
        public string truckLocation { get; set; }
        //public object truckDriver { get; set; }

        public Trucks(string truckModel, string truckPlate, int truckYear, string truckLocation) 
        {
            this.truckModel = truckModel;
            this.truckPlate = truckPlate;
            this.truckYear = truckYear;
            this.truckLocation = truckLocation;
        }

        public void AssingTrailer(Trailers trailer)
        {
            this.truckTrailer = trailer;
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
                sqlDataAdapter.Fill(dataSet, "Login");
                connection.Close();
            }
            catch
            {
                dataSet = null;
            }
            return dataSet;
        }

        public void addTruck(Trucks truck)
        {
            MakeDBOperations("insert into TruckTable(Truck Plate,Truck Model,Truck Year,Truck Trailer,Truck Location) values('"+truck.truckPlate+"','"+truck.truckModel+"','"+truck.truckYear+"','"+truck.truckTrailer+"','"+truck.truckLocation+"')");
        }
    }
}
