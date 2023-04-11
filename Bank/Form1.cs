using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Metrics;

namespace Bank
{
    public partial class Form1 : Form
    {
        SqlConnection connObj;
        int currentID;
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

        //int getCurrentID()
        //{
        //    string queryCount = $"SELECT COUNT(*) FROM Customer";
        //    SqlCommand cmd = new SqlCommand(queryCount, connObj);
        //    // execute the query and get the count of matching records
        //    int count = (int)cmd.ExecuteScalar();
        //    count++;
        //    return count;
        //}
        bool ifExist()
        {
            //search if the record already exists (use sqlCommand to make the query, SqlDataReader go through the data)

            //string querySelect = $"SELECT COUNT(*) FROM Customer WHERE CustomerID={CustomerID.Text}";
            //SqlCommand cmd = new SqlCommand(querySelect, connObj);

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
            // execute the query and get the count of matching records
            //int count = (int)cmd.ExecuteScalar();
            //if (count > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
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
                        String queryAdd = $"INSERT INTO Customer(CustomerID,FirstName,LastName,DOB,StreetNo,StreetName,City,Province,PostalCode,Country,PhoneNO,Email) VALUES ('{CustomerID.Text}','{FirstName.Text}','{LastName.Text}','{DOB.Value}','{StreetNo.Text}','{StreetName.Text}','{City.Text}','{Province.Text}','{PostalCode.Text}','{Country.Text}','{PhoneNo.Text}','{Email.Text}');";

                        SqlCommand cmdAdd = new SqlCommand(queryAdd, connObj);
                        cmdAdd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Failed Insert: ", ex.Message);
                    }

                    //Let the user know it was successful
                    MessageBox.Show("Record Added!");
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
                String queryUpdate = $"UPDATE Customer SET CustomerID={currentID},FirstName='{fName}',LastName='{lName}',DOB='{dateBirth}',StreetNo='{streetNo}',StreetName='{streetName}',City='{city}',Province='{province}',PostalCode='{Postal}',Country='{country}',PhoneNO='{phoneNo}',Email='{email}' WHERE CustomerID={CustomerID.Text};";

                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, connObj);
                cmdUpdate.ExecuteNonQuery();
                //Let the user know it was successful   
                MessageBox.Show("Record Updated!");
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
                    String queryDelete = $"DELETE FROM Customer WHERE CustomerID={currentID};";

                    SqlCommand cmdDelete = new SqlCommand(queryDelete, connObj);
                    cmdDelete.ExecuteNonQuery();
                    //inform the user it had successfuly been deleted
                    MessageBox.Show("Record Delete Successfully!!");
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
        }
        private void Read_Click(object sender, EventArgs e)//Optional
        {
            //-------- this is not a requierment but can be fun to add to your form ---//
            // show all customers in a new form 
        }

        private void button1_Click(object sender, EventArgs e)//Optional
        {
            //-------- this is a requierment ---//
            //search the Database for the first customer that who Has an ID Greater than the current customer
            //if there is no ID greater than the current, let the user know they are at the end of the file
            //If you do find the data, Display in the Texboxes  
        }
    }
}