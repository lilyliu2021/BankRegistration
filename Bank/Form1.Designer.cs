namespace Bank
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            Insert = new Button();
            Read = new Button();
            Update = new Button();
            Delete = new Button();
            Clear = new Button();
            label12 = new Label();
            CustomerID = new TextBox();
            FirstName = new TextBox();
            LastName = new TextBox();
            StreetNo = new TextBox();
            StreetName = new TextBox();
            PostalCode = new TextBox();
            City = new TextBox();
            Province = new TextBox();
            Country = new TextBox();
            PhoneNo = new TextBox();
            Email = new TextBox();
            DOB = new DateTimePicker();
            Previous = new Button();
            Next = new Button();
            FindID = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(336, 34);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(607, 34);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 86);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 2;
            label3.Text = "DOB";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 135);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 3;
            label4.Text = "Street Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(324, 139);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 4;
            label5.Text = "Street Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 206);
            label6.Name = "label6";
            label6.Size = new Size(34, 20);
            label6.TabIndex = 5;
            label6.Text = "City";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(351, 210);
            label7.Name = "label7";
            label7.Size = new Size(65, 20);
            label7.TabIndex = 6;
            label7.Text = "Province";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(599, 139);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 7;
            label8.Text = "Postal Code";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(626, 210);
            label9.Name = "label9";
            label9.Size = new Size(60, 20);
            label9.TabIndex = 8;
            label9.Text = "Country";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(44, 275);
            label10.Name = "label10";
            label10.Size = new Size(108, 20);
            label10.TabIndex = 9;
            label10.Text = "Phone Number";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(324, 275);
            label11.Name = "label11";
            label11.Size = new Size(103, 20);
            label11.TabIndex = 10;
            label11.Text = "Email Address";
            // 
            // Insert
            // 
            Insert.Location = new Point(56, 343);
            Insert.Name = "Insert";
            Insert.Size = new Size(94, 29);
            Insert.TabIndex = 11;
            Insert.Text = "Insert";
            Insert.UseVisualStyleBackColor = true;
            Insert.Click += Insert_Click;
            // 
            // Read
            // 
            Read.Location = new Point(386, 343);
            Read.Name = "Read";
            Read.Size = new Size(94, 29);
            Read.TabIndex = 12;
            Read.Text = "Read";
            Read.UseVisualStyleBackColor = true;
            Read.Click += Read_Click;
            // 
            // Update
            // 
            Update.Location = new Point(56, 407);
            Update.Name = "Update";
            Update.Size = new Size(94, 29);
            Update.TabIndex = 13;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(207, 343);
            Delete.Name = "Delete";
            Delete.Size = new Size(94, 29);
            Delete.TabIndex = 14;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // Clear
            // 
            Clear.Location = new Point(723, 343);
            Clear.Name = "Clear";
            Clear.Size = new Size(94, 29);
            Clear.TabIndex = 15;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(43, 34);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 16;
            label12.Text = "CustomerID";
            // 
            // CustomerID
            // 
            CustomerID.Location = new Point(136, 27);
            CustomerID.Name = "CustomerID";
            CustomerID.Size = new Size(125, 27);
            CustomerID.TabIndex = 17;
            // 
            // FirstName
            // 
            FirstName.Location = new Point(433, 31);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(125, 27);
            FirstName.TabIndex = 18;
            // 
            // LastName
            // 
            LastName.Location = new Point(692, 31);
            LastName.Name = "LastName";
            LastName.Size = new Size(125, 27);
            LastName.TabIndex = 19;
            // 
            // StreetNo
            // 
            StreetNo.Location = new Point(155, 132);
            StreetNo.Name = "StreetNo";
            StreetNo.Size = new Size(125, 27);
            StreetNo.TabIndex = 20;
            StreetNo.Text = "1234";
            // 
            // StreetName
            // 
            StreetName.Location = new Point(434, 132);
            StreetName.Name = "StreetName";
            StreetName.Size = new Size(125, 27);
            StreetName.TabIndex = 21;
            StreetName.Text = "Cambie";
            // 
            // PostalCode
            // 
            PostalCode.Location = new Point(702, 132);
            PostalCode.Name = "PostalCode";
            PostalCode.Size = new Size(125, 27);
            PostalCode.TabIndex = 22;
            PostalCode.Text = "A1BC2D";
            // 
            // City
            // 
            City.Location = new Point(97, 196);
            City.Name = "City";
            City.Size = new Size(125, 27);
            City.TabIndex = 23;
            City.Text = "Vancouver";
            // 
            // Province
            // 
            Province.Location = new Point(433, 203);
            Province.Name = "Province";
            Province.Size = new Size(125, 27);
            Province.TabIndex = 24;
            Province.Text = "BC";
            // 
            // Country
            // 
            Country.Location = new Point(702, 203);
            Country.Name = "Country";
            Country.Size = new Size(125, 27);
            Country.TabIndex = 25;
            Country.Text = "Canada";
            // 
            // PhoneNo
            // 
            PhoneNo.Location = new Point(167, 272);
            PhoneNo.Name = "PhoneNo";
            PhoneNo.Size = new Size(125, 27);
            PhoneNo.TabIndex = 26;
            PhoneNo.Text = "123-456-7890";
            // 
            // Email
            // 
            Email.Location = new Point(434, 270);
            Email.Name = "Email";
            Email.Size = new Size(173, 27);
            Email.TabIndex = 27;
            Email.Text = "Email@email.com";
            // 
            // DOB
            // 
            DOB.Location = new Point(108, 79);
            DOB.Name = "DOB";
            DOB.Size = new Size(250, 27);
            DOB.TabIndex = 28;
            // 
            // Previous
            // 
            Previous.Location = new Point(556, 343);
            Previous.Name = "Previous";
            Previous.Size = new Size(94, 29);
            Previous.TabIndex = 29;
            Previous.Text = "Previous";
            Previous.UseVisualStyleBackColor = true;
            Previous.Click += Previous_Click;
            // 
            // Next
            // 
            Next.Location = new Point(556, 407);
            Next.Name = "Next";
            Next.Size = new Size(94, 29);
            Next.TabIndex = 30;
            Next.Text = "Next";
            Next.UseVisualStyleBackColor = true;
            Next.Click += Next_Click;
            // 
            // FindID
            // 
            FindID.Location = new Point(207, 407);
            FindID.Name = "FindID";
            FindID.Size = new Size(94, 29);
            FindID.TabIndex = 31;
            FindID.Text = "Find ID";
            FindID.UseVisualStyleBackColor = true;
            FindID.Click += FindID_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 507);
            Controls.Add(FindID);
            Controls.Add(Next);
            Controls.Add(Previous);
            Controls.Add(DOB);
            Controls.Add(Email);
            Controls.Add(PhoneNo);
            Controls.Add(Country);
            Controls.Add(Province);
            Controls.Add(City);
            Controls.Add(PostalCode);
            Controls.Add(StreetName);
            Controls.Add(StreetNo);
            Controls.Add(LastName);
            Controls.Add(FirstName);
            Controls.Add(CustomerID);
            Controls.Add(label12);
            Controls.Add(Clear);
            Controls.Add(Delete);
            Controls.Add(Update);
            Controls.Add(Read);
            Controls.Add(Insert);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Customer";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Button Insert;
        private Button Read;
        private Button Update;
        private Button Delete;
        private Button Clear;
        private Label label12;
        private TextBox CustomerID;
        private TextBox FirstName;
        private TextBox LastName;
        private TextBox StreetNo;
        private TextBox StreetName;
        private TextBox PostalCode;
        private TextBox City;
        private TextBox Province;
        private TextBox Country;
        private TextBox PhoneNo;
        private TextBox Email;
        private DateTimePicker DOB;
        private Button Previous;
        private Button Next;
        private Button FindID;
    }
}