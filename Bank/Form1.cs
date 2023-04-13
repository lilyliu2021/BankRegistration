using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace Bank
{
    public partial class Form1 : Form
    {
        //SqlConnection connObj;
        int currentID;
        int branchID;
        string fName;
        string lName;
        DateTime dateBirth;
        string streetNo;
        string streetName;
        string city;
        string province;
        string postal;
        string country;
        string phoneNo;
        string email;

        public Form1()
        {
            currentID = 0;
            branchID = 0;
            fName = "";
            lName = "";
            dateBirth = DateTime.Now;
            streetNo = "";
            streetName = "";
            city = "";
            province = "";
            postal = "";
            country = "";
            phoneNo = "";
            email = "";

            //connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True");
            InitializeComponent();
        }
        void lastRow()
        {
            try
            {
                using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                {
                    //connection open
                    connObj.Open();
                    string queryLast = $"SELECT TOP 1 * FROM Customers ORDER BY CustomerID DESC";
                    using (SqlCommand cmd = new SqlCommand(queryLast, connObj))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerID.Text = reader.GetInt32(0).ToString() ?? string.Empty;
                                BranchID.Text = reader.GetInt32(1).ToString();
                                FirstName.Text = reader.GetValue(2).ToString() ?? string.Empty;
                                LastName.Text = reader.GetValue(3).ToString() ?? string.Empty;
                                DOB.Value = reader.GetDateTime(4);
                                StreetNo.Text = reader.GetValue(5).ToString() ?? string.Empty;
                                StreetName.Text = reader.GetValue(6).ToString() ?? string.Empty;
                                City.Text = reader.GetValue(7).ToString() ?? string.Empty;
                                Province.Text = reader.GetValue(8).ToString() ?? string.Empty;
                                PostalCode.Text = reader.GetValue(9).ToString() ?? string.Empty;
                                Country.Text = reader.GetValue(10).ToString() ?? string.Empty;
                                PhoneNo.Text = reader.GetValue(11).ToString() ?? string.Empty;
                                Email.Text = reader.GetValue(12).ToString() ?? string.Empty;

                                currentID = int.Parse(CustomerID.Text);
                            }
                        }
                        connObj.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed load the last row: ", ex.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)//Required step 1
        {
            lastRow();
            CustomerID.Text = (currentID + 1).ToString();
            FirstName.Clear();
            LastName.Clear();
        }


        bool ifExist()
        {
            //search if the record already exists (use sqlCommand to make the query, SqlDataReader go through the data)            
            try
            {
                using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                {
                    connObj.Open();

                    String queryFind = $"SELECT * FROM Customers WHERE CustomerID=@customerID";
                    using (SqlCommand cmdFind = new SqlCommand(queryFind, connObj))
                    {
                        cmdFind.Parameters.AddWithValue("@customerID", CustomerID.Text);

                        using (SqlDataReader reader = cmdFind.ExecuteReader())
                        {

                            if (reader.HasRows == false)
                            {
                                reader.Close();
                                return false;
                            }
                            while (reader.Read())
                            {
                                CustomerID.Text = reader.GetInt32(0).ToString() ?? string.Empty;
                                BranchID.Text = reader.GetInt32(1).ToString();
                                FirstName.Text = reader.GetValue(2).ToString() ?? string.Empty;
                                LastName.Text = reader.GetValue(3).ToString() ?? string.Empty;
                                DOB.Value = reader.GetDateTime(4);
                                StreetNo.Text = reader.GetValue(5).ToString() ?? string.Empty;
                                StreetName.Text = reader.GetValue(6).ToString() ?? string.Empty;
                                City.Text = reader.GetValue(7).ToString() ?? string.Empty;
                                Province.Text = reader.GetValue(8).ToString() ?? string.Empty;
                                PostalCode.Text = reader.GetValue(9).ToString() ?? string.Empty;
                                Country.Text = reader.GetValue(10).ToString() ?? string.Empty;
                                PhoneNo.Text = reader.GetValue(11).ToString() ?? string.Empty;
                                Email.Text = reader.GetValue(12).ToString() ?? string.Empty;
                                currentID = int.Parse(CustomerID.Text);
                            }
                            reader.Close();
                            connObj.Close();
                            return true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed Find The Record: ", ex.Message);
                return false;
            }
        }
        bool ifFilled()
        {
            if (string.IsNullOrWhiteSpace(FirstName.Text) || string.IsNullOrWhiteSpace(LastName.Text) || string.IsNullOrWhiteSpace(StreetNo.Text) || string.IsNullOrWhiteSpace(StreetName.Text) || string.IsNullOrWhiteSpace(City.Text) || string.IsNullOrWhiteSpace(Province.Text) || string.IsNullOrWhiteSpace(PostalCode.Text) || string.IsNullOrWhiteSpace(Country.Text) || string.IsNullOrWhiteSpace(PhoneNo.Text) || string.IsNullOrWhiteSpace(Email.Text))
            {
                return false;
            }
            else
            {
                currentID = int.Parse(CustomerID.Text);
                branchID = int.Parse(BranchID.Text);
                fName = FirstName.Text;
                lName = LastName.Text;
                dateBirth = DOB.Value;
                streetNo = StreetNo.Text;
                streetName = StreetName.Text;
                city = City.Text;
                province = Province.Text;
                postal = PostalCode.Text;
                country = Country.Text;
                phoneNo = PhoneNo.Text;
                email = Email.Text;
                return true;
            }

        }

        private void Insert_Click(object sender, EventArgs e)//Required step 2
        {

            // ------------This is a requierment--------------//
            //You should have a connection to the data base on your form load         

            // Using SqlCommand and SqlDataReader do the following

            //make sure all of the textboxes are filled in

            if (!ifFilled())
            {
                // The textbox is empty or contains only whitespace
                MessageBox.Show("Please fill in all fields to continue!");
                return;
            }
            // The textbox is not empty and does not contain only whitespace
            try
            {
                using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                {
                    connObj.Open();
                    // check if the record exists
                    String queryExist = $"SELECT * FROM Customers WHERE FirstName=@firstName AND LastName=@lastName AND Email=@email";
                    using (SqlCommand cmdExist = new SqlCommand(queryExist, connObj))
                    {
                        cmdExist.Parameters.AddWithValue("@customerID", CustomerID.Text);
                        cmdExist.Parameters.AddWithValue("@firstName", fName);
                        cmdExist.Parameters.AddWithValue("@lastName", lName);
                        cmdExist.Parameters.AddWithValue("@email", email);

                        using (SqlDataReader reader = cmdExist.ExecuteReader())
                        {
                            if (reader.HasRows)// the record exists
                            {
                                // if it does then tell the user it already exists 
                                MessageBox.Show("The Customer exists, can not be added!");
                                reader.Close();
                                return;
                            }
                        }

                        // the record does not exist                   
                        MessageBox.Show("Input the Information To Add the New Customer!");
                        //    if it doesn't exist proceed to adding the record 
                        //instert the data into the database    (use sqlCommand to insert data and a function that is part of the sqlCommand called .ExecuteNonQuery())

                        String queryAdd = $"INSERT INTO Customers(CustomerID,BranchID,FirstName,LastName,DOB,StreetNo,StreetName,City,Province,PostalCode,Country,PhoneNO,Email) VALUES (@customerID,@branchID,@firstName,@lastName,@DOB,@streetNo,@streetName,@city,@province,@postal,@country,@phoneNo,@email);";

                        using (SqlCommand cmdAdd = new SqlCommand(queryAdd, connObj))
                        {

                            cmdAdd.Parameters.AddWithValue("@customerID", CustomerID.Text);
                            cmdAdd.Parameters.AddWithValue("@branchID", BranchID.Text);
                            cmdAdd.Parameters.AddWithValue("@firstName", FirstName.Text);
                            cmdAdd.Parameters.AddWithValue("@lastName", LastName.Text);
                            cmdAdd.Parameters.AddWithValue("@DOB", DOB.Text);
                            cmdAdd.Parameters.AddWithValue("@streetNo", StreetNo.Text);
                            cmdAdd.Parameters.AddWithValue("@streetName", StreetName.Text);
                            cmdAdd.Parameters.AddWithValue("@city", City.Text);
                            cmdAdd.Parameters.AddWithValue("@province", Province.Text);
                            cmdAdd.Parameters.AddWithValue("@postal", PostalCode.Text);
                            cmdAdd.Parameters.AddWithValue("@country", Country.Text);
                            cmdAdd.Parameters.AddWithValue("@phoneNo", PhoneNo.Text);
                            cmdAdd.Parameters.AddWithValue("@email", Email.Text);
                            int addedRows = cmdAdd.ExecuteNonQuery();
                            if (addedRows > 0)
                            {
                                //Let the user know it was successful
                                MessageBox.Show("The Customer Added Successfully!");
                                CustomerID.Text = (currentID + 1).ToString();
                                currentID = int.Parse(CustomerID.Text);
                                FirstName.Clear();
                                LastName.Clear();
                            }
                        }
                    }
                    connObj.Close();
                }

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Failed Insert: ", ex.Message);
            }
        }

        //----------Optional--------//
        //add another form that connects to accounts so you can add a chequing account

        private void Update_Click(object sender, EventArgs e)//Required step 3
        {
            //-------- this is a requierment ---//
            //You should have a connection to the database on your form load
            // Using SqlCommand and SqlDataReader do the following

            //make sure all of the textboxes are filled in
            //if not ask them to fill it in
            if (!ifFilled())
            {
                // The textbox is empty or contains only whitespace
                MessageBox.Show("Please fill in all fields to continue!");
            }
            else
            {
                //Use an sql statement to update the data (use sqlCommand to Update data and a function that is part of the sqlCommand called .ExecuteNonQuery())
                try
                {
                    using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                    {
                        connObj.Open();
                        String queryUpdate = $"UPDATE Customers SET CustomerID=@customerID,BranchID=@branchID,FirstName=@firstName,LastName=@lastName,DOB=@DOB,StreetNo=@streetNo,StreetName=@streetName,City=@city,Province=@province,PostalCode=@postal,Country=@country,PhoneNO=@phoneNo,Email=@email WHERE CustomerID=@customerID;";
                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connObj))
                        {
                            cmdUpdate.Parameters.AddWithValue("@customerID", CustomerID.Text);
                            cmdUpdate.Parameters.AddWithValue("@branchID", BranchID.Text);
                            cmdUpdate.Parameters.AddWithValue("@firstName", FirstName.Text);
                            cmdUpdate.Parameters.AddWithValue("@lastName", LastName.Text);
                            cmdUpdate.Parameters.AddWithValue("@DOB", DOB.Text);
                            cmdUpdate.Parameters.AddWithValue("@streetNo", StreetNo.Text);
                            cmdUpdate.Parameters.AddWithValue("@streetName", StreetName.Text);
                            cmdUpdate.Parameters.AddWithValue("@city", City.Text);
                            cmdUpdate.Parameters.AddWithValue("@province", Province.Text);
                            cmdUpdate.Parameters.AddWithValue("@postal", PostalCode.Text);
                            cmdUpdate.Parameters.AddWithValue("@country", Country.Text);
                            cmdUpdate.Parameters.AddWithValue("@phoneNo", PhoneNo.Text);
                            cmdUpdate.Parameters.AddWithValue("@email", Email.Text);
                            int updatedRows = cmdUpdate.ExecuteNonQuery();
                            if (updatedRows > 0)
                            {
                                //Let the user know it was successful   
                                MessageBox.Show("Record Updated!");
                                currentID = int.Parse(CustomerID.Text);
                            }
                        }
                        connObj.Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Failed Update: ", ex.Message);
                }
            }
        }

        private void FindID_Click(object sender, EventArgs e)//Required step 4
        {
            //-------- this is a requierment ---//
            //if the customer ID is empty, let the user know to fill it in and leave the function
            CustomerID.Enabled = true;
            if (CustomerID.Text == "")
            {
                MessageBox.Show("Input CustomerID. ");
                return;
            }
            else
            {
                //Search for the record
                //if found add to the textboxes using DataReader
                //if not found let the user know        

                if (!ifExist())
                {
                    MessageBox.Show("Can Not Find The Customer!");
                    currentID = int.Parse(CustomerID.Text);
                    FirstName.Clear();
                    LastName.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show("Find The Customer!");
                    return;
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)//Required step 5
        {
            if (ifExist())
            {
                //-------- this is a requierment ---//
                // ask the user if they are sure they want to 
                DialogResult deleteOrNot = MessageBox.Show("Are You Sure You Want To Delete?", "Yes/No", MessageBoxButtons.YesNo);
                //    if they dont want to delete, leave the function
                if (deleteOrNot == DialogResult.No)
                {
                    return;
                }
                //    if they do proceed to the next step
                else
                {
                    //search for the record
                    //if you find it delete it
                    try
                    {
                        using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                        {
                            connObj.Open();
                            String queryDelete = $"DELETE FROM Customers WHERE CustomerID=@customerID;";
                            using (SqlCommand cmdDelete = new SqlCommand(queryDelete, connObj))
                            {
                                cmdDelete.Parameters.AddWithValue("@customerID", CustomerID.Text);
                                int deletedRows = cmdDelete.ExecuteNonQuery();
                                if (deletedRows > 0)
                                {
                                    //inform the user it had successfuly been deleted
                                    MessageBox.Show("Record Delete Successfully!!");
                                    lastRow();
                                }
                            }
                            connObj.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Failed Delete: ", ex.Message);
                    }

                    // clear data form form
                }
            }
            else
            {
                MessageBox.Show("Can Not Find The Customer!");
            }
        }

        private void Clear_Click(object sender, EventArgs e)//Required step 6
        {
            //clear all textboxes
            currentID = 0;
            branchID = 0;
            fName = "";
            lName = "";
            dateBirth = DateTime.Now;
            streetNo = "";
            streetName = "";
            city = "";
            province = "";
            postal = "";
            country = "";
            phoneNo = "";
            email = "";
            CustomerID.Text = currentID.ToString();
            BranchID.Text = branchID.ToString();
            FirstName.Text = fName;
            LastName.Text = lName;
            DOB.Value = dateBirth;
            StreetNo.Text = streetNo;
            StreetName.Text = streetName;
            City.Text = city;
            Province.Text = province;
            PostalCode.Text = postal;
            Country.Text = country;
            PhoneNo.Text = phoneNo;
            Email.Text = email;
        }

        private void Previous_Click(object sender, EventArgs e)//Optional
        {
            //search the Database for the first customer that who Has an ID less than the current customer

            //if there is not ID less than the current, let the user know they are at the beginning of the file
            //If you do find the data, Display in the Texboxes 
            
            try
            {
                using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                {
                    connObj.Open();
                    string queryPrevious = $"SELECT TOP 1 * FROM Customers WHERE CustomerID < @customerID ORDER BY CustomerID DESC";
                    using (SqlCommand cmdPrevious = new SqlCommand(queryPrevious, connObj))
                    {
                        cmdPrevious.Parameters.AddWithValue("@customerID", CustomerID.Text);
                        using (SqlDataReader reader = cmdPrevious.ExecuteReader())
                        {
                            if (reader.Read())
                            {                                
                                CustomerID.Text = reader.GetInt32(0).ToString() ?? string.Empty;
                                BranchID.Text = reader.GetInt32(1).ToString();
                                FirstName.Text = reader.GetValue(2).ToString() ?? string.Empty;
                                LastName.Text = reader.GetValue(3).ToString() ?? string.Empty;
                                DOB.Value = reader.GetDateTime(4);
                                StreetNo.Text = reader.GetValue(5).ToString() ?? string.Empty;
                                StreetName.Text = reader.GetValue(6).ToString() ?? string.Empty;
                                City.Text = reader.GetValue(7).ToString() ?? string.Empty;
                                Province.Text = reader.GetValue(8).ToString() ?? string.Empty;
                                PostalCode.Text = reader.GetValue(9).ToString() ?? string.Empty;
                                Country.Text = reader.GetValue(10).ToString() ?? string.Empty;
                                PhoneNo.Text = reader.GetValue(11).ToString() ?? string.Empty;
                                Email.Text = reader.GetValue(12).ToString() ?? string.Empty; 
                            }
                            else
                            {
                                MessageBox.Show("It is the first record!");
                            }
                            reader.Close();
                        }
                    }
                    connObj.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed Move Previous: ", ex.Message);
            }
        }

        private void Next_Click(object sender, EventArgs e)//Optional
        {
            //-------- this is a requierment ---//
            //search the Database for the first customer that who Has an ID Greater than the current customer
            //if there is no ID greater than the current, let the user know they are at the end of the file
            //If you do find the data, Display in the Texboxes
                       
            try
            {
                using (SqlConnection connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True"))
                {
                    connObj.Open();
                    string queryNext = $"SELECT TOP 1 * FROM Customers WHERE CustomerID > @customerID ORDER BY CustomerID ASC";
                    using (SqlCommand cmdNext = new SqlCommand(queryNext, connObj))
                    {
                        cmdNext.Parameters.AddWithValue("@customerID", CustomerID.Text);
                        using (SqlDataReader reader = cmdNext.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                CustomerID.Text = reader.GetInt32(0).ToString() ?? string.Empty;
                                BranchID.Text = reader.GetInt32(1).ToString();
                                FirstName.Text = reader.GetValue(2).ToString() ?? string.Empty;
                                LastName.Text = reader.GetValue(3).ToString() ?? string.Empty;
                                DOB.Value = reader.GetDateTime(4);
                                StreetNo.Text = reader.GetValue(5).ToString() ?? string.Empty;
                                StreetName.Text = reader.GetValue(6).ToString() ?? string.Empty;
                                City.Text = reader.GetValue(7).ToString() ?? string.Empty;
                                Province.Text = reader.GetValue(8).ToString() ?? string.Empty;
                                PostalCode.Text = reader.GetValue(9).ToString() ?? string.Empty;
                                Country.Text = reader.GetValue(10).ToString() ?? string.Empty;
                                PhoneNo.Text = reader.GetValue(11).ToString() ?? string.Empty;
                                Email.Text = reader.GetValue(12).ToString() ?? string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("It is the Last record!");
                            }
                            reader.Close();
                        }
                    }
                    connObj.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Failed Move Next: ", ex.Message);
            }
        }

        private void ShowAll_Click(object sender, EventArgs e)//Optional
        {
            //-------- this is not a requierment but can be fun to add to your form ---//
            // show all customers in a new form 
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}