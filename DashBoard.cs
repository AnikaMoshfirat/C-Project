﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barber_Shop_Management_System
{
    public partial class DashBoard : Form
    {
        int id;//

        string connectionString = "data source=SUSANTA-ROG\\SQLEXPRESS; database=BarberBD; integrated security=SSPI";

        public DashBoard(int i)
        {
            id = i;
            InitializeComponent();
            string query = "SELECT * FROM Appointment";
            FillDataGridView(query);
        }
        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2(id);
            f2.Show();
        }
    }
}
