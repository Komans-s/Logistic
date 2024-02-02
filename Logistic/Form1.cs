using System.Data;
using System.DirectoryServices.ActiveDirectory;

namespace Logistic
{
    public partial class Form1 : Form
    {
        Company comp;

        private Form parent;
        public Form1(Form parent)
        {
            InitializeComponent();
            comp = new Company();
            this.parent = parent;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee(tbxEmplyoeeName.Text,tbxEmployeeSurname.Text, Convert.ToInt32(tbxEmployeeID.Text), tbxEmployeeDuty.Text,null);
            bool result = comp.AddEmployee(emp);
            if (result)
                MessageBox.Show("New employee has been added!");
            else MessageBox.Show("Employee could not be added!");
            tbxEmplyoeeName.Text = "";
            tbxEmployeeSurname.Text = "";
            tbxEmployeeID.Text = "";
            tbxEmployeeDuty.Text = "";
        }

        private void btnAddTruck_Click(object sender, EventArgs e)
        {
            Trucks truck =  new Trucks(tbxTruckModel.Text,tbxTruckPlate.Text,Convert.ToInt32(tbxTruckYear.Text),tbxTruckLocation.Text);
            bool result = comp.AddTrucks(truck);
            if (result) MessageBox.Show("New truck has been added!");
            else MessageBox.Show("Truck could not be added!");
            tbxTruckModel.Text = "";
            tbxTruckPlate.Text = "";
            tbxTruckYear.Text = "";
            tbxTruckLocation.Text = "";
        }

        private void btnAddTrailer_Click(object sender, EventArgs e)
        {
            Trailers trailer = new Trailers(tbxTrailerPlate.Text,tbxTrailerLoad.Text,tbxTrailerLocation.Text);
            bool result = comp.AddTrailers(trailer);
            if (result) MessageBox.Show("New trailer has been added!");
            else MessageBox.Show("Trailer could not be added!");
            tbxTrailerPlate.Text = "";
            tbxTrailerLoad.Text = "";
            tbxTrailerLocation.Text = "";
        }

        private void tbcCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcCompany.SelectedIndex == 3)
            {
               
                DataSet ds1 = comp.MakeDBOperations("select * from EmployeeTable");
                int len1 = ds1.Tables[0].Rows.Count;
                for(int i = 0; i < len1; i++)
                {
                    if (ds1.Tables[0].Rows[i]["EmployeeDuty"].ToString() == "Driver" && ds1.Tables[0].Rows[i]["EmployeeTruckPlate"] == null)
                    {
                        cbxAssingDrivers.Items.Add(ds1.Tables[0].Rows[i]["EmployeeId"]);
                    }
                }

                DataSet ds2 = comp.MakeDBOperations("select TruckPlate from TruckTable");
                int len2 = ds2.Tables[0].Rows.Count;
                for (int i = 0; i < len2; i++)
                {
                    cbxAssingTrucksLeft.Items.Add(ds2.Tables[0].Rows[i]["TruckPlate"]);
                }

                DataSet ds3 = comp.MakeDBOperations("select TrailerPlate from TrailerTable");
                int len3 = ds3.Tables[0].Rows.Count;
                for (int i = 0; i < len3; i++)
                {
                    cbxAssingTrailers.Items.Add(ds3.Tables[0].Rows[i]["TrailerPlate"]);
                }

            }
            else
            {
                cbxAssingDrivers.Items.Clear();
                cbxAssingTrucksLeft.Items.Clear();
                cbxAssingTrailers.Items.Clear();
            }

            if(tbcCompany.SelectedIndex == 4) 
            {
                cbxDeassingDrivers.Items.Clear();
                cbxDeassingTrailers.Items.Clear();
                cbxDeassingTrucksLeft.Items.Clear();
                cbxDeassingTrucksRÝght.Items.Clear();

                DataSet ds1 = comp.MakeDBOperations("select * from EmployeeTable");
                int len1 = ds1.Tables[0].Rows.Count;
                for (int i = 0; i < len1; i++)
                {
                    if (ds1.Tables[0].Rows[i]["EmployeeDuty"].ToString() == "Driver" && ds1.Tables[0].Rows[i]["EmployeeTruckPlate"] != null)
                    {
                        cbxDeassingDrivers.Items.Add(ds1.Tables[0].Rows[i]["EmployeeId"]);
                    }
                }

                DataSet ds2 = comp.MakeDBOperations("select TruckPlate from TruckTable");
                int len2 = ds2.Tables[0].Rows.Count;
                for (int i = 0; i < len2; i++)
                {
                    cbxDeassingTrucksLeft.Items.Add(ds2.Tables[0].Rows[i]["TruckPlate"]);
                }
            }

            if(tbcCompany.SelectedIndex == 5)
            {
                cbxDeleteEmployee.Items.Clear();
                DataSet ds1 = comp.MakeDBOperations("select EmployeeId from EmployeeTable");
                int len1 = ds1.Tables[0].Rows.Count;
                for (int i = 0; i < len1; i++)
                {
                   cbxDeleteEmployee.Items.Add(ds1.Tables[0].Rows[i]["EmployeeId"]);
                }
            }

            if(tbcCompany.SelectedIndex == 6)
            {
                //dgvEmployeeList.Rows.Clear();
                DataSet ds = comp.MakeDBOperations("select * from EmployeeTable");
                dgvEmployeeList.DataSource = ds.Tables[0].DefaultView;
            }

            if(tbcCompany.SelectedIndex == 7)
            {
                //dgvTruckList.Rows.Clear();
                DataSet ds = comp.MakeDBOperations("select * from TruckTable");
                dgvTruckList.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void btnAssing_Click(object sender, EventArgs e)
        {

            DataSet ds = comp.MakeDBOperations("select * from EmployeeTable");
            int len = ds.Tables[0].Rows.Count;
            for(int i = 0;i < len;i++)
            {
                if(Convert.ToInt32(cbxAssingDrivers.SelectedItem) == Convert.ToInt32(ds.Tables[0].Rows[i][0]))
                {
                    comp.MakeDBOperations("update EmployeeTable set EmployeeTruckPlate = '"+cbxAssingTrucksLeft.SelectedItem+"'");
                    MessageBox.Show("Truck has been assinged!");
                    cbxAssingDrivers.Items.RemoveAt(cbxAssingDrivers.SelectedIndex);
                    cbxAssingTrucksLeft.Items.RemoveAt(cbxAssingTrucksLeft.SelectedIndex);
                    break;
                }
            }
 
            cbxAssingTrucksLeft.Text = "";
            cbxAssingDrivers.Text = "";  
            cbxAssignTrucksRight.Items.Clear();
           
            for(int i = 0;i < len;i++)
            {
                if(ds.Tables[0].Rows[i][4] != null)
                {
                    cbxAssignTrucksRight.Items.Add(ds.Tables[0].Rows[i][4]);
                }
            }
        }

        private void btnAssignTruckTrailer_Click(object sender, EventArgs e)
        {
            foreach(Trucks truck in comp.truckList)
            {
                if(cbxAssignTrucksRight.Text == truck.truckPlate)
                {
                    truck.truckTrailer = cbxAssingTrailers.Text;
                    MessageBox.Show("Trailer has been assinged to the truck!");
                    cbxAssignTrucksRight.Items.Remove(truck.truckPlate);
                    cbxAssingTrailers.Items.Remove(truck.truckTrailer);
                }
            }

            cbxAssignTrucksRight.Text = "";
            cbxAssingTrailers.Text = "";
        }

        private void btnDeassingDriverTruck_Click(object sender, EventArgs e)
        {
            foreach(Employee emp in comp.employeeList)
            {
                if(emp.EmployeeID == Convert.ToInt32(cbxDeassingDrivers.Text))
                {
                    emp.truck = null;
                    MessageBox.Show("Truck has been removed from the driver.");
                    cbxDeassingDrivers.Items.Remove(emp.EmployeeID);
                    cbxDeassingTrucksLeft.Items.Remove(cbxDeassingTrucksLeft.SelectedItem);
                    cbxAssingDrivers.Items.Add(emp.EmployeeID);
                    cbxAssingTrucksLeft.Items.Add(cbxDeassingTrucksLeft.SelectedItem);
                }
            }
            cbxDeassingDrivers.Text = "";
            cbxDeassingTrucksLeft.Text = "";
        }

        private void btnDeassingTruckTrailers_Click(object sender, EventArgs e)
        {
            foreach (Trucks truck in comp.truckList)
            {
                cbxAssingTrailers.Items.Add(cbxDeassingTrailers.SelectedItem);
                truck.truckTrailer = null;
                MessageBox.Show("Trailer has been removed from the truck.");
                cbxDeassingTrucksRÝght.Items.Remove(cbxDeassingTrucksRÝght.SelectedItem);
                cbxAssignTrucksRight.Items.Add(truck);
                cbxDeassingTrailers.Items.Remove(cbxDeassingTrailers.SelectedItem);
                break;
            }
            cbxDeassingTrucksRÝght.Text = "";
            cbxDeassingTrailers.Text = "";
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Employee will be deleted!", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (dr == DialogResult.Yes)
            {
                bool result = comp.DeleteEmployee(Convert.ToInt32(cbxDeleteEmployee.SelectedItem));

                if (result)
                {
                    cbxDeleteEmployee.Items.RemoveAt(cbxDeleteEmployee.SelectedIndex);
                    MessageBox.Show("Employee has been deleted!");
                }else
                {
                    MessageBox.Show("Employee could not be deleted!");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Visible = true;
        }
    }
}