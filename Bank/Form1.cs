using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Bank
{
    public partial class Form1 : Form
    {
        SqlConnection connObj;
        int currentID;
        int branchID;
        string fName;
        string lName;
        DateTime dateBirth;
        string streetNo;
        string streetName;
        string city;
        string province;
        string Postal;
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
            Postal = "";
            country = "";
            phoneNo = "";
            email = "";

            connObj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\liliu\source\repos\C#\Bank\Bank\Bank.mdf';Integrated Security=True");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//Required step 1
        {
            //connection open
            connObj.Open();
        }

        
        bool ifExist()
        {
            //search if the record already exists (use sqlCommand to make the query, SqlDataReader go through the data)            

            String queryFind = $"SELECT * FROM Customer WHERE CustomerID={CustomerID.Text};";

            SqlCommand cmdFind = new SqlCommand(queryFind, connObj);
            SqlDataReader reader = cmdFind.ExecuteReader();

            if (reader.HasRows == false)
            {
                reader.Close();
                return false;
            }
            while (reader.Read())
            {
                currentID = reader.GetInt32(0);
                branchID = reader.GetInt32(1);
                fName = reader.GetValue(2).ToString();
                lName = reader.GetValue(3).ToString();
                dateBirth = reader.GetDateTime(4);
                streetNo = reader.GetValue(5).ToString();
                streetName = reader.GetValue(6).ToString();
                city = reader.GetValue(7).ToString();
                province = reader.GetValue(8).ToString();
                Postal = reader.GetValue(9).ToString();
                country = reader.GetValue(10).ToString();
                phoneNo = reader.GetValue(11).ToString();
                email = reader.GetValue(12).ToString();
                CustomerID.Text = currentID.ToString();
                BranchID.Text = branchID.ToString();
                FirstName.Text = fName;
                LastName.Text = lName;
                DOB.Value = dateBirth;
                StreetNo.Text = streetNo;
                StreetName.Text = streetName;
                City.Text = city;
                Province.Text = province;
                PostalCode.Text = Postal;
                Country.Text = country;
                PhoneNo.Text = phoneNo;
                Email.Text = email;
            }
            reader.Close();
            return true;           
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
                branchID=int .Parse(BranchID.Text);
                fName = FirstName.Text;
                lName = LastName.Text;
                dateBirth = DOB.Value;
                streetNo = StreetNo.Text;
                streetName = StreetName.Text;
                city = City.Text;
                province = Province.Text;
                Postal = PostalCode.Text;
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
            }
            else
            {
                // The textbox is not empty and does not contain only whitespace

                // check if the record exists
                if (ifExist())
                {
                    // the record exists
                    //    if it does then tell the user it already exists 
                    MessageBox.Show("The Customer exists, can not be added!");
                }
                else
                {
                    // the record does not exist                   
                    MessageBox.Show("The Customer does not exist, add the record!");
                    //    if it doesn't exist proceed to adding the record 

                    //instert the data into the database    (use sqlCommand to insert data and a function that is part of the sqlCommand called .ExecuteNonQuery())
                    try
                    {
                        String queryAdd = $"INSERT INTO Customer(CustomerID,BranchID,FirstName,LastName,DOB,StreetNo,StreetName,City,Province,PostalCode,Country,PhoneNO,Email) VALUES ('{CustomerID.Text}','{BranchID.Text}','{FirstName.Text}','{LastName.Text}','{DOB.Value}','{StreetNo.Text}','{StreetName.Text}','{City.Text}','{Province.Text}','{PostalCode.Text}','{Country.Text}','{PhoneNo.Text}','{Email.Text}');";

                        SqlCommand cmdAdd = new SqlCommand(queryAdd, connObj);
                        int addedRows = cmdAdd.ExecuteNonQuery();
                        if (addedRows > 0)
                        {
                            //Let the user know it was successful
                            MessageBox.Show("Record Added!");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Failed Insert: ", ex.Message);
                    }

                    //CustomerID.Text = getCurrentID().ToString();
                    currentID = int.Parse(CustomerID.Text);
                    FirstName.Clear();
                    LastName.Clear();
                    //----------Optional--------//
                    //add another form that connects to accounts so you can add a chequing account
                }

            }
        }

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
                    String queryUpdate = $"UPDATE Customer SET CustomerID={currentID},BranchID={branchID},FirstName='{fName}',LastName='{lName}',DOB='{dateBirth}',StreetNo='{streetNo}',StreetName='{streetName}',City='{city}',Province='{province}',PostalCode='{Postal}',Country='{country}',PhoneNO='{phoneNo}',Email='{email}' WHERE CustomerID={CustomerID.Text};";

                    SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connObj);
                    int updatedRows = cmdUpdate.ExecuteNonQuery();
                    if (updatedRows > 0)
                    {
                        //Let the user know it was successful   
                        MessageBox.Show("Record Updated!");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Failed Update: ", ex.Message);
                }

                currentID = int.Parse(CustomerID.Text);
                FirstName.Clear();
                LastName.Clear();
            }
        }

        private void FindID_Click(object sender, EventArgs e)//Required step 4
        {
            //-------- this is a requierment ---//
            //if the customer ID is empty, let the user know to fill it in and leave the function
            if (CustomerID.Text == "")
            {
                MessageBox.Show("Input a CustomerID");
                return;
            }
            else
            {
                //Search for the record
                //if found add to the textboxes using DataReader
                //if not found let the user know        

                if (!ifExist())
                {
                    MessageBox.Show("Can not find the customer!");
                    currentID = int.Parse(CustomerID.Text);
                    FirstName.Clear();
                    LastName.Clear();
                    return;
                }
                else
                {
                    MessageBox.Show("Find the customer!");
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
                DialogResult deleteOrNot = MessageBox.Show("Are you sure you want to delete?", "Yes/No", MessageBoxButtons.YesNo);
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
                        String queryDelete = $"DELETE FROM Customer WHERE CustomerID={currentID};";

                        SqlCommand cmdDelete = new SqlCommand(queryDelete, connObj);
                        int deletedRows = cmdDelete.ExecuteNonQuery();
                        if (deletedRows > 0)
                        {
                            //inform the user it had successfuly been deleted
                            MessageBox.Show("Record Delete Successfully!!");
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
                MessageBox.Show("Can not find the customer!");
                currentID = int.Parse(CustomerID.Text);
                FirstName.Clear();
                LastName.Clear();
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
            Postal = "";
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
            PostalCode.Text = Postal;
            Country.Text = country;
            PhoneNo.Text = phoneNo;
            Email.Text = email;
        }

        private void Previous_Click(object sender, EventArgs e)//Optional
        {
            //search the Database for the first customer that who Has an ID less than the current customer

            //if there is not ID less than the current, let the user know they are at the beginning of the file
            //If you do find the data, Display in the Texboxes 
            int currentId = int.Parse(CustomerID.Text); // Get the ID of the current record
            try
            {
                // Create a SQL query to retrieve the previous record based on the ID
                string queryPrevious = $"SELECT TOP 1 * FROM Customer WHERE CustomerID < {currentId} ORDER BY CustomerID DESC";
                // Create a new SqlCommand object with the SQL query and connection
                SqlCommand cmd = new SqlCommand(queryPrevious, connObj);
                // Execute the SQL query and create a SqlDataReader object
                SqlDataReader reader = cmd.ExecuteReader();
                // Read the results and populate the form controls with the data
                if (reader.Read())
                {
                    MessageBox.Show("Find The Previous Record!");
                    currentID = reader.GetInt32(0);
                    branchID=reader.GetInt32(1);
                    fName = reader.GetValue(2).ToString();
                    lName = reader.GetValue(3).ToString();
                    dateBirth = reader.GetDateTime(4);
                    streetNo = reader.GetValue(5).ToString();
                    streetName = reader.GetValue(6).ToString();
                    city = reader.GetValue(7).ToString();
                    province = reader.GetValue(8).ToString();
                    Postal = reader.GetValue(9).ToString();
                    country = reader.GetValue(10).ToString();
                    phoneNo = reader.GetValue(11).ToString();
                    email = reader.GetValue(12).ToString();
                    CustomerID.Text = currentID.ToString();
                    BranchID.Text = branchID.ToString();
                    FirstName.Text = fName;
                    LastName.Text = lName;
                    DOB.Value = dateBirth;
                    StreetNo.Text = streetNo;
                    StreetName.Text = streetName;
                    City.Text = city;
                    Province.Text = province;
                    PostalCode.Text = Postal;
                    Country.Text = country;
                    PhoneNo.Text = phoneNo;
                    Email.Text = email;
                    currentId = int.Parse(CustomerID.Text);
                }
                else
                {
                    MessageBox.Show("It is the first record!");
                }
                // Close the SqlDataReader
                reader.Close();
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
            // int currentId = int.Parse(CustomerID.Text); // Get the ID of the current record
            int currentId = int.Parse(CustomerID.Text); // Get the ID of the current record
            try
            {
                // Create a SQL query to retrieve the previous record based on the ID
                string queryNext = $"SELECT TOP 1 * FROM Customer WHERE CustomerID > {currentId} ORDER BY CustomerID ASC";
                // Create a new SqlCommand object with the SQL query and connection
                SqlCommand cmd = new SqlCommand(queryNext, connObj);
                // Execute the SQL query and create a SqlDataReader object
                SqlDataReader reader = cmd.ExecuteReader();
                // Read the results and populate the form controls with the data
                if (reader.Read())
                {
                    MessageBox.Show("Find The Next Record!");
                    currentID = reader.GetInt32(0);
                    branchID=reader.GetInt32(1);
                    fName = reader.GetValue(2).ToString();
                    lName = reader.GetValue(3).ToString();
                    dateBirth = reader.GetDateTime(4);
                    streetNo = reader.GetValue(5).ToString();
                    streetName = reader.GetValue(6).ToString();
                    city = reader.GetValue(7).ToString();
                    province = reader.GetValue(8).ToString();
                    Postal = reader.GetValue(9).ToString();
                    country = reader.GetValue(10).ToString();
                    phoneNo = reader.GetValue(11).ToString();
                    email = reader.GetValue(12).ToString();
                    CustomerID.Text = currentID.ToString();
                    BranchID.Text = branchID.ToString();
                    FirstName.Text = fName;
                    LastName.Text = lName;
                    DOB.Value = dateBirth;
                    StreetNo.Text = streetNo;
                    StreetName.Text = streetName;
                    City.Text = city;
                    Province.Text = province;
                    PostalCode.Text = Postal;
                    Country.Text = country;
                    PhoneNo.Text = phoneNo;
                    Email.Text = email;
                    currentId = int.Parse(CustomerID.Text);
                }
                else
                {
                    MessageBox.Show("It is the Last record!");
                }
                // Close the SqlDataReader
                reader.Close();
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