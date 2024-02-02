using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic
{
    internal class Trailers
    {
        public string trailerPlate { get; set; }
        public string trailerLoad { get; set; }
        public string trailerLocation { get; set; }

        public Trailers(string trailerPlate, string trailerLoad, string trailerLocation) 
        {
            this.trailerPlate = trailerPlate;
            this.trailerLoad = trailerLoad;
            this.trailerLocation = trailerLocation;
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

        public void addTrailer(Trailers trailer)
        {
            MakeDBOperations("insert into TrailerTable(Trailer plate,Trailer Load,Trailer Location) values('"+trailer.trailerPlate+"','"+trailer.trailerLoad+"','"+trailer.trailerLocation+"')");
        }
    }
}
